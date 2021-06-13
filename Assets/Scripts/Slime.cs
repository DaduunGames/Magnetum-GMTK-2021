using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float SlimeResistance;
    public GameObject Particles;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<Rigidbody>().drag = SlimeResistance;
            //Instantiate(Particles, other.transform.position +  new Vector3(0,-1,0), Quaternion.identity);
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
