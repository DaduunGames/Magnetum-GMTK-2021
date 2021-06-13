using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWSBool : MonoBehaviour
{
    Animator anim;
    public AudioSource source;
    public AudioClip weldClip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetCloseFalse()
    {
        anim.SetBool("Close", false);
    }

    public void playWeld()
    {
        source.PlayOneShot(weldClip);
    }
}
