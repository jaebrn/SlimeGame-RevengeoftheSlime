using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePads : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float jumpForce = 150;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Bounce();
        }
    }

    void Bounce()
    {
        if(gameObject.tag == "Bounce Pad") // applies to tilemap bounce pads 
        {
            playerRb.AddForce(Vector2.up * jumpForce);
        }
        else
        {
            return;
        }
    }
}
