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
    public GameObject gameOverText, endScore, replayButton, mainMenuButton;

    // TextMeshProUGUI Variables
    public TextMeshProUGUI scoreText, endScoreText;

    // Boolean Variables
    public static bool gameActive, tutActive;
    private bool keyDown;

    // Integer Variables
    private int score;

    // BoxCollider2D Variables
    public BoxCollider2D leverWall;

    // SpriteRenderer Variables
    public SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        gameActive = false;
        tutActive = false;
        OpenStart();

        gameOverText.SetActive(false);
        endScore.SetActive(false);
        replayButton.SetActive(false);
        mainMenuButton.SetActive(false);

        score = 0;
        scoreText.text = "Score: 00000" + score;
    }

    // Gives control over to the Player
    public void StartGame()
    {
        OpenGameUI();
        leverWall.isTrigger = true;
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // allows keyDown to not be returned to false the moment a key is lifted
        if(Input.anyKeyDown) { keyDown = true; }
        
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
        StartCoroutine(DisplayEndgame());
    }

    // Shows the Endgame Menu little-by-little
    IEnumerator DisplayEndgame()
    {
        keyDown = false;
        
        // skips the wait if a key has been pressed
        if(!keyDown) { yield return new WaitForSeconds(0.5f); }

        // Display Game Over text
        gameOverText.SetActive(true);

        // skips the wait if a key has been pressed
        if(!keyDown) { yield return new WaitForSeconds(0.5f); }

        // Counts up score in UI
        endScore.SetActive(true);
        for(int i = 0; (i < score) && (!keyDown); i++)
        {
            UpdateScoreText(endScoreText, i);
            UpdateScoreColor(endScoreText, i);
            yield return new WaitForSeconds(0.01f);
        }
        UpdateScoreText(endScoreText, score);
        UpdateScoreColor(endScoreText, score);

        // skips the wait if a key has been pressed
        if(!keyDown) { yield return new WaitForSeconds(0.5f); }

        // Displays buttons at bottom
        replayButton.SetActive(true);
        mainMenuButton.SetActive(true);
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
        UpdateScoreText(scoreText, score);
    }

    // Updates the score in the UI
    public void UpdateScoreText(TextMeshProUGUI scoreText, int numDisplay)
    {
        // pads the score with 0's
        if(numDisplay < 10) { scoreText.text = "Score: 00000" + numDisplay; }
        else if(numDisplay < 100) { scoreText.text = "Score: 0000" + numDisplay; }
        else if(numDisplay < 1000) { scoreText.text = "Score: 000" + numDisplay; }
        else if(numDisplay < 10000) { scoreText.text = "Score: 00" + numDisplay; }
        else if(numDisplay < 100000) { scoreText.text = "Score: 0" + numDisplay; }
        else { scoreText.text = "Score: " + numDisplay; }
    }

    // Updates the end score's color in the UI
    public void UpdateScoreColor(TextMeshProUGUI scoreText, int numDisplay)
    {
        if(numDisplay < 100) { scoreText.color = new Color((255f), (255f), (255f)); }
        else if(numDisplay < 500) { scoreText.color = new Color((119f/255f), (255f/255f), (255f/255f)); }
        else if(numDisplay < 1000) { scoreText.color = new Color((0f/255f), (255f/255f), (83f/255f)); }
        else if(numDisplay < 10000) { scoreText.color = new Color((255f/255f), (255f/255f), (0f/255f)); }
        else { scoreText.color = new Color((226f/255f), (0f/255f), (255f/255f)); }
    }

    // Resets the score and the ball
    public void Reset()
    {
        score = 0;
        UpdateScoreText(scoreText, score);
        UpdateScoreText(endScoreText, score);
        UpdateScoreColor(endScoreText, score);

        gameOverText.SetActive(false);
        endScore.SetActive(false);
        replayButton.SetActive(false);
        mainMenuButton.SetActive(false);

        StartGame();
    }

    // Restarts the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Sets the Lever Wall to a collider
    public void AltLeverWall()
    {
        leverWall.isTrigger = false;
    }
}
