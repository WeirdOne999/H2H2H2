using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestockButton : MonoBehaviour
{
    public UnityEvent Open;

    public UnityEvent Close;

    public bool stockOpen;

    public void TriggerStock()
    {
        if (stockOpen)
        {
            stockOpen = false;
            Close.Invoke();
        }
        else
        {
            stockOpen = true;
            Open.Invoke();
        }
    }
}
