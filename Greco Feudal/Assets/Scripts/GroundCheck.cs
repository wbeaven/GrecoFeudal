using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool grounded;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
            grounded = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
            grounded = false;
    }
}
