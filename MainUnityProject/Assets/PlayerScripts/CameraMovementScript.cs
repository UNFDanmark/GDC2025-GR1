using System;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Camera.main.gameObject.transform.Rotate(-Input.GetAxis("Mouse Y"),0,0);
        transform.Rotate(0,Input.GetAxis("Mouse X"),0);
    }
}
