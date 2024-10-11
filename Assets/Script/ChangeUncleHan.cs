using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChangeUncleHan : MonoBehaviour
{
    [Serializable]
    public struct UncleHanTemplate
    {
        public Sprite Image;
        public Sprite Overlay;
        public int OrderLayer;
    }

    public Sprite basic;
    public Sprite basicOverlay;
    public int basicOrderLayer;

    public SpriteRenderer Body;
    public SpriteRenderer Hands;

    public List<UncleHanTemplate> UHT = new List<UncleHanTemplate>();

    public float timer;

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Body.sprite = basic;
            Hands.sprite = basicOverlay;
        }
    }

    public void SetNewSprite(int num)
    {
        Body.sprite = UHT[num].Image;
        Hands.sprite = UHT[num].Overlay;
        timer = 0.5f;
    }
}