using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    public List<npcTemplate> npcHolder = new List<npcTemplate>();

    public GameObject prefab;



    public GameObject start;
    public GameObject end;
    public GameObject leave;

    private List<GameObject> current  =  new List<GameObject>();

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int temps = Random.Range(0, npcHolder.Count);
        GameObject temp = Instantiate(prefab, start.transform.position, Quaternion.identity);
        temp.GetComponent<NPC>().Back = npcHolder[temps].Back;
        temp.GetComponent<NPC>().Sad = npcHolder[temps].Sad;
        temp.GetComponent<NPC>().Happy = npcHolder[temps].Happy;
        temp.GetComponent<SpriteRenderer>().sprite = npcHolder[temps].Happy;
        temp.GetComponent<NPC>().StartMovement(end.transform.position.x);
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
