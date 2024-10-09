using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnTouch : MonoBehaviour
{
    public string collisionTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != collisionTag) return;
        Destroy(collision.gameObject);
    }
}
