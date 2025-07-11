using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    
    void Update()
    {
        Camera.main.gameObject.transform.Rotate(-Input.GetAxis("Mouse Y"),0,0);
        transform.Rotate(0,Input.GetAxis("Mouse X"),0);
    }
}
