using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    Vector2 moveDir;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //7-16-17-21
    void Update()
    {
        moveDir.y = Input.GetAxis("Vertical");
        moveDir.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDir.x*speed, rb.velocity.y, moveDir.y*speed);
    }
}
