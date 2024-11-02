using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class NPCManager : MonoBehaviour
{
    [Serializable]
    public struct npcTemplate
    {
        public string name;
        public Sprite Happy;
        public Sprite Sad;
        public Sprite Back;
        public int CheckPoint;
    }

    public List<npcTemplate> npcHolder = new List<npcTemplate>();

    public GameObject prefab;



    public GameObject start;
    public GameObject end;
    public GameObject leave;

    public List<GameObject> current  =  new List<GameObject>();

    public bool StoryMode = false;

    public int CustomersBefore1 = 1;
    public int CustomersBefore2 = 1;
    public int CustomersBefore3 = 1;

    public StorySave SS;

    public float gainPerCustomer = 0.3f;
    public float losePerCustomer = -1f;

    public UnityEvent win;
    public UnityEvent lose;

    public bool StartQ = false;

    private void Awake()
    {
    }

    public void StartQTrue()
    {
        StartQ = true;
    }

    public void StartQFalse()
    {
        StartQ = false;
    }

    public void StoryModeTrue()
    {
        StoryMode = true;
    }

    public void Customers1(int cust)
    {
        CustomersBefore1 = cust;
    }

    public void Customers2(int cust)
    {
        CustomersBefore2 = cust;
    }

    public void Customers3(int cust)
    {
        CustomersBefore3 = cust;
    }

    public void Spawn()
    {
        if (!StartQ) return;
        int temps = Random.Range(0, npcHolder.Count - 3);
        if (StoryMode)
        {
            

            if (CustomersBefore1 == 0 && SS.StoryCharacter == 0) temps = npcHolder.Count - 3;
            if (CustomersBefore2 == 0 && SS.StoryCharacter == 1) temps = npcHolder.Count - 2;
            if (CustomersBefore3 == 0 && SS.StoryCharacter == 2) temps = npcHolder.Count - 1;

            if (CustomersBefore1 != 0) CustomersBefore1--;
            if (CustomersBefore1 <= 0) CustomersBefore2--;
            if (CustomersBefore2 <= 0) CustomersBefore3--;


        }
        GameObject temp = Instantiate(prefab, start.transform.position, Quaternion.identity);
        temp.GetComponent<NPC>().Back = npcHolder[temps].Back;
        temp.GetComponent<NPC>().Sad = npcHolder[temps].Sad;
        temp.GetComponent<NPC>().Happy = npcHolder[temps].Happy;
        temp.GetComponent<SpriteRenderer>().sprite = npcHolder[temps].Happy;
        temp.GetComponent<NPC>().StartMovement(end.transform.position.x);
        temp.GetComponent<NPC>().CheckpointNumber = npcHolder[temps].CheckPoint;
        current.Add(temp);
    }

    public void CurrentCustomerLeave()
    {

        GameObject.Find("Main Camera").GetComponent<StarSystem>().AddRating(Random.Range(0, 6));

        current[0].GetComponent<NPC>().StartMovement(leave.transform.position.x);
        current[0].GetComponent<NPC>().HappySprite();
        current.Remove(current[0]);
        Spawn();
    }

    public void IsCustomerHappy(bool isHappy)
    {
        if (isHappy)
        {
            GameObject.Find("Main Camera").GetComponent<StarSystem>().AddRating(gainPerCustomer);
            current[0].GetComponent<NPC>().HappySprite();
            win.Invoke();
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<StarSystem>().AddRating(losePerCustomer);
            current[0].GetComponent<NPC>().SadSprite();
            lose.Invoke();

        }

        current[0].GetComponent<NPC>().StartMovement(leave.transform.position.x);
        current.Remove(current[0]);
        Spawn();
    }
}
