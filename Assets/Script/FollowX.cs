using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowX : MonoBehaviour
{
    public Transform t;

    private float Starty;

    public float speed = 1.0f;

    void Awake()
    {
        Starty = this.transform.position.y;
    }

    private void FixedUpdate()
    {
        Vector3 v3 = t.position;
        v3.y = Starty;

        this.transform.position = Vector3.MoveTowards(this.transform.position,v3, speed);
    }
}
