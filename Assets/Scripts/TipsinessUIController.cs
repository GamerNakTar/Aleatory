using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TipsinessUIController : MonoBehaviour
{
    [SerializeField] private GameObject timerBar;
    [SerializeField] private GameObject player;
    private NewBehaviourScript controllerScript;
    private Vector3 newScale;


    void Start()
    {
        controllerScript = player.GetComponent<NewBehaviourScript>();
    }


    void Update()
    {
        newScale = new Vector3(controllerScript.alcoholGauge/controllerScript.alcoholCapacity, 1f, 1f);
        timerBar.gameObject.transform.localScale = newScale;
    }
}
