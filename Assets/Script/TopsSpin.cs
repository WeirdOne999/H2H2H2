using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TopsSpin : MonoBehaviour
{
    public float speed;
    public float AngularSpeed;

    private Rigidbody2D rb;

    public float Torque;
    public float force;
    public Vector3 direction;
    bool spinning = false;

    public GameObject spinbutton;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        spinbutton.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(rb.totalTorque);


        if (rb.angularVelocity < 500)
        {
            spinbutton.SetActive(true);
        }else
        {
            spinbutton.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * force);  
            direction = transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.up * force); 
            direction = -transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * force);
            direction = -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * force); 
            direction = transform.right;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    public void StartSpinning()
    {
        rb.AddTorque(500f);
        spinning = true;
    }
}
