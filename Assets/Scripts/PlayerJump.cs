using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpPower;
    public float CenterToBottom;
    Rigidbody2D rigid;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        CenterToBottom = GetRaycastDistance();
        Debug.Log(CenterToBottom);
    }

    public void Jump()
    {
        rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
    }    

    //이하 이식해야할 부분 (+9번째 줄)

    public LayerMask groundLayer;
    private bool isGrounded;

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
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, CenterToBottom, groundLayer);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){ //랜덤하게 바뀌는 키로 어떻게 할당하는지 몰라 일단 할당해놨습니다
            Jump();
            
        }
    }

    
}
