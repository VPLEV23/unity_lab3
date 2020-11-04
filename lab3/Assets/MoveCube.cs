using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float jumpHeight = 7f;
    public bool isGrounded;
    public float NumberJumps = 0f;
    public float MaxJumps = 2;
    private Rigidbody rb;
    public float speed = .1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionStay(){
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f,zDirection);

        transform.position += moveDirection *speed;
         if (NumberJumps > MaxJumps - 1)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpHeight);
                NumberJumps += 1;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
        NumberJumps = 0;
    }
    void OnCollisionExit(Collision other)
        {
            
    }
}

