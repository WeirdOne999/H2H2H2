using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TopsChallengeCardController : MonoBehaviour
{
    public UnityEvent Show;

    public UnityEvent Hide;

    public float temp;

    private void Awake()
    {
    }

    private void Update()
    {
        temp += Time.deltaTime;

        if (temp > 0.1f && temp< 1.1f)
        {
            Hide.Invoke();
        }

        if (temp > 5.0f)
        {
            Show.Invoke();
            Destroy(this);
        }
    }
}
