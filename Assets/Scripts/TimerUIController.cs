using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerUIController : MonoBehaviour
{

    // private float xScreenHalfSize, yScreenHalfSize;
    // private float camx, camy;
    // private Vector3 targetPos;
    [SerializeField] private GameObject timerBaranchor;
    [SerializeField] private GameObject timerBar;
    // [SerializeField] private GameObject timerUI;
    [SerializeField] private GameObject player;
    private NewBehaviourScript controllerScript;
    private Vector3 newScale;
    private SpriteRenderer spriteRenderer;
    private float hue, sat, bri;

    void Start()
    {
        // yScreenHalfSize = Camera.main.orthographicSize;
        // xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;
        controllerScript = player.GetComponent<NewBehaviourScript>();
        // timerUI.transform.position = transform.position + new Vector3(xScreenHalfSize*-1f + 1f, yScreenHalfSize-0.7f, 0f);
        spriteRenderer = timerBar.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }


    void Update()
    {
        newScale = new Vector3(controllerScript.currTime/controllerScript.timer, 1f, 1f);
        timerBaranchor.gameObject.transform.localScale = newScale;

        Color.RGBToHSV(spriteRenderer.color, out hue, out sat, out bri);

        if (controllerScript.timer == controllerScript.drunkTimer) {
            hue += Time.deltaTime;
            spriteRenderer.color = Color.HSVToRGB(hue, sat, bri);
        }
        else {
            spriteRenderer.color = Color.red;
        }
        
        
    }
}
