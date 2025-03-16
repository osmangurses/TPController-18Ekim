using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform cameraTransform;
    Vector2 moveDir;
    Rigidbody rb;
    CharacterState characterState;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        characterState = GetComponent<CharacterState>();
    }
    void Update()
    {
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.x = Input.GetAxisRaw("Horizontal");
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
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 finalMoveDirection = (forward * moveDir.y + right * moveDir.x).normalized * speed;

        if (finalMoveDirection.magnitude>0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(finalMoveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,Time.deltaTime*10);

        }


        State currentMoveState = (finalMoveDirection == Vector3.zero) ? State.Idle : State.Walk;
        if (characterState.currentState != currentMoveState)
        {characterState.ChangeState(currentMoveState); }
        rb.velocity = finalMoveDirection + Vector3.up * rb.velocity.y;
    }
}