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

    public GameObject Goal1;
    public GameObject Goal2;

    private void Start()
    {
        Goal1.SetActive(true);
        Goal2.SetActive(false);
        Goal1.GetComponent<Animator>().Play("Goal1");
    }

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
            Goal1.SetActive(false);
            Goal2.SetActive(true);
            Goal2.GetComponent<Animator>().Play("Goal2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 12 && hasReformed)
        {
            winAudio.Play();
            fireWorks.Play();
            Invoke("Win", 2);
            Goal1.SetActive(false);
            Goal2.SetActive(false);
        }
    }

    private void Win()
    {
        
        gui.ActivateWinScreen();
    }
}
