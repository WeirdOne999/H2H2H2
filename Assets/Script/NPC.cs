using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class NPC : MonoBehaviour
{
    public float speed;
    public Vector3 temp = Vector3.zero;
    public float heightOfSine = 0.5f;
    public float heightAlteration = 0f;
    public bool GOTSINE = true;
    public float freqOfSin = 0;
    public bool startSin = false;
    private float sinTimer = 0f;
    private float startY;

    public int CheckpointNumber;

    public Sprite Back;
    public Sprite Happy;
    public Sprite Sad;

    public SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (startSin) sinTimer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, temp, speed);

        float tempFloat = (transform.position.x - temp.x);
        if (tempFloat != 0 && GOTSINE)
        {
            //Debug.Log("SinCurve: " + tempFloat);
            float yCurve = Mathf.Sin(sinTimer * freqOfSin) * heightOfSine + heightAlteration;
            Vector3 newTemp = transform.position;
            newTemp.y += yCurve;
            transform.position = newTemp;
        }
        if (Mathf.Abs(tempFloat) < 0.5f)
        {
            startSin = false;
            temp.y = startY;
        }
    }

    public void StartMovement(float x)
    {
        temp.y = transform.position.y;
        temp.x = x;
        startY = transform.position.y;
        freqOfSin = (transform.position.x - temp.x);
        startSin = true;
        sinTimer = 0f;
    }

    public void HappySprite()
    {
        SR.sprite = Happy;
    }

    public void SadSprite()
    {
        SR.sprite = Sad;
    }

    public void BackSprite()
    {
        SR.sprite = Back;
    }
}
