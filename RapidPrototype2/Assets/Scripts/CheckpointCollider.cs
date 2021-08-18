using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollider : MonoBehaviour
{
    public bool m_Collided = false;
    public Material m_CurrentMat;
    public Material m_NewMat;
    public float m_Timer = 0.0f;
    public GameObject m_Light;

    public AudioSource m_Audio;

    private void OnTriggerEnter(Collider _other)
    {
        if(_other.tag == "Player" && !m_Collided)
        {
            _other.GetComponent<CheckpointRespawn>().m_CheckPoint++;
            m_Collided = true;
            m_Audio.Play();
        }
    }

    private void Update()
    {
        if (m_Collided)
        {
            m_Timer += Time.deltaTime;
            GetComponent<Renderer>().material.Lerp(m_CurrentMat, m_NewMat, m_Timer); 
            if (m_Timer > 0.5f)
            {
                m_Light.SetActive(true);
            }
        }
    }
}
