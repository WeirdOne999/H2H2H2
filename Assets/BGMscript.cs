using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMscript : MonoBehaviour
{
    private static GameObject instance = null;
    private void Awake()
    {
        if (instance == null){
            instance = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
