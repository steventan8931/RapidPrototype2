using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenCtrl : MonoBehaviour
{
    public GameObject manager, wintext;
    public Animator black_start;

    // Update is called once per frame
    void Update()
    {
        if(manager.GetComponent<GameState>().m_GameWin == true)
        {
            black_start.SetBool("IsStart", true);
            wintext.SetActive(true);
        }    
    }
}
