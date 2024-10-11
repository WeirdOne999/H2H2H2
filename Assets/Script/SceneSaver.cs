using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaver : MonoBehaviour
{
    public SceneInfo SceneInfo;

    public void SaveSceneInfo()
    {
        SceneInfo.PrevScene = SceneManager.GetActiveScene().name;
    }
}
