using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
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
    public GameObject SliderGO;
    public Slider slider;

    public float timerForCustomer;
    public float timeRemaining;

    public GameObject Esclamation;
    public GameObject Esclamation2;
    public GameObject Esclamation3;

    public float foreachitem;
    public float extratime;

    public AudioSource source;
    public AudioClip kaching;
    public AudioClip bubble;
    public AudioClip Exclaim;

    public UnityEvent happyHan;
    public UnityEvent AngryHan;

    public GameObject clickParticle;
    public GameObject starParticle;
    public GameObject angryParticle;
    public GameObject hanRef;
    private void Awake()
    {
        RT = GetComponent<RectTransform>();
        RT.sizeDelta = new Vector2(0,0);
        SpeechBubble.SetActive(false);
        Esclamation.SetActive(false);
        Esclamation2.SetActive(false);
        Esclamation3.SetActive(false);
        SliderGO.SetActive(false);
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
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            slider.value = timeRemaining / timerForCustomer;

            if (timeRemaining <= 0 && cart.Count != 0)
            {
                Instantiate(angryParticle,hanRef.transform.position, Quaternion.identity);
                //End Customer
                AngryHan.Invoke();
                foreach (GameObject item in cart)
                {
                    Destroy(item);
                }
                RT.sizeDelta = new Vector2(0, 0);
                count = 0;
                cart.Clear();
                npcMan.IsCustomerHappy(false);
                SliderGO.SetActive(false);
                SpeechBubble.SetActive(false);
                Esclamation.SetActive(false);
                Esclamation2.SetActive(false);
                Esclamation3.SetActive(false);
            }
        }
    }

    public void OrderRand()
    {
        if (npcMan.current[0].GetComponent<NPC>().CheckpointNumber == 0)
        {
            NewOrder(Random.Range(1, 6));
        }
        else if(npcMan.current[0].GetComponent<NPC>().CheckpointNumber == 1)
        {
            Esclamation.SetActive(true);
            source.PlayOneShot(Exclaim);    
        }
        else if (npcMan.current[0].GetComponent<NPC>().CheckpointNumber == 2)
        {
            Esclamation2.SetActive(true);
            source.PlayOneShot(Exclaim);
        }
        else if (npcMan.current[0].GetComponent<NPC>().CheckpointNumber == 3)
        {
            Esclamation3.SetActive(true);
            source.PlayOneShot(Exclaim);
        }
    }

    public void NewOrder(int orderCount)
    {
        SpeechBubble.SetActive(true);
        source.PlayOneShot(bubble);
        SliderGO.SetActive(true);
        timerForCustomer = orderCount * foreachitem + extratime;
        timeRemaining = timerForCustomer;
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
            Instantiate(clickParticle, currentClick.transform.position, Quaternion.identity);
            currentClick.SetActive(false);

            currentPosition++;

            if (currentPosition == count)
            {
                Instantiate(starParticle, hanRef.transform.position, Quaternion.identity);
                source.PlayOneShot(kaching);
                //End Customer
                foreach (GameObject item in cart)
                {
                    Destroy(item);
                }
                RT.sizeDelta = new Vector2(0, 0);
                count = 0;
                cart.Clear();
                npcMan.IsCustomerHappy(true);
                SliderGO.SetActive(false);
                SpeechBubble.SetActive(false);
                Esclamation.SetActive(false);
                Esclamation2.SetActive(false);
                Esclamation3.SetActive(false);
                happyHan.Invoke();
            }

        }

    }
}
