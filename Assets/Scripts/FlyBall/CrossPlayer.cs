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
            // ��С�򷢳�����
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Physics.Raycast(transform.position, moveDirection, 2)
            // RaycastHit hit;
            Vector3 relectionAngle = Vector3.Reflect(moveDirection, collision.contacts[0].normal);
            moveDirection = relectionAngle.normalized;
        }
    }

    private void GetForkPositon()
    {
        // get fork position when input space
        // if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetMouseButtonDown(0))
        {
            // ����Ӧ�ô������ȡ�㻹�Ǵ� player ȡ���أ�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ����һ�� LayweMask ���� clickIgnore ��
            int layerMask = ~(1 << LayerMask.NameToLayer("clickIgnore"));

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (clickedObject.CompareTag("Fork"))
                {
                    Vector3 clickedObjectPosition = hit.point;
                    // Debug.Log("���������: " + clickedObjectPosition);

                    moveDirection = (clickedObjectPosition - transform.position).normalized;
                    // return clickedObjectPosition;
                }
            }
        }
    }
}
