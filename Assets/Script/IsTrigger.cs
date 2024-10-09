using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class IsTrigger : MonoBehaviour
{
    public List<UnityEvent> unityEvents = new List<UnityEvent>();
    public string collisionTag;
    public bool NeedChangeSprite = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != collisionTag) return;
        foreach (UnityEvent ue in unityEvents)
        {
            ue.Invoke();
        }

        if(NeedChangeSprite) collision.gameObject.GetComponent<NPC>().BackSprite();
    }
}
