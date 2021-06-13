using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIcontroller : MonoBehaviour
{
    public GameObject WinScreen;
    private Animator WsMagAnim;
    public GameObject WsMagnets;

    public GameObject PauseScreen;
    private Animator pMagAnim;
    public GameObject pMagnets;

    public Animator HowToAnim;

    public Animator GUI;

    int sceneIndex;

    bool isPaused;

    public AudioSource aSource;
    public AudioClip Hover;
    public AudioClip Pressed;

    private void Start()
    {
        WsMagAnim = WsMagnets.GetComponent<Animator>();
        pMagAnim = pMagnets.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
               
                DeactivatePauseScreen();
            }
            else
            {
                
                ActivatePauseScreen();
            }
           
        }
    }

    public void ActivateWinScreen()
    {
        GUI.SetBool("Triggered", true);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", true);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }
    public void DeactivateWinScreen()
    {
        GUI.SetBool("Triggered", false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }

    

    public void ActivatePauseScreen()
    {
        isPaused = true;
        GUI.SetBool("Triggered", true);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", true);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }
    public void DeactivatePauseScreen()
    {
        isPaused = false;
        GUI.SetBool("Triggered", false);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }

    public void ActivateHowTo()
    {
        isPaused = false;
        GUI.SetBool("Triggered", true);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", true);
    }
    public void DeactivateHowTo()
    {
        isPaused = false;
        GUI.SetBool("Triggered", false);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }

    public void TriggerWinScreenMagnets(Transform obj)
    {
        WsMagnets.transform.position = obj.position;
        WsMagAnim.SetBool("Close",true);
        aSource.PlayOneShot(Pressed);
    }

    public void MoveWinScreenMagnets(Transform obj)
    {
        if (!WsMagAnim.GetBool("Close")) 
        {
            WsMagnets.transform.position = obj.position;
            aSource.PlayOneShot(Hover);
        }

    }

    public void TriggerPauseMagnets(Transform obj)
    {
        pMagnets.transform.position = obj.position;
        pMagAnim.SetBool("Close", true);
        aSource.PlayOneShot(Pressed);
    }

    public void MovePauseMagnets(Transform obj)
    {
        if (!pMagAnim.GetBool("Close"))
        {
            pMagnets.transform.position = obj.position;
            aSource.PlayOneShot(Hover);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        aSource.PlayOneShot(clip);
    }

    public void LoadScene(int index)
    {
        sceneIndex = index;
        Invoke("Scene", 0.25f);
    }
    private void Scene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void LoadUrl(string url)
    {
        Application.OpenURL(url);
    }
}
