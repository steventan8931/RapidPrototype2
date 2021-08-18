using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRespawn : MonoBehaviour
{
    public Transform[] m_Checkpoints;
    public int m_CheckPoint;
    public AudioSource m_Audio;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GetComponent<CharacterMotor>().m_Gravity > 1)
        {
            if (!m_Audio.isPlaying)
            {
                m_Audio.Play();
            }
            GetComponent<CharacterController>().enabled = false;
            transform.position = m_Checkpoints[m_CheckPoint - 1].position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
