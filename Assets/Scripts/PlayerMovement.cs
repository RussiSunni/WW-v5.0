using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
    float z;


    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            z = 1f;
        }

        // float x = CrossPlatformInputManager.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        // Vector3 move = transform.right * x + transform.forward * z;

        Vector3 move = transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
