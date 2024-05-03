using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    public static void Move(bool isLeft, Rigidbody2D rigid, float maxSpeed, float acceleration) {
        float dir;
        if (isLeft)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        rigid.AddForce(Vector2.right * dir * acceleration, ForceMode2D.Force);
        if(rigid.velocity.x > maxSpeed) // right max speed
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed*(-1)) // left max speed
        {
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        }
    }
}

