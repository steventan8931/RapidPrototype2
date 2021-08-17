using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameState m_State;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.GetComponent<CharacterMotor>() != null)
        {
            m_State.m_GameWin = true;
        }
    }
}
