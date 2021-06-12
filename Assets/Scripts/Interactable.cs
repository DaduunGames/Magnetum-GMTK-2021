using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Animator anim;
    public virtual void Activate()
    {
        anim.SetBool("Activated", !anim.GetBool("Activated"));
    }
}
