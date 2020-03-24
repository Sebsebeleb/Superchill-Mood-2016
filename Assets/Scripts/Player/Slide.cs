using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Slide : MonoBehaviour
{
    public PhysicMaterial SomeFriction;
    
    public PhysicMaterial ZeroFriction;
    
    public GameObject player;

    public bool groundedSlide;

    public GameObject playerBody;

    private float FOV;

    public bool grounded;

    private GameObject FOVcombine;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //playerBody = GameObject.Find("PlayerBody");
        //FOV = Camera.main.GetComponent<Camera>().fieldOfView;
        //FOVcombine = GameObject.FindWithTag("ScriptManager");
    }

    
    //gjær som at det blir en mindre frame med slowdown.
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //player.GetComponent<CapsuleCollider>().material = ZeroFriction;
            groundedSlide = true;
        }

        grounded = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            //player.GetComponent<CapsuleCollider>().material = ZeroFriction;
            groundedSlide = true;
        }
        grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //player.GetComponent<CapsuleCollider>().material = ZeroFriction; //SomeFriction
        groundedSlide = false;
        grounded = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            //player.GetComponent<CapsuleCollider>().material = ZeroFriction; //SomeFriction
            groundedSlide = false;
        }
        
        
        //Flytter kamera tilbake og ned.

        var lerpSpeed = Time.deltaTime * 10f;
        
        /*if (groundedSlide == true)
        {
            Vector3 slidePos = new Vector3(0f,-0.8f,-1.5f);
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition,slidePos,lerpSpeed);
            
            Quaternion slideRot = Quaternion.Euler(-80f,playerBody.transform.localRotation.y,playerBody.transform.localRotation.z);
            playerBody.transform.localRotation = Quaternion.Lerp(playerBody.transform.localRotation, slideRot, lerpSpeed);

            FOVcombine.GetComponent<FOVCombine>().slideEffect = Mathf.Lerp(FOVcombine.GetComponent<FOVCombine>().slideEffect, FOV + 10f,lerpSpeed);
        }
        if (groundedSlide == false)
        {
            Vector3 standPos = new Vector3(0f,0f,0f);
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition,standPos,lerpSpeed);
            
            Quaternion StandRot = Quaternion.Euler(0f,playerBody.transform.localRotation.y,playerBody.transform.localRotation.z);
            playerBody.transform.localRotation = Quaternion.Lerp(playerBody.transform.localRotation, StandRot, lerpSpeed);
            
            FOVcombine.GetComponent<FOVCombine>().slideEffect = Mathf.Lerp(FOVcombine.GetComponent<FOVCombine>().slideEffect, FOV,lerpSpeed);
        }*/
    }
}
