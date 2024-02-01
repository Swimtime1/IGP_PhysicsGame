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

    // Float Variables
    private float startX, startY;
    
    // Start is called before the first frame update
    void Start()
    {
        startX = 3f;
        startY = -1f;
        
        transform.position = new Vector3(startX, startY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
