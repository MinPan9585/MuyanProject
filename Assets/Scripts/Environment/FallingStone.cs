using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    public Transform wayPoint;
    public float moveSpeed = 10000f;

    private Vector3 initPoint;
    // Start is called before the first frame update
    void Start()
    {
        this.initPoint = this.transform.position;
        Debug.Log("initPoint");
        Debug.Log(this.initPoint);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("!!!!");
        Debug.Log(this.initPoint);
        this.transform.position = this.transform.position.y > wayPoint.transform.position.y ? new Vector3(initPoint.x, initPoint.y -= moveSpeed * Time.deltaTime, initPoint.z) : this.initPoint; 
    }
}
