using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShoppingCartManager : MonoBehaviour
{
    [Serializable]
    public struct grocery
    {
        public string name;
        public Sprite image;
    }

    public float count;
    public float half;

    private RectTransform RT;

    private List<GameObject> cart = new List<GameObject>();

    public GameObject prefab;
    public List<grocery> groceries = new List<grocery>();

    public int currentPosition = 0;
    public List<string> OrderOfCustomers = new List<string>();

    public NPCManager npcMan;

    public GameObject currentClick;

    public GameObject SpeechBubble;

    public GameObject Esclamation;

    private void Start()
    {
        RT = GetComponent<RectTransform>();
        RT.sizeDelta = new Vector2(0,0);
        SpeechBubble.SetActive(false);
        Esclamation.SetActive(false);
    }

    public void SetCount(float count)
    {
        this.count = count;

        half = Mathf.Ceil(count);
        RT.sizeDelta = new Vector2((half * 125) + ((half - 1) * 12), 125);

        currentPosition = 0;
    }

    private void Update()
    {
        
    }

    public void OrderRand()
    {
        if (npcMan.current[0].GetComponent<NPC>().CheckpointNumber == 0)
        {
            NewOrder(Random.Range(1, 6));
        }
        else
        {
            Esclamation.SetActive(true);
        }
    }

    public void NewOrder(int orderCount)
    {
        SpeechBubble.SetActive(true);
        foreach (GameObject item in  cart)
        {
            Destroy(item);
        }
        cart.Clear();
        OrderOfCustomers.Clear();
        for (int i = 0; i < orderCount; i++)
        {
            int temps = Random.Range(0, groceries.Count);
            cart.Add(Instantiate(prefab));
            cart[cart.Count - 1].transform.SetParent(this.transform);
            cart[cart.Count - 1].GetComponent<Image>().sprite = groceries[temps].image;
            OrderOfCustomers.Add(groceries[temps].name);
        }
        SetCount(orderCount);
    }

    public void ClickOnItem(string name)
    {
        if (count == 0) return;
        Debug.Log("Click on " + name);
        if (OrderOfCustomers[currentPosition] == name)
        {
            for (int i = 0; i < cart[currentPosition].transform.childCount; i++)
            {
                cart[currentPosition].transform.GetChild(i).gameObject.SetActive(true);
            }

            currentClick.SetActive(false);

            currentPosition++;

            if (currentPosition == count)
            {
                //End Customer
                foreach (GameObject item in cart)
                {
                    Destroy(item);
                }
                RT.sizeDelta = new Vector2(0, 0);
                count = 0;
                cart.Clear();
                npcMan.CurrentCustomerLeave();
                SpeechBubble.SetActive(false);
                Esclamation.SetActive(false);
            }
        }
    }
}
