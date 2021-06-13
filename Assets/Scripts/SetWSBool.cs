using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWSBool : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetCloseFalse()
    {
        anim.SetBool("Close", false);
    }
}
