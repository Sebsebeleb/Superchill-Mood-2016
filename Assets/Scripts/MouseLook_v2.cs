using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_v2 : MonoBehaviour
{
    public float mouseSensetivity;

    public Transform playerBody;

    public float xRotation;

    public float yRotation;

    public float mouseX;
    public float mouseY;
    
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;
        
        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0f);
        



        /*mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        
        yRotation = yRotation + mouseX;
        //yRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, yRotation,0f);
        //playerBody.Rotate(Vector3.up * mouseX);
        
        //Grunnen til at det hakker når du beveger kameraet er fordi at vi roterer cylinderen med rigidbody, dette gjør at når dette skjer brekker interpolation
        //Så hvis vi vil fiske det må vi vi gjøre at rotasjonen til kameriet i x aksen må i kameraet selv, ikke rotere cylinderen.*/
    }
}
