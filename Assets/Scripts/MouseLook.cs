using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] Transform playerMain = null;
    [System.NonSerialized] public float vertRot = 0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Horizontal Mouse Controls
        playerMain.transform.Rotate(Vector3.up * mouseX);

        // Vertical Mouse Controls
        vertRot -= mouseY;
        vertRot = Mathf.Clamp(vertRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(vertRot, 0, 0);
    }
}
