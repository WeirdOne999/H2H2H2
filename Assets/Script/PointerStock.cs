using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using static ShoppingCartManager;

public class PointerStock : MonoBehaviour
{
    public bool holdingStock = false;


    public ShoppingCartManager SCM;
    private SpriteRenderer sprite;

    public string CurrentStock;

    public List<GameObject> StockCollider = new List<GameObject>();

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        foreach (GameObject item in this.StockCollider)
        {
            item.SetActive(false);
        }

    }

    private void Update()
    {
        if (holdingStock)
        {
            foreach (GameObject item in this.StockCollider)
            {
                item.SetActive(true);
            }
            Vector3 tempV = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tempV.z = 1;
            this.transform.position = tempV;
            sprite.enabled = true;
            this.transform.tag = "Mouse";
            if (Input.GetMouseButtonUp(0))
            {
                foreach (GameObject item in this.StockCollider)
                {
                    item.SetActive(false);
                }
                this.transform.tag = "MouseItem";
                holdingStock = false;
                GameObject temp = Instantiate(this.gameObject);
                Destroy(temp.GetComponent<PointerStock>());
                temp.AddComponent<Rigidbody2D>();
                sprite.enabled = false;
            }
        }
    }

    public void AddedStock()
    {
        this.transform.tag = "MouseItem";
        holdingStock = false;
        sprite.enabled = false;
        foreach (GameObject item in this.StockCollider)
        {
            item.SetActive(false);
        }
    }

    public void SetStock(string name)
    {
        if (holdingStock) return;
        else holdingStock = true;
        //foreach (ShoppingCartManager.grocery grocery in SCM.groceries)
        //{
        //    Debug.Log(grocery.name + " " + name);
        //    if (grocery.name == name)
        //    {
        //        sprite.sprite = grocery.image;
        //    }
        //}

        for (int i =0; i < SCM.groceries.Count; i++)
        {
            if (SCM.groceries[i].name == name)
            {
                sprite.sprite = SCM.groceries[i].image;
                CurrentStock = SCM.groceries[i].name;
            }
        }
    }
}
