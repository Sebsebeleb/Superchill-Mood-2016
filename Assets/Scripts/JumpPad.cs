using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("Settings")] public float Force;
    public float Cooldown;
    public Vector3 tweenScale = new Vector3(1,1,1);
    public float tweenIntensity = 1.15f;
    public float tweenDuration = 0.25f;
    
    private float nextReady;
    


    private void OnCollisionEnter(Collision other)
    {
        if (Time.time < nextReady)
        {
            return;
        }
        if (other.rigidbody == null)
        {
            return;
        }
        
        Bounce(other);
        
    }

    private void Bounce(Collision other)
    {
        nextReady = Time.time + Cooldown;

        other.rigidbody.AddForce(transform.forward * Force, ForceMode.Impulse);
        other.rigidbody.AddForce(transform.forward * Force * 0.03f, ForceMode.VelocityChange);

        transform.DOScale(tweenScale * tweenIntensity, tweenDuration).SetLoops(2, LoopType.Yoyo);
    }
}
