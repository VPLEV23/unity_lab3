using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class playerJump : MonoBehaviour {
    [SerializeField] float playerUpwardForce;
    private Rigidbody rb;
    private bool isGrounded;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void Updates()
    {
        Jump();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        } 
    }
    void Jump()
    {
       if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * playerUpwardForce , ForceMode.VelocityChange);
            isGrounded = false;
        }
    }
    
}