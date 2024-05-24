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
        // 화면 크기에 맞춰 텍스트 오브젝트의 크기 조절
        float screenRatioWidth = Screen.width / 1920f; // 1920은 기준 너비
        float screenRatioHeight = Screen.height / 1080f; // 1080은 기준 높이
        controlText.rectTransform.sizeDelta = new Vector2(200 * screenRatioWidth, 100 * screenRatioHeight);

        // 폰트 크기 조절
        controlText.fontSize = Mathf.RoundToInt(10 * screenRatioHeight); // 기준 폰트 크기는 24로 가정


        // 스크린 좌표를 이용해 텍스트 위치 조정
        controlText.rectTransform.sizeDelta = new Vector2(100 * screenRatioWidth, 50 * screenRatioHeight);
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
