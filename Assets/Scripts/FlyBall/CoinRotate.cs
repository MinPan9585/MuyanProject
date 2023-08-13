using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    // public float rotationSpeedX = 5f;
    // public float rotationSpeedY = 10f;
    public float rotationSpeedZ = 15f;
    public float rotationTransZ = 1f;

    void Update()
    {
        // transform.Rotate(Vector3.right * rotationSpeedX * Time.deltaTime, Space.Self);
        // transform.Rotate(Vector3.up * rotationSpeedY * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.forward * rotationSpeedZ * rotationTransZ * Time.deltaTime, Space.Self);
    }
}
