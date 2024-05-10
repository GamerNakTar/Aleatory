using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum ButtonType
{
    New,
    Option,
    Sound,
    Back,
    Quit,
    Main
}

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ButtonType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case ButtonType.New:
                SceneManager.LoadScene("GameScene");
                break;
            case ButtonType.Quit:
                ExitGame();
                break;
            case ButtonType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                break;
            case ButtonType.Sound:
                Debug.Log("Sound");
                break;
            case ButtonType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                break;
            case ButtonType.Main:
                SceneManager.LoadScene("StartScene");
                break;
        }
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.1f;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
