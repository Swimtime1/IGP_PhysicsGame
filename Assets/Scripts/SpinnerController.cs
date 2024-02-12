using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    // Rigidbody2D Variables
    public Rigidbody2D rb;

    // Float Variables
    private float angVel;

    // AudioSource Variables
    public AudioSource aud;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angVel = rb.angularVelocity;
        angVel /= 750f;

        aud.pitch = angVel > 0.5f ? angVel : 0.5f;
        aud.volume = angVel;
    }

    // Called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        aud.Play();
    }
}
