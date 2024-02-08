using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    // Rigidbody2D Variables
    public Rigidbody2D lrb, rrb;

    // Float Variables
    public float force;

    // HingeJoint2D Variables
    public HingeJoint2D lHinge, rHinge;

    // Start is called before the first frame update
    void Start()
    {
        force = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyForce();
    }

    // Applies force to the flipper
    void ApplyForce()
    {
        // Adds Force to left Flipper
        if(Input.GetKey(KeyCode.A))
        {
            lHinge.useMotor = false;
            lrb.AddForce(transform.up * force, ForceMode2D.Impulse);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            lHinge.useMotor = true;
            lrb.AddForce(-transform.up * force, ForceMode2D.Impulse);
        }

        // Adds Force to right Flipper
        if(Input.GetKey(KeyCode.D))
        {
            rHinge.useMotor = false;
            rrb.AddForce(transform.up * force, ForceMode2D.Impulse);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            rHinge.useMotor = true;
            /* rrb.AddForce(-transform.up * force, ForceMode2D.Impulse); */
        }
    }
}
