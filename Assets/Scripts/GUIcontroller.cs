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

    public GameObject ContinueGameButton;
    public GameObject Settings;

    private void Start()
    {
        WsMagAnim = WsMagnets.GetComponent<Animator>();
        pMagAnim = pMagnets.GetComponent<Animator>();

        WinScreen.SetActive(false);
        PauseScreen.SetActive(false);
        HowToAnim.gameObject.SetActive(false);
        GUI.gameObject.SetActive(true);
        Settings.SetActive(false);

        if (ContinueGameButton)
        {
            ContinueGameButton.SetActive(false);

            if (PlayerPrefs.GetInt("CurrentScene", 1) > 1)
            {
                ContinueGameButton.SetActive(true);
            }
        }

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
        WinScreen.SetActive(true);
        PauseScreen.SetActive(false);
        HowToAnim.gameObject.SetActive(false);
        GUI.gameObject.SetActive(false);
        Settings.SetActive(false);

        GUI.SetBool("Triggered", true);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", true);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }
    public void DeactivateWinScreen()
    {
        WinScreen.SetActive(false);
        PauseScreen.SetActive(false);
        HowToAnim.gameObject.SetActive(false);
        GUI.gameObject.SetActive(true);
        Settings.SetActive(false);

        GUI.SetBool("Triggered", false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }

    

    public void ActivatePauseScreen()
    {
        WinScreen.SetActive(false);
        PauseScreen.SetActive(true);
        HowToAnim.gameObject.SetActive(false);
        GUI.gameObject.SetActive(false);
        Settings.SetActive(false);

        isPaused = true;
        GUI.SetBool("Triggered", true);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", true);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }
    public void DeactivatePauseScreen()
    {
        Invoke("DeactivatePause", 0.25f);
    }

    void DeactivatePause()
    {
        WinScreen.SetActive(false);
        PauseScreen.SetActive(false);
        HowToAnim.gameObject.SetActive(false);
        GUI.gameObject.SetActive(true);
        Settings.SetActive(false);

        isPaused = false;
        GUI.SetBool("Triggered", false);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", false);
    }

    public void ActivateHowTo()
    {
        WinScreen.SetActive(false);
        PauseScreen.SetActive(false);
        HowToAnim.gameObject.SetActive(true);
        GUI.gameObject.SetActive(false);
        Settings.SetActive(false);

        isPaused = false;
        GUI.SetBool("Triggered", true);
        PauseScreen.GetComponent<Animator>().SetBool("Triggered", false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
        HowToAnim.SetBool("Triggered", true);
    }
    public void DeactivateHowTo()
    {
        WinScreen.SetActive(false);
        PauseScreen.SetActive(false);
        HowToAnim.gameObject.SetActive(false);
        GUI.gameObject.SetActive(true);
        Settings.SetActive(false);

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

    public void NextLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Invoke("scene", 0.25f);
    }

    public void LoadScene(int index)
    {
        sceneIndex = index;
        Invoke("scene", 0.25f);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("CurrentScene");
        sceneIndex = 1;
        Invoke("scene", 0.25f);
    }

    public void Continue()
    {
        sceneIndex = PlayerPrefs.GetInt("CurrentScene", 1);
        Invoke("scene", 0.25f);
    }
    private void scene()
    {
        if (sceneIndex != 0) PlayerPrefs.SetInt("CurrentScene", sceneIndex);
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

    public void ActivateSettings()
    {
        WinScreen.SetActive(false);
        PauseScreen.SetActive(false);
        HowToAnim.gameObject.SetActive(false);
        GUI.gameObject.SetActive(false);
        Settings.SetActive(true);
    }
}
