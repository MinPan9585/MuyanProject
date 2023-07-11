using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPlayer : MonoBehaviour
{
    private float playerSpeed = 7f;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        // player = GetComponent<Rigidbody>();
        moveDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * playerSpeed * Time.deltaTime, Space.World);
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
        // �����ʱ��ȡѡ�е� fork ��������
        if (Input.GetMouseButtonDown(0))
        {
            // ����Ӧ�ô������ȡ�㻹�Ǵ� player ȡ���أ�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag("Fork"))
                {
                    Vector3 clickedObjectPosition = hit.point;
                    Debug.Log("���������: " + clickedObjectPosition);

                    moveDirection = (clickedObjectPosition - transform.position);
                    // return clickedObjectPosition;
                }
            }
        }
    }
}
