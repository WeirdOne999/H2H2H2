using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JoyStickLogic : MonoBehaviour
{
    public GameObject baseStick;
    public GameObject targetStick;

    public Vector3 diff;

    public void Update()
    {

        diff = baseStick.transform.position - targetStick.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            baseStick.SetActive(true);
            baseStick.transform.position = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
                targetStick.transform.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            baseStick.SetActive(true);
            targetStick.transform.position = baseStick.transform.position;
        }
    }
}
