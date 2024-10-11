using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialogueUI;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private string cacheText;
    public GameObject dialogueSprite; 
    public Queue<string> lines;
    public float textSpeed;
    private float actualTextSpeed;
    public Queue<DialogueData> dialogueQueue = new();

    public bool DialogueIsRunning = false;
    [SerializeField] UnityEvent unityEvent;
    DialogueData previousData;

   

    // Start is called before the first frame update
    void Start()
    {


    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (previousData.unityEvent != null)
            {
                previousData.characterSprite.SetActive(false);
                previousData.DialogueSprite.SetActive(false);
                previousData.unityEvent.Invoke();
                previousData.unityEvent = null;
            }

            if (dialogueQueue.Count == 0)
            {
                if (DialogueIsRunning)
                {
                    EndDialogue();
                    unityEvent.Invoke();
                }
                return; //ignore if queue is currently empty
            }

            DialogueData sentence = dialogueQueue.Dequeue();
            sentence.characterSprite.SetActive(true);
            sentence.DialogueSprite.SetActive(true);

            DisplayNext(sentence);
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {

        DialogueUI.SetActive(true);
        DialogueIsRunning = true;
        
        dialogueQueue.Clear();

        foreach (DialogueData data in dialogue.data)
        {
            dialogueQueue.Enqueue(data);
            
        }

        DialogueData sentence = dialogueQueue.Dequeue();
        
        DisplayNext(sentence);
    }

    public void DisplayNext(DialogueData currentData)
    {

        StopAllCoroutines();
        StartCoroutine(TypeSentenceAndInvokeEvent(currentData));
        previousData = currentData;
        currentData.characterSprite.SetActive(true);
        currentData.DialogueSprite.SetActive(true);

    }


    IEnumerator TypeSentenceAndInvokeEvent(DialogueData currentData)
    {
        dialogueText.text = "";
        bool htmltag = false;
        foreach (char c in currentData.text.ToCharArray())
        {
            if (c == '<')
            {
                htmltag = true;
            }

            if (c == '>')
            {
                htmltag = false;
            }

            if (htmltag == false)
            {
                dialogueText.text += cacheText + c;
                cacheText = "";
                actualTextSpeed = textSpeed;
            }
            else
            {
                actualTextSpeed = 0;
                cacheText = cacheText + c;
            }
           
            yield return new WaitForSeconds(actualTextSpeed);
        }

       
    }

    void EndDialogue()
    {
        DialogueIsRunning = false;
        DialogueUI.SetActive(false);
    }


}

