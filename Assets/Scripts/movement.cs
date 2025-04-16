using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public checks controller;
    float horizontalMovement = 0f;
    public float speed = 40f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
       horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
}
