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

    void Start()
    {
<<<<<<< HEAD
        // 화면 크기에 따라 Text UI의 크기를 조정
        float screenRatioWidth = Screen.width / 1920f; // 1920은 기준 너비
        float screenRatioHeight = Screen.height / 1080f; // 1080은 기준 높이
        controlText.rectTransform.sizeDelta = new Vector2(100 * screenRatioWidth, 50 * screenRatioHeight);

        Vector3 topRightCorner = new Vector3(Screen.width, Screen.height, 0);
        Vector3 topRightWorld = Camera.main.ScreenToWorldPoint(topRightCorner);
        transform.position = new Vector3(topRightWorld.x - 5 * screenRatioWidth , topRightWorld.y - 3 * screenRatioHeight, 0);
=======

>>>>>>> 913c1ca39d32579df28758c7bddde920f817ed67
    }

    // Update is called once per frame
    void Update()
    {
        Jump = playerController.Jump;
        MoveLeft = playerController.MoveLeft;
        MoveRight = playerController.MoveRight;

        controlText.text = "Jump: " + Jump.ToString() + "\nLeft: " + MoveLeft.ToString() + "\nRight: " + MoveRight.ToString();
    }
}
