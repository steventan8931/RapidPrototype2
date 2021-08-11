using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    public Rigidbody rigi;
    public float depthbeforeSubmerge = 1f;
    public float displacementAmount = 3f;
    public GameObject watercube;
    public bool inwater = false;
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    private void FixedUpdate()
    {
        // if collide with water layer object

        if (transform.position.y < watercube.transform.position.y )
        {
            float displacementmultiplier = Mathf.Clamp01(-transform.position.y / depthbeforeSubmerge) * displacementAmount;
            rigi.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementmultiplier, 0f), ForceMode.Acceleration);
        }
    }

}
