using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    private float playTime;
    private int playHour = 0;
    private int playMin = 0;
    private int playSec = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        ShowScore();
    }
    public void ShowScore()
    {
        playTime = Goal.playTime;
        playHour = (int)playTime / 3600;
        playMin = ((int)playTime - (playHour * 60)) / 60;
        playSec = (int)playTime - (playHour * 3600) - (playMin * 60);
        scoreText.text = playHour.ToString() + "h " + playMin.ToString() + "m " + playSec.ToString() + "s";
    }
}
