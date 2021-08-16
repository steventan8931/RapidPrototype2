using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuscr : MonoBehaviour
{
    GameObject startbutton, exitbutton;
    public Animator transistion;
    public void StartGame()
    {
        transistion.SetTrigger("IsStart");
        print("trigger activated");
        //Invoke("loadGameScene", 0.5f);
    }
     
    public void loadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
