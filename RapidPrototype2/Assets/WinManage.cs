using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinManage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject manager, winText;
    public Animator Black_Screen;

    private void FixedUpdate()
    {
        if(manager.GetComponent<GameState>().m_GameWin == true)
        {
            winText.SetActive(true);
            Black_Screen.SetBool("IsWin", true);
            Invoke("loadEndScene", 2.0f);
        }

    }

    public void loadEndScene()
    {
        SceneManager.LoadScene(2);
    }
}
