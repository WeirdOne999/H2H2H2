using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemClick : MonoBehaviour
{
    private MouseOver MO;
    public UnityEvent Events;
    // Start is called before the first frame update
    void Start()
    {
        MO = GetComponent<MouseOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(MO.IsMouseOver)
            {
                Events.Invoke();
            }
        }
    }
}
