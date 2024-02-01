using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    // GameObject Variables
    public GameObject startMenu, inGameUI, instructionsMenu, endgameMenu;
    public GameObject obstacles, ball;

    // Sprite Variables

    // TextMeshProUGUI Variables

    // Boolean Variables
    public static bool gameActive, tutActive;

    // Float Variables

    // Integer Variables

    // Script Variables

    // AudioSource Variables

    // AudioClip Variables
    
    // Start is called before the first frame update
    void Start()
    {
        gameActive = false;
        tutActive = false;
        OpenStart();
    }

    // Gives control over to the Player
    public void StartGame()
    {
        OpenGameUI();
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Closes the Tutorial Menu
        if(tutActive && Input.anyKeyDown)
        {
            tutActive = false;
            StartGame();
        }
    }

    // Deativates all of the UI so that a specific menu can be opened
    public void CloseMenus()
    {
        startMenu.SetActive(false);
        inGameUI.SetActive(false);
        instructionsMenu.SetActive(false);
        endgameMenu.SetActive(false);
    }

    // Opens the Start Menu
    public void OpenStart()
    {
        DisableObjects();
        CloseMenus();
        startMenu.SetActive(true);
    }

    // Opens the Instructions Menu
    public void OpenTutorial()
    {
        CloseMenus();
        instructionsMenu.SetActive(true);
        tutActive = true;
    }

    // Opens the In-Game UI Menu
    public void OpenGameUI()
    {
        ActivateObjects();
        CloseMenus();
        inGameUI.SetActive(true);
    }

    // Opens the Endgame Menu
    public void OpenEndgame()
    {
        gameActive = false;
        DisableObjects();
        CloseMenus();
        endgameMenu.SetActive(true);
    }

    // Deactivates GameObjects in the scene that aren't part of the Canvas
    public void DisableObjects()
    {
        obstacles.SetActive(false);
        ball.SetActive(false);
    }

    // Activates GameObjects in the scene that aren't part of the Canvas
    public void ActivateObjects()
    {
        obstacles.SetActive(true);
        ball.SetActive(true);
    }
}
