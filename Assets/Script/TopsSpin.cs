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

    public AudioSource source;
    public AudioClip topspinning;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartSpinning();
        
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(rb.totalTorque);


       if (rb.angularVelocity < 500)
        {
            spinning = false;
        }
    }

    private void FixedUpdate()
    {
        if (spinning == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector2.up * force);
                direction = Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-Vector2.up * force);
                direction = -Vector2.up;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-Vector2.right * force);
                direction = -Vector2.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * force);
                direction = Vector2.right;
            }
        }
       
    }



    public void StartSpinning()
    {
        rb.AddTorque(500f);
        spinning = true;

        source.PlayOneShot(topspinning);
    }
}
