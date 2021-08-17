using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{
    public float m_FloatForce = 5.0f;

    public bool m_TurnedToSteam = false;
    public GameObject m_SteamParticles;
    public HeatPadScr m_Pad;

    private void OnTriggerStay(Collider _other)
    {
        if (m_TurnedToSteam)
        {
            if (_other.GetComponent<CharacterMotor>() != null)
            {
                Vector3 horizontalVelocity = _other.GetComponent<CharacterMotor>().m_Velocity;
                horizontalVelocity.x = 0.0f;
                horizontalVelocity.y = m_FloatForce + transform.localScale.y;

                _other.GetComponent<CharacterMotor>().m_Controller.Move(horizontalVelocity * Time.deltaTime);

                _other.GetComponent<CharacterMotor>().m_Gravity = 1.0f;
                _other.GetComponent<CharacterMotor>().m_Grounded = true;
                _other.GetComponent<CharacterMotor>().m_Animation.ResetTrigger("Jumping");
                _other.GetComponent<CharacterMotor>().m_Animation.SetTrigger("Jumping");
            }
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.GetComponent<CharacterMotor>() != null)
        {
            _other.GetComponent<CharacterMotor>().m_Gravity = 40.0f;
        }
    }

    private void Update()
    {
        if (m_Pad.m_WaterCount >= 10)
        {
            m_SteamParticles.SetActive(true);
            m_TurnedToSteam = true;
        }
        else
        {
            m_SteamParticles.SetActive(false);
        }
    }
}
