using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StockAdd : MonoBehaviour
{
    private PointerStock PS;
    private void Start()
    {
        PS = GameObject.Find("PointerStock").GetComponent<PointerStock>();
    }
    public void AddStock(string stock)
    {
        if (stock == PS.CurrentStock)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (!this.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    this.transform.GetChild(i).gameObject.active = true;
                    PS.AddedStock();
                    break;
                }
            }
        }
    }
}
