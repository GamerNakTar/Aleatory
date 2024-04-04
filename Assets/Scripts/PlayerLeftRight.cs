using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftRight : MonoBehaviour
{

    public static void LeftRight(bool isLeft, Rigidbody2D rigid, float maxSpeed, float accelaration) {
        float h;
        if (isLeft)
        {
            h = -1;
        }
        else
        {
            h = 1;
        }
        rigid.AddForce(Vector2.right * h * accelaration, ForceMode2D.Force);
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

