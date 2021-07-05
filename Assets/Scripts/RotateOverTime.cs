using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    public Vector3 Speeds;
    void Update()
    {
        transform.Rotate(Speeds * Time.deltaTime);
    }
}
