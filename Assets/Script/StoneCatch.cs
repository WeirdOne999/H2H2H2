using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StoneCatch : MonoBehaviour
{
    public ArmFollowX AFX;
    public StoneCount SC;
    public AudioSource source;
    public AudioClip dropbag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Stones") return;
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y >= 0) return;
        if (!collision.gameObject.GetComponent<SpriteRenderer>().enabled) return;
        collision.gameObject.GetComponent<StoneHIdeAndShow>().Hide();
        collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        GameObject temp = collision.gameObject;
        AFX.Stones.Add(collision.gameObject);
        temp.SetActive(false);
        AFX.StoneCount++;
        SC.StoneOnFloor--;
        AFX.CheckForWin();

        source.PlayOneShot(dropbag);
    }
}
