using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayControls_fixed : MonoBehaviour
{
    public TextMeshProUGUI controlText;
    public NewBehaviourScript playerController;

    private KeyCode Jump;
    private KeyCode MoveLeft;
    private KeyCode MoveRight;
    private KeyCode Pause;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Jump = playerController.Jump;
        MoveLeft = playerController.MoveLeft;
        MoveRight = playerController.MoveRight;
        Pause = playerController.Pause;

        controlText.text = "Jump: " + Jump.ToString() + "\nLeft: " + MoveLeft.ToString() + "\nRight: " + MoveRight.ToString()+"\nPause: "+Pause.ToString();
    }
}
