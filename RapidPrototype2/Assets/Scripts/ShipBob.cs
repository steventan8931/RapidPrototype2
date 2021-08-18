using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBob : MonoBehaviour
{
    public float m_BobSpeed = 5.0f;
    public float m_YOrigin = 3.95f;
    private void Update()
    {
        float YPos = Mathf.Sin(Time.time * m_BobSpeed) + m_YOrigin;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, YPos, transform.position.z);
    }
}
