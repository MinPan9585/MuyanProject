using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGroup1 : MonoBehaviour
{
    public GameObject fallingStones1;
    private void Update()
    {
        if(transform.GetChild(0).GetComponent<FallingStones1>().isFinished == true)
        {
            Destroy(transform.GetChild(0).gameObject);
            Instantiate(fallingStones1, transform);
        }
    }
}
