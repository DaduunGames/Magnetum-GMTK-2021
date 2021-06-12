using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject[] AttractedObjects;
    public float AttractionForce;
    public float DampeningFactor = 1;

    private void Update()
    {
        foreach (GameObject obj in AttractedObjects)
        {
            Vector3 force = transform.position - obj.transform.position;
            force.Normalize();
            force *= AttractionForce + (DampeningFactor / Vector3.Distance(transform.position, obj.transform.position));

            obj.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
