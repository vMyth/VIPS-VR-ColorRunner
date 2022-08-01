using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 200f;
    private Rigidbody player;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Keyboard Movement
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.AddForce(force*Time.deltaTime,0f,0f,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(-force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
    }
}
