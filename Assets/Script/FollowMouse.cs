using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v3.z = -1;
        Debug.Log(v3);

    }
}
