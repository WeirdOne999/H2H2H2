using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEndScript : MonoBehaviour
{
    public UnityEvent WinEvent;
    public UnityEvent LoseEvent;
    public GameObject player;
    public GameObject enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       //End game 
       if (collision.CompareTag("Player"))
        {
            LoseEvent.Invoke();
        }
        if (collision.CompareTag("NPC"))
        {
            WinEvent.Invoke();
        }
    }

    public void DisableBoth()
    {
        player.SetActive(false);
        enemy.SetActive(false);
    }
}
