using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float NeededBreakVelocity;

    public ParticleSystem particles;

    public AudioSource breakAudio;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            if (rb.velocity.magnitude >= NeededBreakVelocity)
            {
                Instantiate(particles, transform.position, transform.rotation);
                breakAudio.Play();
                Destroy(gameObject);
            }
        }
    }
}
