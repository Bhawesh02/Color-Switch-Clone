using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOrb : MonoBehaviour
{
    public PlayerControl playerControl;
    
    public int colorIndex;

    [SerializeField]
    private SpriteRenderer orbSr; 

    // Start is called before the first frame update
    void Start()
    {
        orbSr.color = playerControl.color[colorIndex];        
    }

    
}
