using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // particles
    public GameObject WaterSplashParticles;
    public GameObject Ripptied;
    // where particle will spawn based on the object entrences
    public Vector3 ObjectInWaterTransform;
    
    // float values
    private float Waterheight;
    public float SlimeResistance;
    public float WaitTime;

    public AudioSource inWater;

    public void Start()
    {
        Waterheight = gameObject.transform.localScale.y;
        Waterheight /= 2;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<Rigidbody>().drag = SlimeResistance;
            inWater.Play();
            //Instantiate(Particles, other.transform.position +  new Vector3(0,-1,0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // red magnet layer
        if (other.gameObject.layer == 8)
        {
            ObjectInWaterTransform = other.transform.position;
            
            StartCoroutine(ExampleCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // red magnet layer
        if (other.gameObject.layer == 8)
        {
            other.GetComponent<Rigidbody>().drag = 10;
        }
    }
    
    // plays water particles
    IEnumerator ExampleCoroutine()
    {

        Instantiate(WaterSplashParticles, ObjectInWaterTransform +  new Vector3(0,0 + Waterheight,0), Quaternion.identity);

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(WaitTime);

        //After we have waited 1 seconds print the time again.
        Instantiate(Ripptied, new Vector3(ObjectInWaterTransform.x, gameObject.transform.position.y + Waterheight, ObjectInWaterTransform.z), Quaternion.identity);
        ObjectInWaterTransform = Vector3.zero;
    }
}
