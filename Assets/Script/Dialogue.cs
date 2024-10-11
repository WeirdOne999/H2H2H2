using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{

    //[TextArea(3, 10)]
    
    public DialogueData[] data;
   

}

[Serializable]
public struct DialogueData
{
    public string text;
    public UnityEvent unityEvent;
    public GameObject characterSprite;
    public GameObject DialogueSprite;

    public DialogueData(string text, UnityEvent _unityevent, GameObject characterSprite, GameObject DialogueSprite)
    {
        this.text = text;
        this.unityEvent = _unityevent;
        this.characterSprite = characterSprite;
        this.DialogueSprite = DialogueSprite;
    }
}