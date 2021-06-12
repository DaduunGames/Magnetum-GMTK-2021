using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float SlimeResistance;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<Rigidbody>().drag = SlimeResistance;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<Rigidbody>().drag = 10;
        }
    }

}
