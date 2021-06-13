using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIcontroller : MonoBehaviour
{
    public GameObject WinScreen;
    private Animator WsAnim;
    public GameObject WsMagnets;

    public GameObject GoalTip;

    int sceneIndex;



    private void Start()
    {
        GoalTip.SetActive(true);
        WinScreen.SetActive(false);

        WsAnim = WsMagnets.GetComponent<Animator>();
    }

    public void ActivateWinScreen()
    {
       
        GoalTip.SetActive(false);
        WinScreen.SetActive(true);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", true);
    }
    public void DeactivateWinScreen()
    {
        
        GoalTip.SetActive(false);
        WinScreen.SetActive(false);
        WinScreen.GetComponent<Animator>().SetBool("Triggered", false);
    }

    public void TriggerWinScreenMagnets(Transform obj)
    {
        WsMagnets.transform.position = obj.position;
        WsAnim.SetBool("Close",true);
    }

    public void MoveWinScreenMagnets(Transform obj)
    {
        if (!WsAnim.GetBool("Close")) 
        {
            WsMagnets.transform.position = obj.position;
        }
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
