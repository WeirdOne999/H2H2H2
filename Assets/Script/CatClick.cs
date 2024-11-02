using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;

public class CatClick : MonoBehaviour
{
    public Sprite normal;

    public List<Sprite> hit = new List<Sprite>();
    public Sprite Demon;

    public int touched = 0;
    public int timesToTouch;

    private MouseOver MO;

    public float time = 0;
    public float timeBackToNorm = 1.5f;
    public SpriteRenderer SR;
    public List<AudioClip> MEOW = new List<AudioClip>();

    public AudioSource AS;

    void Awake()
    {
        MO = GetComponent<MouseOver>();
        SR = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (MO.IsMouseOver)
            {
                AS.Stop();
                AS.clip = MEOW[Random.Range(0, MEOW.Count)];
                AS.Play();
                touched++;
                time = timeBackToNorm;
                SR.sprite = hit[Random.Range(0,hit.Count)];
            }
        }

        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 0;

                SR.sprite = normal;
            }
        }

        if (touched >  timesToTouch)
        {
            SR.sprite = Demon;
        }
    }
}
