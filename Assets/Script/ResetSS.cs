using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSS : MonoBehaviour
{
    public StorySave SS;

    public void RESETSS()
    {
        SS.OnStory = false;
        SS.StoryCharacter = 0;
    }
}
