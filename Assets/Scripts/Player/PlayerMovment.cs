using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float Walkspeed;

    public float runSpeed;
    
    private float currentSpeedLimiter;

    public float jumpforce;

    private Rigidbody rb;

    public GameObject Grounded;

    public float getAxisAnim;

    [Space(20)]
    [Tooltip("Hvor mye som spilleren kan dytte seg selv i luften")]
    public float airMoveForce;
    
    void Start()
    { 
        rb = gameObject.GetComponent<Rigidbody>();
        Grounded = GameObject.Find("[Empty] Grounded");
    }


    private Vector3 direction;
    private void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && Grounded.GetComponent<Slide>().grounded == true)
        {
            rb.AddForce(0f, jumpforce,0f,ForceMode.Impulse);
        }
        
        //setter hva current speed Limiter skal være

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeedLimiter = runSpeed;
        }
        else
        {
            currentSpeedLimiter = Walkspeed;
        }

        float x = Input.GetAxis("Horizontal") * currentSpeedLimiter;
        float y = Input.GetAxis("Vertical") * currentSpeedLimiter;

        

        var forward = Camera.main.transform.forward;
        forward = new Vector3(forward.x, 0, forward.z).normalized;
        forward = forward * y;

        var right = Camera.main.transform.right;
        right = new Vector3(right.x, 0, right.z).normalized;
        right = right * x;

        direction = forward + right;

        
        //Camera.main.GetComponent<Animator>().SetBool("Walk",false);

        if (GameObject.Find("[Empty] Grounded").GetComponent<Slide>().grounded && GameObject.Find("[Empty] Grounded").GetComponent<Slide>().groundedSlide == false)
        {
            direction.y = rb.velocity.y;
            rb.velocity = direction;
        }

        if (GameObject.Find("[Empty] Grounded").GetComponent<Slide>().grounded == false || GameObject.Find("[Empty] Grounded").GetComponent<Slide>().groundedSlide)
        {
            //Camera.main.GetComponent<Animator>().SetBool("Walk",false);
            //Camera.main.GetComponent<Animator>().speed = 1f;
            return;
        }
        
        
        if (x <= getAxisAnim && x >= 0f && y <= getAxisAnim && y >= 0f)
        {
            //Debug.Log("IsIdle");
            //Camera.main.GetComponent<Animator>().SetBool("Walk",false);
            //Camera.main.GetComponent<Animator>().speed = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            //Camera.main.GetComponent<Animator>().SetBool("Walk",true);
            //Camera.main.GetComponent<Animator>().speed = 2f;
        }
        else
        {
            //Camera.main.GetComponent<Animator>().SetBool("Walk",true);
            //Camera.main.GetComponent<Animator>().speed = 1f;
        }
        
        direction = new Vector3(direction.x,0f,direction.z);
    }

    [Tooltip("Sier hvor fort spilleren kan bevege seg og fortsatt påvirke farten sin")]
    public float moveMaxAirSpeed;
    void FixedUpdate()
    {
        if (GameObject.Find("[Empty] Grounded").GetComponent<Slide>().grounded == false &&
            new Vector3(rb.velocity.x,0,rb.velocity.z).magnitude < moveMaxAirSpeed)
        {
            rb.AddForce(direction * airMoveForce,ForceMode.Force);
        }
    }
}
