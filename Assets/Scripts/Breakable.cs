using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float Health;

    public ParticleSystem particles;

    public AudioSource breakAudio;

    private void Update()
    {
        if(Health <= 0)
        {
            Instantiate(particles, transform.position, transform.rotation);
           
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            breakAudio.Play();
            Health--;
        }
    }
}
