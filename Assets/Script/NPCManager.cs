using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

    private void Start()
    {
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
        int temps = Random.Range(0, npcHolder.Count - 3);
        if (StoryMode)
        {
            if (CustomersBefore1 == 0) temps = npcHolder.Count - 3;
            if (CustomersBefore2 == 0) temps = npcHolder.Count - 2;
            if (CustomersBefore3 == 0) temps = npcHolder.Count - 1;

            CustomersBefore1--;
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
}
