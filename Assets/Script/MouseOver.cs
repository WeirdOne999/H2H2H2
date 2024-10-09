using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public bool IsMouseOver;
    void Start()
    {
        IsMouseOver = false;
    }

    private void OnEnable()
    {
        IsMouseOver = false;
    }

    private void OnMouseOver()
    {
        IsMouseOver = true;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
