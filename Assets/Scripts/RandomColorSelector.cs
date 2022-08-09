using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorSelector : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = GameManager.colors[Random.Range(0, GameManager.colors.Length)];
    }
}
