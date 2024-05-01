using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // List of key codes that can be used for left, right, and jump.
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

    Rigidbody2D rigid;

    [SerializeField]
    public float maxSpeed;
    public float acceleration;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Jump = Keys[0];
        MoveLeft = Keys[1];
        MoveRight = Keys[2];
        // maxSpeed = 1f;
        // acceleration = 1f;
    }

    public DisplayControls displayControls;

    [SerializeField]
    private float currTime;
    public KeyCode Jump, MoveLeft, MoveRight;
    public PlayerJump jumpHandler;

    [SerializeField] public float timer;
    [SerializeField] private float drunkTimer;
    [SerializeField] private float drunkLength;
    private bool isDrunk = false;

    void Start()
    {
        displayControls.UpdateKeyDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if(isDrunk)
        {
            StartCoroutine("DrunkTimeController");
        }

        // Key Randomize
        if(currTime > timer)
        {
            Jump = Keys[getRandIdx()];
            MoveLeft = Keys[getRandIdx()];
            MoveRight = Keys[getRandIdx()];
            currTime = 0;

            displayControls.UpdateKeyDisplay();
        }

        // Jump
        if (Input.GetKey(Jump)) // Use GetKeyDown for single jump press
        {
            jumpHandler.Jump();
        }
        // Movement
        if (Input.GetKey(MoveLeft))
        {
            PlayerLeftRight.LeftRight(true, rigid, maxSpeed, acceleration);
        }
        if (Input.GetKey(MoveRight))
        {
            PlayerLeftRight.LeftRight(false, rigid, maxSpeed, acceleration);
        }
    }

    private int getRandIdx(){
        System.Random rand = new System.Random();
        return rand.Next(Keys.Count);
    }

    IEnumerator DrunkTimeController() {
        isDrunk = false;
        float timerTemp = timer;
        timer = drunkTimer;
            yield return new WaitForSeconds(drunkLength);
        timer = timerTemp;
    }
}

