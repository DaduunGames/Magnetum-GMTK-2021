using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public Mesh CompleteMagnet;
    public MeshFilter meshfilter;
    public ParticleSystem sparks;
    public Magnet magnet;

    public GUIcontroller gui;

    public AudioSource weldAudio;
    public AudioSource winAudio;

    public ParticleSystem fireWorks;

    bool hasReformed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            meshfilter.mesh = CompleteMagnet;
            magnet.AttractedObjects = new GameObject[0];
            Instantiate(sparks, transform.position, transform.rotation);
            weldAudio.Play();
            hasReformed = true;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 12 && hasReformed)
        {
            winAudio.Play();
            fireWorks.Play();
            Invoke("Win", 2);
        }
    }

    private void Win()
    {
        
        gui.ActivateWinScreen();
    }
}
