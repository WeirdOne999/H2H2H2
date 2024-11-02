using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemClick : MonoBehaviour
{
    private MouseOver MO;
    public UnityEvent Events;
    private ShoppingCartManager SCM;

    // Start is called before the first frame update
    void Awake()
    {
        MO = GetComponent<MouseOver>();
        SCM = GameObject.Find("Cart Item").GetComponent<ShoppingCartManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(MO.IsMouseOver)
            {
                SCM.currentClick = this.gameObject;
                Events.Invoke();
            }
        }
    }
}
