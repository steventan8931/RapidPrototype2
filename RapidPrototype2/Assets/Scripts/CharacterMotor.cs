﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    public Transform m_Model;

    public Camera m_Camera;

    public CharacterController m_Controller;

    public Vector3 m_Velocity;

    public float m_MoveSpeed = 8.0f;
    public float m_Acceleration = 12.0f;
    public AnimationCurve m_FrictionCurve = AnimationCurve.Linear(0.0f, 0.1f, 1.0f, 1.0f);

    public float m_Gravity = 40.0f;
    public float m_JumpSpeed = 12.0f;

    public float m_PushStrength = 5.0f;

    public bool m_Grounded = false;

    public float m_FacingAngle = 0.0f;

    public AudioSource m_IcePushAudio;
    public AudioSource m_JumpAudio;

    public Animator m_Animation;

    public bool m_WaterCrystalCollected = false;

    private void OnControllerColliderHit(ControllerColliderHit _hit)
    {
        Vector3 horizontalVelocity = m_Velocity;
        horizontalVelocity.y = 0.0f;

        if (_hit.moveDirection.y < -0.3f)
        {
            return;
        }

        if (_hit.collider.GetComponent<Rigidbody>() != null)
        {
            Rigidbody rigid = _hit.collider.GetComponent<Rigidbody>();
            if (horizontalVelocity.x != 0)
            {
                rigid.AddForce(horizontalVelocity * m_PushStrength);
                if (!m_IcePushAudio.isPlaying)
                {
                    m_IcePushAudio.Play();
                }

            }
        }
    }

    public bool ResetZAxis()
    {
        //If the player is pushed off the z axis reset it to 0
        if (transform.position.z > 0)
        {
            m_Controller.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            return(false);
        }
        else if (transform.position.z < 0)
        {
            m_Controller.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            return (false);
        }
        else
        {
            m_Controller.enabled = true;
            return (true);
        }
    }

    public void Update()
    {
        if(!ResetZAxis())
        {
            return;
        }
        
        float x = 0.0f;

        x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && m_Grounded)
        {
            m_Velocity.y = m_JumpSpeed;
            m_JumpAudio.Play();
            m_Animation.ResetTrigger("Jumping");
            m_Animation.SetTrigger("Jumping");
        }

        Vector3 inputMove = new Vector3(x, 0.0f, 0.0f);
        if (inputMove.sqrMagnitude > 1.0f)
        {
            inputMove.Normalize();
        }

        float cacheY = m_Velocity.y;
        m_Velocity.y = 0.0f;

        Vector3 cacheVelocity = m_Velocity;

        m_Velocity += inputMove * m_Acceleration * Time.deltaTime;
        m_Velocity -= m_Velocity.normalized * m_Acceleration * m_FrictionCurve.Evaluate(m_Velocity.magnitude) * Time.deltaTime;

        if (Vector3.Dot(cacheVelocity.normalized, m_Velocity.normalized) < 0.0f)
        {
            m_Velocity.x = 0.0f;
        }

        m_Velocity.y = cacheY;
        m_Velocity.y -= m_Gravity * Time.deltaTime;

        if (m_Velocity.x == 0)
        {
            m_Animation.SetBool("Walking", false);
        }
        else
        {
            m_Animation.SetBool("Walking", true);
        }

        Vector3 trueVelocity = m_Velocity;
        trueVelocity.x *= m_MoveSpeed;

        m_Controller.Move(trueVelocity * Time.deltaTime);

        if (m_Controller.collisionFlags == CollisionFlags.Below)
        {
            m_Velocity.y = -1.0f;
            m_Grounded = true;
        }
        else
        {
            m_Grounded = false;
        }

        //if ((m_Controller.collisionFlags & CollisionFlags.Below) != 0)
        //{
        //    m_Velocity.y = -1.0f;
        //    m_Grounded = true;
        //}
        //else
        //{
        //    m_Grounded = false;
        //}

        if ((m_Controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            m_Velocity.y = -1.0f;
        }

        cacheY = m_Velocity.y;
        m_Velocity.y = 0.0f;
        if (m_Velocity.magnitude > 0.01f)
        {
            float angle = Mathf.Atan2(m_Velocity.x, m_Velocity.z) * Mathf.Rad2Deg;
            m_Model.localEulerAngles = new Vector3(0.0f, angle, 0.0f);
            if (angle < 0)
            {
                m_Model.localScale = new Vector3(-1, 1, 1);
            }
            if (angle > 0)
            {
                m_Model.localScale = new Vector3(1, 1, 1);
            }
            m_FacingAngle = angle;
        }
        m_Velocity.y = cacheY;


    }
}
