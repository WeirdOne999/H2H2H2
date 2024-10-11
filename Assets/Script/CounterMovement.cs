using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CounterMovement : MonoBehaviour
{
    public Transform MainCharacter;
    private Vector3 pos;
    public float speed;
    public List<GameObject> listOfInteractables = new List<GameObject>();
    private Vector3 temp = Vector3.zero;
    private float speedTemp = 0f;
    public float heightOfSine = 0.5f;
    public float heightAlteration = 0f;
    public bool GOTSINE = true;
    public float freqOfSin = 0;
    private bool startSin = false;
    private float sinTimer = 0f;
    private float startY;
    private bool leftMouseDown = false;

    public GameObject Lborder;
    public GameObject Rborder;

    private CharacterLookAt CLA;
    private SpriteRenderer SR;

    public AudioSource source;
    public AudioClip clip;

    public List<GameObject> itemHolder  = new List<GameObject>();
    void Start()
    {
        temp = MainCharacter.transform.position;
        pos = MainCharacter.transform.position;
        startY = pos.y;
        CLA = GetComponent<CharacterLookAt>();
        SR = GetComponent<SpriteRenderer>();

        //foreach (GameObject go in itemHolder.chil)

        for (int j = 0; j < itemHolder.Count; j++)
        {
            for (int i = 0; i < itemHolder[j].transform.childCount; i++)
            {
                Debug.Log("Child: " + i);
                if (itemHolder[j].transform.GetChild(i).CompareTag("Item")) listOfInteractables.Add(itemHolder[j].transform.GetChild(i).gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        leftMouseDown = Input.GetMouseButton(0);

    }

    private void FixedUpdate()
    {
        if (startSin) sinTimer += Time.deltaTime;
        MainCharacter.transform.position = Vector3.MoveTowards(MainCharacter.transform.position, temp, speed);
        float tempFloat = (MainCharacter.transform.position.x - temp.x);
        if (tempFloat != 0 && GOTSINE)
        {
            //Debug.Log("SinCurve: " + tempFloat);
            float yCurve = Mathf.Sin(sinTimer * freqOfSin) * heightOfSine + heightAlteration;
            Vector3 newTemp = MainCharacter.transform.position;
            newTemp.y += yCurve;
            MainCharacter.transform.position = newTemp;
        }

        if (Mathf.Abs(tempFloat) < 0.5f)
        {
            startSin = false;
            temp.y = startY;
        }
        if (leftMouseDown)
        {
            foreach (GameObject go in listOfInteractables)
            {
                if (go.GetComponent<MouseOver>().IsMouseOver)
                {

                    Debug.Log("Touched Movement");
                    
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    
                    

                    pos.x = mousePosition.x;
                    if (mousePosition.x < Lborder.transform.position.x + SR.bounds.size.x / 2)
                    {
                        pos.x = Lborder.transform.position.x + SR.bounds.size.x / 2;
                    }
                    if (mousePosition.x > Rborder.transform.position.x - SR.bounds.size.x / 2)
                    {
                        pos.x = Rborder.transform.position.x - SR.bounds.size.x / 2;
                    }

                    temp = MainCharacter.transform.position;
                    if (temp.x > mousePosition.x)
                    {
                        CLA.LookLeft();
                    }
                    else
                    {
                        CLA.LookRight();
                    }
                    temp.x = pos.x;
                    speedTemp = Mathf.Abs((MainCharacter.transform.position - temp).magnitude) / speed;
                    freqOfSin = (MainCharacter.transform.position.x - temp.x);
                    startSin = true;
                    sinTimer = 0f;

                    //change look at

                    
                }
            }
        }
    }
}
