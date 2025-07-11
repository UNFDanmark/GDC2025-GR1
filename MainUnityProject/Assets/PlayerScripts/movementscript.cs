using System.Collections;
using UnityEngine;

public class movementscript : MonoBehaviour
{

    public float speed = 6, jumpforce = 270, jumpdelay = 0.1f;
    bool jumping;
    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        movement *= Time.deltaTime;
        
        
        transform.position += movement * speed;
        
        //jump
        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            if (Physics.Raycast(transform.position - new Vector3(0, 1, 0), Vector3.down, .1f))
            {
                rb.AddForce(Vector3.up * jumpforce);
                StartCoroutine(jumpDelay());
            }
        }
    }

    IEnumerator jumpDelay()
    {
        jumping = true;
        yield return new WaitForSeconds(jumpdelay);
        jumping = false;
        StopAllCoroutines();
    }
    
}
