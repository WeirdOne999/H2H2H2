using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSpinAi : MonoBehaviour
{

    private Rigidbody2D rb;
    public float force;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(rb.totalTorque);

    }

    private void FixedUpdate()
    {

       

    }

    public void StartSpinning()
    {
        rb.AddTorque(500f);
    }
}
