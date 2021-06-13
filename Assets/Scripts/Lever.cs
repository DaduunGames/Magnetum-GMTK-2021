using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator anim;
    public Interactable[] Interactables;

    public AudioSource openDoor;
    public AudioSource lever;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 8)
        {
            anim.SetBool("On", !anim.GetBool("On"));
            foreach(Interactable item in Interactables)
            {
                item.Activate();
                openDoor.Play();
                lever.Play();
            }
        }
    }
}
