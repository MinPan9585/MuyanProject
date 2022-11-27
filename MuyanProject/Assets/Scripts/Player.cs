using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;

    void Start()
    {

    }

    void Update()
    {
        transform.position += new Vector3(0f, 0f, Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        MoveForward();
    }

    void MoveForward()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
