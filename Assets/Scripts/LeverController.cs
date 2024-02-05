using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    // Float Variables
    float yRoof, yFloor;
    float xPos, yPos;
    float pullBack;

    // Vector3 Variables
    Vector3 mousePos;

    // Collider2D Variables
    Collider2D target;
    public Collider2D lever;

    // Rigidbody2D Variables
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        yRoof = -2f;
        yFloor = -3.356f;
        xPos = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        yPos = transform.position.y;
        
        // Ensures lever doesn't go above yRoof
        if(yPos > yRoof)
        { transform.position = new Vector3(xPos, yRoof, 0); }
        
        MoveLever();
        Release();
    }

    // Moves the lever with the mouse
    void MoveLever()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Ensures mouse button is being pressed
        if (Input.GetMouseButton(0))
        {
            target = Physics2D.OverlapPoint(mousePos);
            
            // Moves the lever if the mouse is overlapping
            if (target == lever)
            {
                // Ensures mousePos isn't out of bounds
                if((mousePos.y <= yRoof) && (mousePos.y >= yFloor))
                { transform.position = new Vector3(xPos, mousePos.y, 0); }
                else if(mousePos.y > yRoof)
                { transform.position = new Vector3(xPos, yRoof, 0); }
                else { transform.position = new Vector3(xPos, yFloor, 0); }
            }
        }
    }

    // Shoots the ball by returning the lever to start with force
    void Release()
    {
        // Ensures mouse button was just released
        if (Input.GetMouseButtonUp(0))
        {
            pullBack = (yRoof - yPos) * 10f;
            rb.velocity = new Vector3(0f, pullBack, 0f);
        }
        else if(yPos == yRoof)
        { rb.velocity = new Vector3(0f, 0f, 0f); }
    }
}
