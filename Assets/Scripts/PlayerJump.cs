using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float JumpPower;
    private float CenterToBottom;
    Rigidbody2D rigid;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        CenterToBottom = GetRaycastDistance();
    }

    public void Jump()
    {
        rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }    

    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private float jumpBufferCounter;
    [SerializeField] private float terminalSpeed;
    float GetRaycastDistance()
    {
        Collider2D playerCollider = GetComponent<Collider2D>();
        if (playerCollider != null) {
            float distanceToBottom = playerCollider.bounds.extents.y;
            return distanceToBottom;
            
        }
        return 1f;
    }

    void Update() { 
        
        if (rigid.velocity.y < -15f) {
            rigid.velocity = new Vector2(rigid.velocity.x, -15f);
        }
        
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, CenterToBottom, groundLayer);
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
        
        if(coyoteTimeCounter > 0f && jumpBufferCounter > 0f && isGrounded){ //랜덤하게 바뀌는 키로 어떻게 할당하는지 몰라 일단 할당해놨습니다
            Jump();
            jumpBufferCounter = 0f;
        }
    }    
}
