using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 20f;

    public AudioSource audioPlay;

    public AudioClip clipGameOver;
    public AudioClip clipPass;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        audioPlay = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        this.transform.Translate(Vector3.back*Time.deltaTime*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if(this.gameObject.GetComponent<Renderer>().material.color == player.GetComponent<Renderer>().material.color)
                {
                    audioPlay.clip = clipPass;
                    StartCoroutine(PlayAudio());
                    GameManager.score += 1;
                    player.GetComponent<Renderer>().material.color = GameManager.colors[Random.Range(0, GameManager.colors.Length)];
                    
                }
                else
                {
                    audioPlay.clip = clipGameOver;
                    StartCoroutine(PlayAudio());
                    FindObjectOfType<GameManager>().InitiateDeath();
                }
                break;
            case "ObstacleWall":
                Destroy(this.gameObject);
                break;
        }
    }

    IEnumerator PlayAudio()
    {
        audioPlay.Play();
        yield return new WaitForSeconds(audioPlay.clip.length);
        Destroy(this.gameObject);
    }
}
