using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public float FireRate;

    private float nextShootTime;

    [SerializeField] private ParticleSystem flamethrowerParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextShootTime)
        {
            nextShootTime = Time.time + FireRate;

            flamethrowerParticles.Emit(1);
        }
    }
}
