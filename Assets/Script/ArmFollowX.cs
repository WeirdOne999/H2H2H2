using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ArmFollowX : MonoBehaviour
{

    public Sprite Normal;
    public Sprite Grab;
    public Sprite Catch;

    private SpriteRenderer SR;

    public int StoneCount = 0;

    public TextMeshProUGUI ui;

    public float grabTime = 0;
    public bool grabbed = false;
    public int highestScore = 0;

    public List<GameObject> Stones = new List<GameObject>();

    public float throwMultiplier = 5.0f;
    public bool StartThrow = false;

    public StoneCount SC;

    public UnityEvent ue;


    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    public void CheckForWin()
    {
        if (StoneCount >= 5)
        {
            this.gameObject.SetActive(false);
            ue.Invoke();
        }
    }

    private void Update()
    {
        
        ui.text = StoneCount.ToString();
        if (highestScore < StoneCount)
        {
            highestScore = StoneCount;
        }

        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v3.z = -1;
        this.transform.position = v3;

            if (Input.GetMouseButtonDown(0) && (Time.time - grabTime) > 0.5f && SC.StoneOnFloor + StoneCount >= 5)
            {
            

            if (StoneCount > 0)
                {
                int tempCount = Stones.Count;
                for (int i = 0; i < tempCount; i++)
                {
                    SR.sprite = Catch;
                    //throw remaining
                    GameObject temp = Stones[0];
                    temp.SetActive(true);
                    Stones[0].GetComponent<SpriteRenderer>().enabled = true;
                    Stones[0].GetComponent<StoneHIdeAndShow>().Show();

                    Stones[0].transform.position = this.transform.position + new Vector3(0,1,0);

                    Stones[0].GetComponent<Rigidbody2D>().AddForce(Vector2.up * throwMultiplier);
                    StoneCount--;
                    Stones.Remove(Stones[0]);
                    if (Stones.Count == 0)
                    {
                        grabbed = false;
                    }
                }
                    
                }
            }
            
    }

    public void ArmClose()
    {
        grabTime = Time.time;
        Debug.Log("Close : " + StoneCount);
        StoneCount++;
        SR.sprite = Grab;
    }
}
