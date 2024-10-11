using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeCardLogic : MonoBehaviour
{
    public SceneInfo SceneInfo;

    private void Start()
    {
        if (SceneInfo.PrevScene == SceneManager.GetActiveScene().name)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
