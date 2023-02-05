using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStones1 : MonoBehaviour
{
    public Rigidbody[] stones;
    private float fallingTimer = 1f;
    private int index = 0;
    public bool isFinished = false;

    private void Start()
    {
        stones = transform.GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        fallingTimer -= Time.deltaTime;
        if(fallingTimer<= 0)
        {
            if(index <= 3)
            {
                stones[index].isKinematic = false;
                index++;
                fallingTimer = Random.Range(0.3f, 0.9f);
            }
        }
        if(stones[3] == null)
        {
            isFinished = true;
        }
    }
}
