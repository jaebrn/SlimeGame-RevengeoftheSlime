using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePads : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float jumpForce;

    public Vector2 bouncePadVector;
    public float bounceTimerMax = 0.5f;

    private void Start()
    {
        if (gameObject.tag == "Bounce Pad")
        {
            jumpForce = 150;
        }
        else
        {
            jumpForce = 35;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Flat, tilemap bounce pads
        if(gameObject.tag == "Bounce Pad" && collision.gameObject.tag == "Player")
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("bounce pad");
        }
        else
        {
            bouncePadVector = transform.up;
        }
        
        
    }
}
