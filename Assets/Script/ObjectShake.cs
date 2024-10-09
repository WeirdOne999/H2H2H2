using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    public IEnumerator Tremble()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localPosition += new Vector3(5f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition -= new Vector3(5f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
