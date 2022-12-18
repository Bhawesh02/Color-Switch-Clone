using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed ;


    public Color[] colorsPresent;
    public string[] colorsPresentNames;
    // Update is called once per frame
    void Awake()
    {
        rotationSpeed = Random.Range(80f,120f);
    }
    void Update()
    {
        transform.Rotate(0,0, rotationSpeed * Time.deltaTime);

    }
}
