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


    public string[] colors;
    public Color[] color;

    private void Start()
    {
        int noOfColors = color.Length;
        playerSr.color = color[Random.Range(0,noOfColors - 1)];
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
            Destroy(collision.gameObject);
        }

    }
}
