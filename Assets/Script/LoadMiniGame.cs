using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadMiniGame : MonoBehaviour
{
    public UnityEvent ue;
    public void LoadScene(string name)
    {
        ue.Invoke();
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
