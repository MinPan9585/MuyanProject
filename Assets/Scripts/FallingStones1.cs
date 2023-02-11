using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStones1 : MonoBehaviour
{
    public Rigidbody[] stones;
    public bool isFinished = false;

    private float fallingTimer = 1f;
    private int index = 0;
    private int randerIndex;

    private void Start()
    {
        stones = transform.GetComponentsInChildren<Rigidbody>();
        randerIndex = Random.Range(0, stones.Length - 1);
    }

    private void Update()
    {
        fallingTimer -= Time.deltaTime;
        if(fallingTimer <= 0 && index < stones.Length)
        {
            stones[randerIndex % stones.Length].isKinematic = false;
            index++;
            randerIndex++;
            fallingTimer = Random.Range(0.3f, 0.9f);
        }
        if(stones[(randerIndex + stones.Length - 1) % stones.Length] == null)
        {
            isFinished = true;
            randerIndex = Random.Range(0, stones.Length - 1);
        }
    }
}
