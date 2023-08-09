using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance = 4.0f; // Distance from the player
    public float xSpeed = 120.0f; // Camera rotation speed
    public float ySpeed = 120.0f;

    private float x = 0.0f;
    private float y = 0.0f;
    private Vector3 cameraPositionOffset;
    private Vector3 lookAtOffset;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // 设置摄像机的初始位置
        // 获取 player 的初始朝向
        cameraPositionOffset = -1f * distance * player.transform.forward;
        lookAtOffset = 1.6f * player.transform.up;
        transform.position = cameraPositionOffset + player.position;
        transform.LookAt(lookAtOffset + player.position);
    }

    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        y = Mathf.Clamp(y, -89, 89);

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * cameraPositionOffset + player.position;

        transform.rotation = rotation;
        transform.position = position;

        transform.LookAt(rotation * lookAtOffset + player.position);
    }
}
