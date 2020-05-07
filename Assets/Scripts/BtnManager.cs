using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public float ScaleSpeed = 0.01f;
    public bool DoUp = false;
    void Update()
    {
        if (DoUp)
            MakeUp();
    }
    public void MakeUp()
    {
        GameObject.FindWithTag("Cube").transform.localScale += new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
    }
    public void MakeUpBtn()
    {
        DoUp = true;
    }
}
