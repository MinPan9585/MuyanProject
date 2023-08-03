using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class effectWall : MonoBehaviour
{
    public GameObject wall;
    private VisualEffect wallVFX;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var ripples = Instantiate(wall, transform) as GameObject;
            wallVFX = ripples.GetComponent<VisualEffect>();
            wallVFX.SetVector3("WallCenter", collision.contacts[0].point);

            Destroy(ripples, 2);
        }
    }
}
