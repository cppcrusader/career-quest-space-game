using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public BoxCollider2D collider;
    public Rigidbody2D rb;

    public float scrollSpeed = 2f;

    public bool scrollToLeft = true;

    private float width;
    private float scrollDirection = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //gets the collider from the object we're attached to
        collider = GetComponent<BoxCollider2D>();

        //get the rigidbody from the object we're attached to
        rb = GetComponent<Rigidbody2D>();

        //set width to the x size of the collider
        width = collider.size.x;

        //disable the collider as we no longer need it
        collider.enabled = false;
        
        //if scrollToLeft is true, set the direction to -1
        if(scrollToLeft)
        {
            scrollDirection = -1f;
        }

        //set the velocity to a vector using our scrollSpeed and scrollDirection
        rb.velocity = new Vector2((scrollDirection * scrollSpeed), 0);
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the background has gone past the width in the scrollDirection
        //reset the background so it will continue scrolling on screen
        if(transform.position.x < (width * scrollDirection))
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
