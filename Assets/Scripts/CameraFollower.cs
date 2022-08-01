using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    public int axis;

    private void Update()
    {
        Vector3 newPos;

        newPos = transform.position;
        newPos[axis] = player.position[axis];

        transform.position = newPos;    
    }
}
