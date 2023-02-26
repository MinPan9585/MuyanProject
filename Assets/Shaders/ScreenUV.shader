Shader "Unlit/ScreenUV"
{
    Properties
    {
        _MainTex ("RGBA", 2D) = "gray" {}
        _Opacity ("transparent", range(0, 1)) = 0.5
        _ScreenTex ("texture", 2D) = "black" {}
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
            uniform sampler2D _ScreenTex;
            uniform float4 _ScreenTex_ST;

            // 输入结构
            struct VertexInput {
                float4 vertex: POSITION;
                float2 uv: TEXCOORD0;
            };
            
            // 输出结构
            struct VertexOutput {
                float4 pos: SV_POSITION;
                float uv: TEXCOORD0;
                float screenUV: TEXCOORD1;
            };

            // 输入结果
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    float3 posVS = UnityObjectToViewPos(v.vertex).xyz;
                    float originDist = UnityObjectToViewPos(float3(0.0, 0.0, 0.0)).z;
                    o.screenUV = posVS.xy / posVS.z;
                    o.screenUV *= originDist;
                    o.screenUV = o.screenUV * _ScreenTex_ST.xy - frac(_Time.x * _ScreenTex_ST.zw);
                return o; 
            }
            // 输出结果
            half4 frag(VertexOutput i): COLOR {
                half4 var_MainTex = tex2D(_MainTex, i.uv);
                half var_ScreenTex = tex2D(_ScreenTex, i.screenUV).r;
                half3 finalRGB = var_MainTex.rgb;
                half opacity = var_MainTex.a * _Opacity * var_ScreenTex;
                return half4(finalRGB * opacity, opacity);
            }

            ENDCG
        }
    }
    FallBack "Diffuse"
}
