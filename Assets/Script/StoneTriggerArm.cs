using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class StoneTriggerArm : MonoBehaviour
{

    public List<GameObject> targets;
    public ArmFollowX AFX;
    public StoneCount SC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Stones") return;
        if (!collision.gameObject.GetComponent<SpriteRenderer>().enabled) return;

        targets.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Stones") return;
        if (!collision.gameObject.GetComponent<SpriteRenderer>().enabled) return;

        targets.Remove(collision.gameObject);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (AFX.StoneCount == 0 && !AFX.grabbed)
            {
                AFX.Stones.Add(targets[0]);
                targets[0].GetComponent<StoneHIdeAndShow>().Hide();

                targets[0].GetComponent<SpriteRenderer>().enabled = false;
                GameObject temp = targets[0];
                targets.Remove(targets[0]);
                temp.SetActive(false);
                AFX.grabbed = true;
                AFX.ArmClose();
                SC.StoneOnFloor--;
            }
        }
    }
}
