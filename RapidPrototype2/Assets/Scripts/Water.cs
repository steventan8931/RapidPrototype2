using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float m_FloatForce = 5.0f;

    private void OnTriggerStay(Collider _other)
    {
        Vector3 horizontalVelocity = _other.GetComponent<CharacterMotor>().m_Velocity;
        horizontalVelocity.x = 0.0f;
        horizontalVelocity.y = m_FloatForce + transform.localScale.y;

        _other.GetComponent<CharacterMotor>().m_Controller.Move(horizontalVelocity * Time.deltaTime);

        _other.GetComponent<CharacterMotor>().m_Gravity = 1.0f;
    }

    private void OnTriggerExit(Collider _other)
    {
        _other.GetComponent<CharacterMotor>().m_Gravity = 40.0f;
    }
}
