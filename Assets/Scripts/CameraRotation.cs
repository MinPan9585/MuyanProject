using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private Vector3 rotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float mouseZ = Input.GetAxis("Mouse ScrollWheel") * mouseSensitivity * Time.deltaTime;

        rotation.x -= mouseY;
        rotation.y -= mouseX;
        rotation.z -= mouseZ;

        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);
        rotation.z = Mathf.Clamp(rotation.z, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotation.x, -rotation.y, rotation.z);
        // playerBody.Rotate(Vector3.up * mouseX);
    }
}

