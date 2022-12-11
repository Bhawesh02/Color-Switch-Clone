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

            Destroy(collision.gameObject);
        }

    }
}
