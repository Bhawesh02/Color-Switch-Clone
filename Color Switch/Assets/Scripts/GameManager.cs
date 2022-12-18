using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Color> colorinScene;
    private Camera mainCamera;
    private GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        ScanColor();
    }
    // Update is called once per frame
    void Update()
    {

        // Deactivate and activate objects visible in the scene
        foreach(GameObject obstacle in obstacles)
        {
            if(Mathf.Abs(obstacle.transform.position.y - mainCamera.transform.position.y) <= mainCamera.orthographicSize + 5f)

            {
                obstacle.SetActive(true);
            }
            else
                obstacle.SetActive(false);

        }
    }

    //gets different color present in the scene
    void ScanColor()
    {
        
        foreach (GameObject obstacle in obstacles)
        {
            Color[] colorInObstacle = obstacle.gameObject.GetComponent<Rotator>().colorsPresent;
            foreach (Color color in colorInObstacle)
            {
                colorinScene.Add(color);
            }
        }
    }
}
