using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLookAt : MonoBehaviour
{
    private float scaleX;
    private void Start()
    {
        scaleX = transform.localScale.x;
    }
    public void LookLeft()
    {
        setX(Mathf.Abs(scaleX));
    }
    public void LookRight()
    {
        setX(-scaleX);
    }
    public void setX(float x)
    {
        Vector3 scale = transform.localScale;
        scale.x = x;
        transform.localScale = scale;
    }
}
