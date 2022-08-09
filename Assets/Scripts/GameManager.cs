using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static Color[] colors = new Color[4];

    public GameObject obstaclePrefab;
    public Transform obstacles;

    public static float score;
    public TextMeshProUGUI scoreTextUI;

    float t = 0;

    private void Awake()
    {
        colors[0] = Color.blue;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = Color.yellow;
    }
    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 3f);
    }

    private void Update()
    {
        scoreTextUI.text = score.ToString();

        
        t += Time.deltaTime;
        if (t >= 1)
        {
            score += 1;
            t = 0;
        }
    }

    public void InitiateDeath()
    {
        CancelInvoke("Spawn");

        FindObjectOfType<PlayerController>().enabled = false;

        foreach (Transform obstacle in obstacles)
        {
            obstacle.gameObject.GetComponent<ObstacleMovement>().enabled = false;
        }
    }

    private void Spawn()
    {
        int i;
        for (i = -6; i < 6; i += 6)
        {
            Instantiate(obstaclePrefab, new Vector3(Mathf.Floor(Random.Range(i,i+6)), 1.5f, 110), Quaternion.identity, obstacles);  
        }
    }
}
