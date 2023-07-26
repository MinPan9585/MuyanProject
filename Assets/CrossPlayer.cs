using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPlayer : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody rb;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(moveDirection);
        rb.velocity = moveDirection * playerSpeed * Time.deltaTime;
        //transform.Translate(moveDirection * playerSpeed * Time.deltaTime, Space.World);
        GetForkPositon();
    }

    // void FixedUpdate()
    // {
        // player.MovePosition(player.position + moveDirection * playerSpeed * Time.fixedDeltaTime);
    // }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Wall"))
        {
            Vector3 relectionAngle = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
            moveDirection = relectionAngle.normalized;
        }
    }

    private void GetForkPositon()
    {
        // 鼠标点击时获取选中的 fork 物体坐标
        if (Input.GetMouseButtonDown(0))
        {
            // 这里应该从摄像机取点还是从 player 取点呢？
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag("Fork"))
                {
                    Vector3 clickedObjectPosition = hit.point;
                    // Debug.Log("点击的坐标: " + clickedObjectPosition);

                    moveDirection = (clickedObjectPosition - transform.position).normalized;
                    // return clickedObjectPosition;
                }
            }
        }
    }
}
