Shader "Unlit/ScreenWarp"
{
    Properties
    {
        _MainTex ("RGBA", 2D) = "gray" {}
        _Opacity ("transparent", range(0, 1)) = 0.5
        _WarpMidVal ("disturbate median", range(0, 1)) = 0.5
        _WarpInt ("disturbate intensity", range(0, 5)) = 1
    }
    SubShader
    {
        Tags {
            "Queue" = "Transparent"
            "RenderType"="Transparent"
            // 关闭阴影投射
            "ForceNoShadowCasting" = "True"
            // 不响应投射器
            "TgnoreProjector" = "True"
        }
        GrabPass {
            "_BGTex"
        }

        Pass {
            Name "FORWARD"
            Tags {
                "LightMode" = "ForwardBase"
            } 
            Blend One OneMinusSrcAlpha

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbass_fullshadows
            #pragma target 3.0

            // 输入参数
            uniform sampler2D _MainTex;
            uniform half _Opacity;
            uniform half _WarpMidVal;
            uniform half _WarpInt;
            uniform sampler2D _BGTex;

            // 输入结构
            struct VertexInput {
                float4 vertex: POSITION;
                float2 uv: TEXCOORD0;
            };
            
            // 输出结构
            struct VertexOutput {
                float4 pos: SV_POSITION;
                float uv: TEXCOORD0;
                float4 grabPos: TEXCOORD1;
            };

            // 输入结果
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv; 
                    o.grabPos = ComputeGrabScreenPos(o.pos);
                return o; 
            }
            // 输出结果
            half4 frag(VertexOutput i): COLOR {
                half4 var_MainTex = tex2D(_MainTex, i.uv);
                i.grabPos.xy += (var_MainTex.r - _WarpMidVal) * _WarpInt * _Opacity;
                half3 var_BGTex = tex2Dproj(_BGTex, i.grabPos).rgb;
                half3 finalRGB = lerp(1.0, var_MainTex.rgb, _Opacity) * var_BGTex;
                half opacity = var_MainTex.a;
                return half4(finalRGB * opacity, opacity);
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
