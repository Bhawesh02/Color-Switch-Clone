using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private float jumpForce ;
    [SerializeField]
    private float bottomScreen = -8.2f;
    [SerializeField]
    private SpriteRenderer playerSr;
    [SerializeField]
    private string playerColorName;
    


    private void Start()
    {
        playerSr.color = gameManager.colorinScene[Random.Range(0, gameManager.colorinScene.Count - 1)];
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
            playerColorName = collision.gameObject.GetComponent<ColorOrb>().colorName;
            Destroy(collision.gameObject);
        }
        
        //Check color of ball not same as that of collided
        else if(!collision.gameObject.CompareTag(playerColorName))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
