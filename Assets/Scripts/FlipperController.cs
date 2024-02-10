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

    // AudioSource Variables
    public AudioSource lAudio, rAudio;

    // AudioClip Variables
    public AudioClip swoosh;

    // Boolean Variables
    private bool lUp, rUp;

    // Start is called before the first frame update
    void Start()
    {
        force = 100f;
        lUp = false;
        rUp = false;
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

            // Plays a swooshing sound when the flipper first goes up
            if(!lUp)
            {
                lAudio.PlayOneShot(swoosh);
                lUp = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            lHinge.useMotor = true;
            lrb.AddForce(-transform.up * force, ForceMode2D.Impulse);
            lUp = false;
        }

        // Adds Force to right Flipper
        if(Input.GetKey(KeyCode.D))
        {
            rHinge.useMotor = false;
            rrb.AddForce(transform.up * force, ForceMode2D.Impulse);

            // Plays a swooshing sound when the flipper first goes up
            if(!rUp)
            {
                rAudio.PlayOneShot(swoosh);
                rUp = true;
            }
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            rHinge.useMotor = true;
            rrb.AddForce(-transform.up * force, ForceMode2D.Impulse);
            rUp = false;
        }
    }
}
