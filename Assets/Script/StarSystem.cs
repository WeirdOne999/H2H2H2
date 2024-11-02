using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class StarSystem : MonoBehaviour
{
    public float Stars = 5.0f;

    public List<float> StarsList = new List<float>();
    public RectTransform RT;
    private float widthStart;
    public float Speed = 1f;

    public List<UnityEvent> loseEvents = new List<UnityEvent>();

    public void ResetStar()
    {
        Stars = 5.0f;
    }
    void Awake()
    {
        widthStart = RT.sizeDelta.x;
    }

    private void FixedUpdate()
    {
        RT.sizeDelta = Vector2.MoveTowards(RT.sizeDelta,new Vector2(widthStart * (Stars / 5), RT.sizeDelta.y), Speed);
    }

    public void AddRating(float stars)
    {
        Stars += stars;
        if (Stars >= 5)
        {
            Stars = 5;
        }
        if (Stars <= 0)
        {
            foreach (UnityEvent ue in loseEvents)
            {
                ue.Invoke();
            }
        }
        
    }

    public void CalculateNewStars()
    {
        float temp = 0f;
        foreach (float i in  StarsList)
        {
            temp += i;
        }

        Stars = temp / StarsList.Count;

       
    }
}
