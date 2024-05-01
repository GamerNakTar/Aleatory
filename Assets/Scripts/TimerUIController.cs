using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerUIController : MonoBehaviour
{

    // private float xScreenHalfSize, yScreenHalfSize;
    // private float camx, camy;
    // private Vector3 targetPos;
    [SerializeField] private GameObject timerBar;
    // [SerializeField] private GameObject timerUI;
    [SerializeField] private GameObject player;
    private NewBehaviourScript controllerScript;
    private Vector3 newScale;


    void Start()
    {
        // yScreenHalfSize = Camera.main.orthographicSize;
        // xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;
        controllerScript = player.GetComponent<NewBehaviourScript>();
        // timerUI.transform.position = transform.position + new Vector3(xScreenHalfSize*-1f + 1f, yScreenHalfSize-0.7f, 0f);
    }


    void Update()
    {
        newScale = new Vector3(controllerScript.currTime/controllerScript.timer, 1f, 1f);
        timerBar.gameObject.transform.localScale = newScale;
    }
}
