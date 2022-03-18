using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePads : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float jumpForce = 150;

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
            playerRb.AddForce(this.transform.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Angled BP");
        }
        
        
    }
}
