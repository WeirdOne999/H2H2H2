using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public GameObject Menu;
    public GameObject LoseScreen;
    public GameObject WinScreen;

    public UnityEvent WinStuff;

    private void Awake()
    {
        Menu.SetActive(false);
        LoseScreen.SetActive(false);
        WinScreen.SetActive(false);
    }

    public void ToggleMenu()
    {
        Menu.SetActive(!Menu.activeInHierarchy);

        if (Menu.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void HideMenu()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowLose()
    {
        Time.timeScale = 0;
        LoseScreen.SetActive(true);
    }

    public void ShowWin()
    {
        Time.timeScale = 0;
        WinScreen.SetActive(true);
    }

    public void AfterWin()
    {
        Time.timeScale = 1;
        WinScreen.SetActive(false);
        WinStuff.Invoke();
    }
}
