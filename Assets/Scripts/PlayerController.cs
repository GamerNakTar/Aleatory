using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<KeyCode> Keys = new List<KeyCode>() {
    KeyCode.Space, KeyCode.A, KeyCode.D, KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P
    , KeyCode.S, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B
    , KeyCode.N, KeyCode.M, KeyCode.Backspace, KeyCode.CapsLock, KeyCode.Tab, KeyCode.BackQuote, KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2
    , KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Minus
    , KeyCode.Equals, KeyCode.LeftBracket, KeyCode.RightBracket, KeyCode.Backslash, KeyCode.Semicolon, KeyCode.Quote, KeyCode.LeftShift
    , KeyCode.RightShift, KeyCode.Comma, KeyCode.Period, KeyCode.Slash, KeyCode.LeftControl, KeyCode.LeftAlt, KeyCode.RightAlt, KeyCode.RightControl
    , KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Insert, KeyCode.Home, KeyCode.PageUp, KeyCode.PageDown
    , KeyCode.End, KeyCode.Delete
    };

    void Start()
    {
        Jump = Keys[0];
        MoveLeft = Keys[1];
        MoveRight = Keys[2];
    }

    [SerializeField]
    private float moveSpeed = 5f;
    private float currTime;
    KeyCode Jump, MoveLeft, MoveRight;
    public PlayerJump jumpHandler;

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if(currTime > 100)
        {
            List<int> randIdx = getRandIdx();
            Jump = Keys[randIdx[0]];
            MoveLeft = Keys[randIdx[1]];
            MoveRight = Keys[randIdx[2]];
            Debug.Log(Keys[randIdx[0]]);
            Debug.Log(Keys[randIdx[1]]);
            Debug.Log(Keys[randIdx[2]]);
            currTime = 0;
        }

        // Jump
        if (Input.GetKey(Jump)) // Use GetKeyDown for single jump press
        {
            jumpHandler.Jump(1);
        }
        // Movement
        if (Input.GetKey(MoveLeft))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(MoveRight))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    private List<int> getRandIdx(){
        System.Random rand = new System.Random();
        int idx1 = rand.Next(Keys.Count), idx2 = rand.Next(Keys.Count), idx3 = rand.Next(Keys.Count);
        List<int> randIdx = new List<int>() {idx1, idx2, idx3};
        return randIdx;
    }
}

