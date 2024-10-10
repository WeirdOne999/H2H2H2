using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotate : MonoBehaviour
{
    public Transform reference;
    private void Update()
    {
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, reference.position)

;
    }
}
