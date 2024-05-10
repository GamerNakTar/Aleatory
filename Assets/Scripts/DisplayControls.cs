using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayControls : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI controlText;
    public NewBehaviourScript playerController;
<<<<<<< HEAD
=======
    public Vector3 offset = new Vector3(0, 2, 0);
>>>>>>> 913c1ca39d32579df28758c7bddde920f817ed67
    public float displayDuration; //duration of displaying the keyboard changed

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
        controlText.fontSize = Mathf.RoundToInt(7 * screenRatioHeight); // 기준 폰트 크기는 24로 가정


        // 스크린 좌표를 이용해 텍스트 위치 조정
        controlText.transform.position = new Vector3(player.position.x, player.position.y + 3 * screenRatioHeight, 0);
    }

    void Update() // Update is called once per frame
    {
<<<<<<< HEAD
        float screenRatioWidth = Screen.width / 1920f; // 1920은 기준 너비
        float screenRatioHeight = Screen.height / 1080f; // 1080은 기준 높이
        controlText.rectTransform.sizeDelta = new Vector2(200 * screenRatioWidth, 100 * screenRatioHeight);

        controlText.transform.position = new Vector3(player.position.x, player.position.y + 2, 0);
=======
        controlText.transform.position = Camera.main.WorldToScreenPoint(player.position + offset);
>>>>>>> 913c1ca39d32579df28758c7bddde920f817ed67
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
