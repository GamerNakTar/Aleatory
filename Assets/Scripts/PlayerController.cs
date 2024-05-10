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

    public DisplayControls displayControls;

    [SerializeField]
    public float currTime;
    // 취기 게이지 수치
    public float alcoholGauge;
    public KeyCode Jump, MoveLeft, MoveRight, Pause;
    public PlayerJump jumpHandler;

    [SerializeField] public float timer;
    // 피버 게이지 총량
    [SerializeField] public float alcoholCapacity;
    // 피버 시 타이머
    [SerializeField] public float drunkTimer;
    // 피버 지속 시간
    [SerializeField] private float drunkLength;
    public bool isDrunk = false;
    private bool isDrunking = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Jump = Keys[0];
        MoveLeft = Keys[1];
        MoveRight = Keys[2];
        Pause = Keys[3];
        maxSpeed = 7f;
        acceleration = 0.8f;
        alcoholCapacity = 60f;
        alcoholGauge = 0f;
        currTime = 0f;
    }

    void Start()
    {
        displayControls.UpdateKeyDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if(isDrunk && !isDrunking)
        {
            StartCoroutine("DrunkCoroutine");
        }

        if(isDrunk)
        {
            alcoholGauge -= Time.deltaTime * (alcoholCapacity / drunkLength);
        }
        else
        {
            alcoholGauge += Time.deltaTime;
        }

        // 취기 게이지가 꽉 찼을 때
        if(alcoholGauge > alcoholCapacity)
        {
            isDrunk = true;
        }

        // Key Randomize
        if(currTime > timer)
        {
            Jump = Keys[getRandIdx()];
            MoveLeft = Keys[getRandIdx()];
            MoveRight = Keys[getRandIdx()];
            Pause = Keys[getRandIdx()];
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
            MoveBehaviour.Move(true, rigid, maxSpeed, acceleration);
        }
        if (Input.GetKey(MoveRight))
        {
            MoveBehaviour.Move(false, rigid, maxSpeed, acceleration);
        }
    }

    private int getRandIdx(){
        System.Random rand = new System.Random();
        return rand.Next(Keys.Count);
    }

    IEnumerator DrunkCoroutine() {
        isDrunking = true;
        float timerTemp = timer;
        timer = drunkTimer;
            yield return new WaitForSeconds(drunkLength);
        timer = timerTemp;
        alcoholGauge = 0;
        isDrunk = false;
        isDrunking = false;
    }
}

