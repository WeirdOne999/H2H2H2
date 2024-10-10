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
    public string name;
    public Sprite picture;

    public DialogueData(string text, UnityEvent _unityevent, string name, Sprite picture)
    {
        this.text = text;
        this.unityEvent = _unityevent;
        this.name = name;
        this.picture = picture;
    }
}