using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayControls : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI controlText;
    public NewBehaviourScript playerController;
    public Vector3 offset = new Vector3(0, 2, 0);
    public float displayDuration; //duration of displaying the keyboard changed

    private KeyCode Jump;
    private KeyCode MoveLeft;
    private KeyCode MoveRight;


    void Update() // Update is called once per frame
    {
        controlText.transform.position = Camera.main.WorldToScreenPoint(player.position + offset);
    }

    public void UpdateKeyDisplay()
    {
        Jump = playerController.Jump;
        MoveLeft = playerController.MoveLeft;
        MoveRight = playerController.MoveRight;

        controlText.text = "Jump: "+Jump.ToString()+"\nLeft: "+MoveLeft.ToString()+"\nRight: "+MoveRight.ToString();

        StopCoroutine("HideTextAfterDelay");
        StartCoroutine("HideTextAfterDelay");
    }

    IEnumerator HideTextAfterDelay()
    {
        float gapTime = 1.0f;
        float elapsedTime = 0;
        bool isVisible = true;

        while (elapsedTime < displayDuration)
        {
            yield return new WaitForSeconds(gapTime);
            isVisible = !isVisible;
            controlText.text = isVisible ? "Jump: "+Jump.ToString()+"\nLeft: "+MoveLeft.ToString()+"\nRight: "+MoveRight.ToString() : "";

            elapsedTime += gapTime-0.1f;
        }

        controlText.text = "";
    }

}
