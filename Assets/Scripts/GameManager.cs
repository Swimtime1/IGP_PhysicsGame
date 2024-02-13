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
    public TextMeshProUGUI scoreText, endScoreText;

    // Boolean Variables
    public static bool gameActive, tutActive;

    // Float Variables

    // Integer Variables
    private int score;

    // Script Variables

    // AudioSource Variables

    // AudioClip Variables
    
    // Start is called before the first frame update
    void Start()
    {
        gameActive = false;
        tutActive = false;
        OpenStart();

        score = 0;
        scoreText.text = "Score: 00000" + score;
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
        UpdateScoreText(endScoreText);
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

    // Updates the score
    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreText(scoreText);
    }

    // Updates the score in the UI
    public void UpdateScoreText(TextMeshProUGUI scoreText)
    {
        // pads the score with 0's
        if(score < 10) { scoreText.text = "Score: 00000" + score; }
        else if(score < 100) { scoreText.text = "Score: 0000" + score; }
        else if(score < 1000) { scoreText.text = "Score: 000" + score; }
        else if(score < 10000) { scoreText.text = "Score: 00" + score; }
        else if(score < 100000) { scoreText.text = "Score: 0" + score; }
        else { scoreText.text = "Score: " + score; }
    }

    // Resets the score and the ball
    public void Reset()
    {
        score = 0;
        UpdateScoreText(scoreText);
        StartGame();
    }

    // Restarts the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
