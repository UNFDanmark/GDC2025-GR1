using System;
using UnityEngine;

    

public class CameraMovementScript : MonoBehaviour
{
    GameObject camera;

    
    [SerializeField]float minXAngle = 70, maxXAngle = 270;

    
    void Start()
    {

        camera = UnityEngine.Camera.main.gameObject;
        
        Cursor.lockState = CursorLockMode.Locked;
     
    }

    void Update()
    {
             

        transform.Rotate(0,Input.GetAxis("Mouse X"),0);
        
        
        if (((camera.transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") < minXAngle && camera.transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") >= -5) || (camera.transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") <= 365 && camera.transform.rotation.eulerAngles.x - Input.GetAxis("Mouse Y") > maxXAngle)))
        {
            
            camera.transform.Rotate(-Input.GetAxis("Mouse Y"),0,0);
        }
        
    }
    
}
