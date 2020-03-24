using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 3f;
    public float currentSpeed;

    void Start()
    {
        currentSpeed = speed;
    }
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * currentSpeed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += 0.05f;
        }
        else
        {
            currentSpeed -= 0.1f;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, speed, 20);
    }
}
