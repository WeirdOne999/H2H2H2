using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueSprite;
    public Dialogue dialogue;
    public GameObject DialogueUI;
    public void TriggerDialogue()
    {   
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
       
    }
}
