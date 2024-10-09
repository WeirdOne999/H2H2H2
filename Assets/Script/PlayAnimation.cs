using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public void PlayAnim(string name)
    {
        GetComponent<Animator>().Play(name);
    }
}
