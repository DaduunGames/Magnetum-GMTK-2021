using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public Mesh CompleteMagnet;
    public MeshFilter meshfilter;
    public ParticleSystem sparks;
    public Magnet Nmagnet;

    public GUIcontroller gui;

    public AudioSource weldAudio;
    public AudioSource winAudio;

    public ParticleSystem fireWorks;

    bool hasReformed = false;

    public GameObject Goal1;
    public GameObject Goal2;

    public Transform SMTransform;

    public float collisionDist;
    float timer = 0;

    public GameObject CameraAnchor;

    private void Start()
    {
        Goal1.SetActive(true);
        Goal2.SetActive(false);
        Goal1.GetComponent<Animator>().Play("Goal1");
    }

    private void FixedUpdate()
    {
        if (SMTransform) 
        {
            if (Vector3.Distance(SMTransform.position, transform.position) <= collisionDist)
            {
                Invoke("CheckAgain", 0.1f);
            }
        }
    }

    private void CheckAgain()
    {
        if (SMTransform)
        {
            if (Vector3.Distance(SMTransform.position, transform.position) <= collisionDist)
            {
                Destroy(SMTransform.gameObject);
                Weld();
            }
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

    private void Weld()
    {
        meshfilter.mesh = CompleteMagnet;
        Nmagnet.AttractedObjects = new GameObject[0];
        CameraAnchor.GetComponent<Magnet>().AttractedObjects = new GameObject[1];
        CameraAnchor.GetComponent<Magnet>().AttractedObjects[0] = Nmagnet.gameObject;
        Instantiate(sparks, transform.position, transform.rotation);
        weldAudio.Play();
        hasReformed = true;
        Goal1.SetActive(false);
        Goal2.SetActive(true);
        Goal2.GetComponent<Animator>().Play("Goal2");
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, collisionDist / 2);
    }
}
