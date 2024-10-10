using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class EraserForce : MonoBehaviour
{
    private Rigidbody2D rb;
    public float flickPower = 1.0f;
    public float torque = 1.0f;

    public bool OnTurn = false;

    public float lowestMag = 1.0f;
    public UnityEvent TurnDone;

    private float Timer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if (OnTurn)
        {
            Timer += Time.deltaTime;
            //Debug.Log(rb.velocity.magnitude + " " + rb.angularVelocity);
            if (rb.velocity.magnitude == 0 && rb.angularVelocity == 0 && Timer > 1f)
            {
                OnTurn = false;
                TurnDone.Invoke();
            }
        }
    }

    public void FlickEraer(Vector3 v2)
    {
        Timer = 0f;
        OnTurn = true;
        rb.AddForce(((this.transform.position - v2)) * flickPower);

        //Debug.Log(torque * (v2.magnitude) / Mathf.Abs(torque * (v2.magnitude)));
        float temp = 0f;
        if(v2.x < this.transform.position.x)
        {
            temp = -1f;
        }
        else
        {
            temp = 1f;
        }
        rb.AddTorque(temp * torque);
    }

    public void InverseFlickEraer(Vector3 v2)
    {
        Timer = 0f;
        OnTurn = true;
        rb.AddForce((-(this.transform.position - v2)) * flickPower);


        //Debug.Log(torque * (v2.magnitude) / Mathf.Abs(torque * (v2.magnitude)));

        float temp = 0f;
        if (v2.x < this.transform.position.x)
        {
            temp = -1f;
        }
        else
        {
            temp = 1f;
        }
        rb.AddTorque(temp * torque);
    }
}
