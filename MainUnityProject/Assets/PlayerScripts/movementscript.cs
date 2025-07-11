using UnityEngine;

public class movementscript : MonoBehaviour
{

    public float speed = 6;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        movement *= Time.deltaTime;
        
        
        transform.position += movement * speed;
    }
}
