using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopsSpin : MonoBehaviour
{
    public float speed;
    public float AngularSpeed;

    private Rigidbody2D rb;

    public float Torque;
    public float force;
    public Vector3 direction;
    public bool spinning = false;
    float tempangvel;

    public GameObject spinbutton;

    public AudioSource source;
    public AudioClip topspinning;

    private float timerCount = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Reset Rigidbody state and variables on scene reload
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        spinning = true;
        Debug.Log("TEST: " + spinning);
        StartSpinning();
        Debug.Log("TEST2: " + spinning);
    }

    // Update is called once per frame
    private void Update()
    {
        timerCount += Time.deltaTime;
        //Debug.Log(rb.totalTorque);

        if (rb.angularVelocity < 500 && timerCount > 2.0f)
        {
            Debug.Log("Lost Spin");
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

    public void StopSpinning()
    {
        tempangvel = rb.angularVelocity;
        spinning = false;
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;
    }

    public void StartSpinningAgain()
    {
        rb.AddTorque(tempangvel);
        spinning = true;
    }

    public void StartSpinning()
    {
        rb.AddTorque(500f);
        spinning = true;

        if (source != null && topspinning != null)
        {
            source.PlayOneShot(topspinning);
        }
    }
}
