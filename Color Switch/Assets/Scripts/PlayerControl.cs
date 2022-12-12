using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private float jumpForce ;
    [SerializeField]
    private float bottomScreen = -8.2f;
    [SerializeField]
    private SpriteRenderer playerSr;
    [SerializeField]
    private int playerColorIndex;
    

    public string[] colors;
    public Color[] color;

    private void Start()
    {
        int noOfColors = color.Length;
        playerColorIndex = Random.Range(0, noOfColors - 1);
        playerSr.color = color[playerColorIndex];
    }
    // Update is called once per frame
    void Update()
    {
        //Jump on input
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
            Jump(jumpForce);


        //jump is reached botom of screen
        if (transform.position.y <= bottomScreen)
            Jump(jumpForce / 2); 

    }

    void Jump(float forc)
    {
        playerRb.velocity = (Vector2.up * forc);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collided with color orb change color of player
        if (collision.gameObject.CompareTag("Color-Orb"))
        {
            playerSr.color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            playerColorIndex = collision.gameObject.GetComponent<ColorOrb>().colorIndex;
            Destroy(collision.gameObject);
        }
        
        //Check color of ball same as that of collided
        if(collision.gameObject.CompareTag(colors[playerColorIndex]))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
