using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator anim;
    public Interactable[] Interactables;

    public AudioSource openDoor;
    public AudioSource lever;

    public bool OneTimeToggle = false;
    private bool ToggledOnce = false;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 8)
        {
            if (OneTimeToggle == false)
            {
                activate();
            }
            else if (ToggledOnce == false)
            {
                ToggledOnce = true;
                activate();
            }
        }
    }

    void activate()
    {
        anim.SetBool("On", !anim.GetBool("On"));
        foreach (Interactable item in Interactables)
        {
            item.Activate();
            openDoor.Play();
            lever.Play();
        }
    }
}
