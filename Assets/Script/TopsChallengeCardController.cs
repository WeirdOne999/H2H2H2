using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TopsChallengeCardController : MonoBehaviour
{
    public UnityEvent Show;

    public UnityEvent Hide;

    public float temp;

    private void Start()
    {
        Hide.Invoke();
    }

    private void Update()
    {
        temp += Time.deltaTime;

        if (temp > 5.0f)
        {
            Show.Invoke();
            Destroy(this);
        }
    }
}
