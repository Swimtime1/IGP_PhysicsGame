using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    // Script Variables
    public GameManager gameManager;
    public GoalController gc1000, gc500, gc100;

    // Float Variables
    private float startX, startY;

    // Rigidbody2D Variables
    public Rigidbody2D rb;

    // AudioSource Variables
    public AudioSource audioSource;

    // AudioClip Variables
    public AudioClip bounce;
    
    // Start is called before the first frame update
    public void Start()
    {
        startX = 3f;
        startY = -1f;
        
        transform.position = new Vector3(startX, startY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Plays a sound on collisions
    void OnCollisionExit2D(Collision2D other)
    {
        audioSource.PlayOneShot(bounce);
    }

    // Called when a collision is detected
    void OnCollisionEnter2D(Collision2D other)
    {
        // ends the game
        if(other.gameObject.CompareTag("Bottom")) { gameManager.OpenEndgame(); }
    }

    // Called when a trigger is entered
    void OnTriggerEnter2D(Collider2D other)
    {
        // checks if the 1000 point goal was triggered
        if(other.gameObject.CompareTag("1000")) { StartCoroutine(gc1000.Trigger()); }

        // checks if the 500 point goal was triggered
        else if(other.gameObject.CompareTag("500")) { StartCoroutine(gc500.Trigger()); }

        // checks if the 100 point goal was triggered
        else if(other.gameObject.CompareTag("100")) { StartCoroutine(gc100.Trigger()); }
    }
}
