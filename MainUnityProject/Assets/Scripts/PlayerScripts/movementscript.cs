using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementscript : MonoBehaviour
{
    
    public float speed = 6, jumpforce = 270, jumpdelay = 0.1f;
    bool jumping;
    Rigidbody rb;
    
    [SerializeField]Vector3 movement;
    [SerializeField]Vector3 linearVelocity;
    
    float movex, movez;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //movement input
        movez = Input.GetAxisRaw("Vertical");
        movex = Input.GetAxisRaw("Horizontal");
        
        movement = transform.forward * movez + transform.right * movex;
        movement *= Time.deltaTime;

        rb.linearVelocity = movement * (speed * 100) + Vector3.up * rb.linearVelocity.y;
        
        
        
        
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
