using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCount : MonoBehaviour
{
    public int StoneOnFloor = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Stones") return;
        if (!collision.gameObject.GetComponent<SpriteRenderer>().enabled) return;
        StoneOnFloor++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Stones") return;
        if (!collision.gameObject.GetComponent<SpriteRenderer>().enabled) return;

        StoneOnFloor--;
    }

}
