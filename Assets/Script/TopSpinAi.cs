using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSpinAi : MonoBehaviour
{

    private Rigidbody2D rb;
    public float force;
    public GameObject player;
    public bool spinning = false;
    public GameObject centre;
    public float angle;
    public float moveSpeed;
    public float radius;
    public float randomtime;
    public bool atpoint = false;
    public float tempangvel;
    public bool pause;

    private float timerCount = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartSpinning();  
        
    }

    public void SpinAgain()
    {
        rb = GetComponent<Rigidbody2D>();
        StartSpinning();
    }

    // Update is called once per frame
    private void Update()
    {
        timerCount += Time.deltaTime;
        if (rb.angularVelocity < 500 && timerCount > 2.0f)
        {
            spinning = false;
        }
        Debug.Log(rb.totalTorque);

        
        if (spinning == true && Time.timeScale != 0)
        {
            randomtime += Time.deltaTime;
            if (randomtime > 5)
            {
                //angle += (moveSpeed / (radius * Mathf.PI * 2.0f)) * Time.deltaTime;
                //transform.position = Vector2.MoveTowards(transform.position, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius, force);

                angle += (moveSpeed / (radius * Mathf.PI * 2.0f)) * Time.deltaTime;


                float distancetopoint = Vector2.Distance(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius, transform.position);
                if (distancetopoint < 1)
                {
                    atpoint = true;

                }

                if (atpoint)
                {
                    transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(centre.transform.position.x, -4), force);
                }

                if (randomtime > 10)
                {
                    randomtime = 0;
                    atpoint = false;
                }
                Debug.Log("Circle");
            }
            else
            {
                if (spinning == true && pause == false)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, force);
                }
                float distancetocentre = Vector2.Distance(centre.transform.position, transform.position);
                if (distancetocentre > 4)
                {
                    Vector2 direction = centre.transform.position - transform.position;
                    rb.AddForce(direction);
                }
                Debug.Log("follow");
            }
        }
       

        


        Debug.Log(atpoint);
        //transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
    }

    private void FixedUpdate()
    {

       

    }

    public void StartSpinning()
    {
        rb.AddTorque(500f);
        spinning = true;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Vector2 direction = player.transform.position - transform.position;

            rb.AddForce(-direction * 3, ForceMode2D.Impulse);

            collision.rigidbody.AddForce(direction*3, ForceMode2D.Impulse);
        }
       
    }

    public void StopSpinning()
    {
        tempangvel = rb.angularVelocity;
        spinning = false;
        rb.angularVelocity = 0;


        rb.velocity = Vector2.zero;
        pause = true;
    }

    public void StartSpinningAgain()
    {
        rb.AddTorque(tempangvel);
        spinning = true;
        pause = false;
    }
}
