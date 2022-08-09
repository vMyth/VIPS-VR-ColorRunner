using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 200f;
    private Rigidbody player;

    public FloatingJoystick floatJoystick;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Touch Movement
        Vector3 direction = Vector3.forward*floatJoystick.Vertical + Vector3.right*floatJoystick.Horizontal;
        player.AddForce(direction * force * Time.fixedDeltaTime, ForceMode.VelocityChange);

        // Keyboard Movement
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(force*Time.deltaTime,0f,0f,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(-force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
    }
}
