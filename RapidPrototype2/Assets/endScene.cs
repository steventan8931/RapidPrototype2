using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScene : MonoBehaviour
{
    public GameObject menuButton, exitbutton;

    public void backtoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
