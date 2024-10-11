using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEraserController : MonoBehaviour
{
    private MouseOver MO;
    private EraserForce EF;
    public bool GotClick = false;

    public GameObject Arrow;

    public float arrowLimit;

    public bool oneClick = false;

    // Start is called before the first frame update
    void Start()
    {
        MO = GetComponent<MouseOver>();
        EF = GetComponent<EraserForce>();
        Arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (MO.IsMouseOver && !oneClick)
            {
                GotClick = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (GotClick)
            {
                Arrow.SetActive(false);
                EF.FlickEraer(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                oneClick = true;
                GotClick = false;
            }
        }

        if (GotClick)
        {
            Arrow.SetActive(true);
            Vector2 temp = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Vector3 temps = (this.transform.position - new Vector3(temp.x, temp.y, 0)).normalized;
            temps.z = 0;
            //Debug.Log((temp).normalized);
            Vector3 v3 = this.transform.position + (temps.normalized * arrowLimit);
            v3.z = -1;
            Arrow.transform.position = v3;
            var zEulerAngle = Mathf.Atan2(
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y - this.transform.position.y,
            -(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - this.transform.position.x)
            ) * Mathf.Rad2Deg;
            Arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -zEulerAngle));

        }
    }
}
