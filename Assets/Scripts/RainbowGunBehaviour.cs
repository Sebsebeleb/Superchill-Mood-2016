using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowGunBehaviour : MonoBehaviour
{
    public float Force, Radius;

    private ParticleSystem ps;
    private List<ParticleCollisionEvent> collisionEvents;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

     
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);
        foreach (var pEvent in collisionEvents)
        {
            var rb = pEvent.colliderComponent?.GetComponent<Rigidbody>();
            if (rb == null)
            {
                continue;
            }

            Vector3 pos = pEvent.intersection;
            foreach (Collider hit in Physics.OverlapSphere(pos, Radius))
            {
                if (hit.attachedRigidbody != null)
                {
                    hit.attachedRigidbody.AddExplosionForce(Force, pos, Radius, 1, ForceMode.Impulse);
                }
            }
        }
        
        //other.GetComponent<Rigidbody>()?.AddForce(Vector3.up * Force, ForceMode.Impulse);
    }
}
