using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public Mesh CompleteMagnet;
    public MeshFilter meshfilter;
    public ParticleSystem sparks;
    public Magnet magnet;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            meshfilter.mesh = CompleteMagnet;
            magnet.AttractedObjects = new GameObject[0];
            Instantiate(sparks, transform.position, transform.rotation);
        }
    }
}
