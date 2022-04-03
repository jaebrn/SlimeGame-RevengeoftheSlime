using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerCurrent : MonoBehaviour
{

    //Variables 
    private Rigidbody2D rb;
    public float moveSpeed;
    private float moveInput;
    //see void flip \/
    private bool facingRight = true;

    //transform is for x,y coordinate of check to see if overlap is on terrain (public because a different script needs to see the x,y coordinates
    private bool OnTerrain;
    public Transform TerrainCheck;
    public float checkRadius;
    public LayerMask whatisTerrain; // lets you select in inspector what layer counts as ground

    //Jumping
    public float jumpForce;
    private float jumpTimerMax;
    public float jumpTime;
    private bool isJumping;

    //Spawns, Checkpoints, Level ends
    private Vector2 respawnPoint;
    public Vector2 initialPosition;

    //Bounce Pads
    private Vector2 bouncePadVector; // force applied to player from bp
    private float bouncePadJumpForce;
    public bool isBouncing = false;
    public float bounceTime;
    public float bounceTimerMax;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = this.transform.position;
        initialPosition = respawnPoint;
        bouncePadVector = new Vector2(0, 0);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        OnTerrain = Physics2D.OverlapCircle(TerrainCheck.position, checkRadius, whatisTerrain);

    }

    void Update()
    {

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (OnTerrain == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimerMax = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimerMax > 0)
            {
                rb.velocity = new Vector2 (rb.velocity.x, Vector2.up.y * jumpForce);
                jumpTimerMax -= Time.deltaTime;
            }
            else
            {
                isJumping = false;

            }
        }

        // likely a better version of the freeze would involve setting the rb type to kenematic
        //then back to dynamic on button release
        if (OnTerrain == true && Input.GetKey(KeyCode.LeftControl))
        {

            isJumping = false;
            jumpTimerMax = jumpTime;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0,0);

        }

        else
        {
            rb.gravityScale = 5;
            rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);
        }

        

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (isBouncing == true)
        {
            if (bounceTime > 0)
            {
                bounceTime -= Time.deltaTime;
                rb.velocity = bouncePadVector * bouncePadJumpForce;
            }
            else
            {
                bouncePadVector = new Vector2(0, 0);
                bouncePadJumpForce = 0;
                isBouncing = false;

            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.position = respawnPoint;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.transform.position = initialPosition;
        }
    }
    

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // kills
        if (collision.gameObject.tag == "Hazard")
        {
            transform.position = respawnPoint;
            Debug.Log("ouch");
        }

        //Checkpoint
        else if (collision.gameObject.tag == "Checkpoint")
        {
            respawnPoint = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 1) ;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Angled Bounce Pad")
        {
            isBouncing = true;
            bounceTimerMax = collision.gameObject.GetComponent<BouncePads>().bounceTimerMax;
            bounceTime = bounceTimerMax;
            bouncePadVector = collision.gameObject.GetComponent<BouncePads>().bouncePadVector.normalized;
            bouncePadJumpForce = collision.gameObject.GetComponent<BouncePads>().jumpForce;
        }
        else if (collision.gameObject.tag == "Moving Platform")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moving Platform")
        {
            this.transform.parent = null;
        }
    }


}