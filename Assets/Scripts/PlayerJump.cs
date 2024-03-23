using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // 이부분도 이식 필요
    [SerializeField] private float jumpPower;
    Vector2 vecGravity;
    //
    private float CenterToBottom;
    Rigidbody2D rigid;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    public void Jump(float jumpMult)
    {
        //rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        rigid.velocity = new Vector2(rigid.velocity.x, jumpPower * jumpMult);
    }    

    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] float jumpTime;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private float terminalSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float jumpMultiplier;
    
    private bool isGrounded;
    //private bool isJumping;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;
    //private float jumpCounter;

    void Update() { 
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.52f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        
        

        if (rigid.velocity.y < 0f) {
            //isJumping = false;
            rigid.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
            if (rigid.velocity.y < -15f) {
                rigid.velocity = new Vector2(rigid.velocity.x, -15f);
            }
        }

        //if (rigid.velocity.y > 0) {
            //rigid.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        //}
        
        if(isGrounded) {
            coyoteTimeCounter = coyoteTime;
        } else  {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpBufferCounter = jumpBufferTime;
        } else {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (rigid.velocity.y>0) {
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * 0.6f);
            }
        }

        if(coyoteTimeCounter > 0f && jumpBufferCounter > 0f && isGrounded){ //랜덤하게 바뀌는 키로 어떻게 할당하는지 몰라 일단 할당해놨습니다
            Jump(jumpMultiplier);
            //isJumping = true;
            jumpBufferCounter = 0f;
        }
    }    
}
