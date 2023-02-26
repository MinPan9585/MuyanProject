using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stone"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            //restart game
            //life --
        }
    }
}