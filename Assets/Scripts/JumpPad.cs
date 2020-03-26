using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("Settings")] public float Force;
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody == null)
        {
            return;
        }
        
        other.rigidbody.AddForce(transform.forward * Force, ForceMode.Impulse);
        other.rigidbody.AddForce(transform.forward * Force * 0.03f, ForceMode.VelocityChange);
    }
}
