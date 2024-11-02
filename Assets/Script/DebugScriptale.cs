using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugScriptale : MonoBehaviour
{
    public StorySave SS;

    public SceneInfo SI;

    public TextMeshProUGUI text;

    public void Update()
    {
        text.text = SS.OnStory.ToString() + " " + SS.StoryCharacter.ToString() + " " + SI.PrevScene;
    }

}
