using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private float terminalSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float jumpMultiplier;
    private bool jumpKeyPressed;
    private bool isGrounded;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    Vector2 vecGravity;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        jumpKeyPressed = false;
    }

    public void Jump()
    {
        jumpKeyPressed = true;
    }

    void Update() {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.52f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (rigid.velocity.y < 0f) {
            rigid.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
            if (rigid.velocity.y < -15f) {
                rigid.velocity = new Vector2(rigid.velocity.x, -15f);
            }
            if (!isGrounded) {
                jumpKeyPressed = false;
            }
        }

        if(isGrounded) {
            coyoteTimeCounter = coyoteTime;
        } else  {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (jumpKeyPressed) {
            jumpBufferCounter = jumpBufferTime;
        } else {
            jumpBufferCounter -= Time.deltaTime;
            if (rigid.velocity.y>0) {
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 0.6f);
            }
        }

        if(coyoteTimeCounter > 0f && jumpBufferCounter > 0f && isGrounded){
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower * jumpMultiplier);
            jumpBufferCounter = 0f;
        }
    }
}
