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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
            //dialogueSprite.GetComponent<Image>().sprite = transform.GetComponent<SpriteRenderer>().sprite;

            Destroy(this.gameObject.GetComponent<Collider2D>());
        }



    }

}
