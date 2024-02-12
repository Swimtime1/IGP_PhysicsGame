using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    // Script Variables
    public GameManager gameManager;

    // Integer Variables
    public int numPoints;

    // ParticleSystem Variables
    public ParticleSystem particles;

    // Boolean Variables
    private bool active;

    // Float Integers
    public float rVal, gVal, bVal;

    // SpriteRenderer Variables
    public SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Deactivates the goal temporarily, and updates the score
    public IEnumerator Trigger()
    {
        // Makes sure the goal is active first
        if(active)
        {
            particles.Play();
            active = false;
            sprite.color = new Color((rVal/255f), (gVal/255f), (bVal/255f), (2f/255f));
            gameManager.UpdateScore(numPoints);
            yield return new WaitForSeconds(2.5f);
            sprite.color = new Color((rVal/255f), (gVal/255f), (bVal/255f));
            active = true;
        }
    } 
}
