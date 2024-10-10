using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHIdeAndShow : MonoBehaviour
{
    public SpriteRenderer SR;

    public void Hide()
    {
        SR.enabled = false;
    }

    public void Show()
    {
        SR.enabled = true;
    }
}
