using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    public Vector3 temp = Vector3.zero;
    public float heightOfSine = 0.5f;
    public float heightAlteration = 0f;
    public bool GOTSINE = true;
    public float freqOfSin = 0;
    public bool StartSin = false;
    private float sinTimer = 0f;
    private float StartY;

    public int CheckpointNumber;

    public Sprite Back;
    public Sprite Happy;
    public Sprite Sad;

    public SpriteRenderer SR;

    public AudioSource source;
    public AudioClip walk;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (StartSin) sinTimer += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, temp, speed);
        if (!(temp == transform.position))
        {
            if (!source.isPlaying)
            {

                source.PlayOneShot(walk);
            }


        }else
        {
            source.Stop();
        }

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
            StartSin = false;
            temp.y = StartY;
        }
    }

    public void StartMovement(float x)
    {
        temp.y = transform.position.y;
        temp.x = x;
        StartY = transform.position.y;
        freqOfSin = (transform.position.x - temp.x);
        StartSin = true;
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
