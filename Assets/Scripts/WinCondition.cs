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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(collision.gameObject);
            meshfilter.mesh = CompleteMagnet;
            magnet.AttractedObjects = new GameObject[0];
            Instantiate(sparks, transform.position, transform.rotation);

            Invoke("Win", 1);
        }
    }

    private void Win()
    {
        gui.ActivateWinScreen();
    }
}
