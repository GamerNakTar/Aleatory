using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    static public float playTime = 0f;
    void Update()
    {
        playTime += Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
