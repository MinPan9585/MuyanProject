using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTest : MonoBehaviour
{
    public Transform player; // Player transform
    public float rotationSpeed = 2.0f; // Speed of camera rotation

    private float mouseX;
    private float mouseY;
    private float xRotation = 0.0f;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 0, 0);
        // Set the initial position of the camera
        transform.position = player.position + offset;
    }

    void Update()
    {
        // Get the mouse input
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        // Clamp the vertical rotation to prevent flipping
        mouseY = Mathf.Clamp(mouseY, -90.0f, 90.0f);

        // Rotate the camera around the player
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);
        transform.position = player.position - transform.rotation * offset;

        // Make sure the player is always at the bottom center of the screen
        Vector3 targetPosition = player.position + offset;
        targetPosition.y = player.position.y;
        transform.LookAt(targetPosition);
    }
}
