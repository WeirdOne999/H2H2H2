using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScene : MonoBehaviour
{
    public StorySave SS;
    public NPCManager NPCM;
    public UnityEvent UE;

    void Awake()
    {
        if (SS.OnStory)
        {
            UE.Invoke();
            if (SS.StoryCharacter >= 1)
            {
                NPCM.CustomersBefore1 = 0;
            }
            if (SS.StoryCharacter > 2)
            {
                NPCM.CustomersBefore2 = 0;
            }
            if (SS.StoryCharacter > 3)
            {
                NPCM.CustomersBefore3 = 0;
            }
        }
    }

    public void SetCharaccter(int charact)
    {
        SS.OnStory = true;
        SS.StoryCharacter = charact;
    }
}
