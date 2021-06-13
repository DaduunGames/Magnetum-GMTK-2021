using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToTrigger : MonoBehaviour
{
    public Animator GUIAnim;
    public Animator HowToAnim;

    public void AnimsEnable()
    {
        GUIAnim.SetBool("Triggered", true);
        HowToAnim.SetBool("Triggered", true);
    }

    public void AnimsDisable()
    {
        GUIAnim.SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }
}
