using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRespawn : MonoBehaviour
{
    public Transform[] m_Checkpoints;
    public int m_CheckPoint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = m_Checkpoints[m_CheckPoint - 1].position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
