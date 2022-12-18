using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOrb : MonoBehaviour
{
    public PlayerControl playerControl;

    private GameObject[] obstacles;
    private GameObject nextObstacle;
    public int colorIndex;
    public string colorName;

    [SerializeField]
    private SpriteRenderer orbSr; 

    // Find the closest obstacle above it and get a random color from it
    void Awake()
    {

        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        float min = 999f;
        foreach (GameObject obstacle in obstacles)
        {
            if((obstacle.transform.position.y > transform.position.y) && ((obstacle.transform.position.y - transform.position.y)<min))
            {
                min = obstacle.transform.position.y - transform.position.y;
                nextObstacle = obstacle;
            }
        }
        Debug.Log(nextObstacle.gameObject.GetComponent<Rotator>().colorsPresent.Length);
        colorIndex = Random.Range(0, nextObstacle.gameObject.GetComponent<Rotator>().colorsPresent.Length - 1);
        orbSr.color = nextObstacle.gameObject.GetComponent<Rotator>().colorsPresent[colorIndex];
        colorName = nextObstacle.gameObject.GetComponent<Rotator>().colorsPresentNames[colorIndex];
    }

    
}
