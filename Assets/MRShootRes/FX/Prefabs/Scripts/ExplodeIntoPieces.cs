using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeIntoPieces : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float radius;

    void Start(){
        ShieldBreakExplode();
    }

    public void ShieldBreakExplode(){
        foreach (Transform t in transform){
            var rb = t.GetComponent<Rigidbody>();

            if(rb != null){
                rb.AddExplosionForce(Random.Range(minForce,maxForce),transform.position,radius);
            }
        }
    }
}
