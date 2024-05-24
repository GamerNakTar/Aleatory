using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagController : MonoBehaviour, ICollidable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }

    public void OnCollision(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Player has touched the flag!");
            SceneManager.LoadScene("ClearScene");
        }
    }
}
