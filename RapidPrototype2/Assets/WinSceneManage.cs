using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinSceneManage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MenuButton, exitButton;
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
