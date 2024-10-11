using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;


    public void PlayAnim(string name)
    {
        GetComponent<Animator>().Play(name);
        source.PlayOneShot(clip);
    }
}
