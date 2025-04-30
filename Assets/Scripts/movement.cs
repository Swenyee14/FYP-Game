using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public checks controller;
    float horizontalMovement = 0f;
    public float speed = 40f;
    bool jump = false;

    void Update()
    {
       horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, jump);
        jump = false;
        
    }
}
