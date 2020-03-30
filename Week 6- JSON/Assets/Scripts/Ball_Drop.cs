using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Drop : MonoBehaviour
{
    Rigidbody rb; //Rigidbody

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the RigidBody component
        rb.isKinematic = true; //Turn on Kinematic
    }

    private void OnMouseDown() //on clicking the object
    {
        rb.isKinematic = false; //move without physics
    }
}
