using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public bool gotSound = true;
    public AudioSource source;
    public AudioClip clip;


    public void PlayAnim(string name)
    {
        GetComponent<Animator>().Play(name);
        if (gotSound) source.PlayOneShot(clip);
    }
}
