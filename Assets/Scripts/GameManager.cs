using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Text Componenets + End Screen
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI winnerText;
    // Public Game Objects
    public GameObject endScreen;
    public GameObject pauseScreen;
    public GameObject[] powerUps;
    public GameObject ball;
    public GameObject gameArea;
    public GameObject paddles;
    
    // Music
    public AudioClip matchMusic;
    public AudioClip endMusic;
    public new AudioSource audio;
    
    // Game Mode Properties
    public static bool PowerUpMode = true;
    public int scoreToWin;
    // Private Variables
    private int leftScore = 0;
    private int rightScore = 0;
    private int roundCount = 0;
    private bool player1Scored = false;
    private List<GameObject> spawnedPowerUps = new List<GameObject>();
    private GameObject gameBall;
    private bool gamePaused = false;
    private bool gameOver = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        audio = GetComponent<AudioSource>();
        PowerUpMode = GameProperties.EnablePowerUps;
        endScreen.SetActive(false);
        pauseScreen.SetActive(false);
        Invoke("SpawnBall",2.0f);
    }
    
    public void LeftGoal(LeftGoalLogic leftGoalLogic)
    {
        // Destroy all power ups on board and multi-balls
        player1Scored = false;
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        rightScoreText.color = Color.yellow;
        leftScoreText.color = Color.white;
        Debug.Log("Right Score: " + rightScore);
        CheckScore();
    }
    public void RightGoal(RightGoalLogic rightGoalLogic)
    {
        player1Scored = true;
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        leftScoreText.color = Color.yellow;
        rightScoreText.color = Color.white;
        Debug.Log("Left Score: " + leftScore);
        CheckScore();
    }
    // Runs after a goal has been made
    void CheckScore()
    {
        if (leftScore >= scoreToWin)
        {
            ClearPowerUps();
            Debug.Log("Game Over, Left Paddle Wins!");
            paddles.SetActive(false);
            gameArea.SetActive(false);
            winnerText.GetComponent<TextMeshProUGUI>().text = "Game Over, Left Paddle Wins!";
            endScreen.SetActive(true);
            audio.Stop();
            audio.PlayOneShot(endMusic);
            gameOver = true;
        }

        else if (rightScore >= scoreToWin)
        {
            ClearPowerUps();
            Debug.Log("Game Over, Right Paddle Wins!");
            paddles.SetActive(false);
            gameArea.SetActive(false);
            winnerText.GetComponent<TextMeshProUGUI>().text = "Game Over, Right Paddle Wins!";
            endScreen.SetActive(true);
            audio.Stop();
            audio.PlayOneShot(endMusic);
            gameOver = true;
        }
        else
        {
            Invoke("SpawnBall",2.0f);
        }

        roundCount++;
    }
    // Logic relating to the ball spawning and who scored last
    void SpawnBall()
    {
        gameBall = Instantiate(ball, this.transform.position, Quaternion.identity);

        paddles.GetComponent<PaddleController>().ball = gameBall;
        
        if (player1Scored)
        {
            gameBall.GetComponent<Rigidbody>().linearVelocity = transform.TransformDirection(new Vector3(1, 0, .25f) * 10.0f);
        }
        if (!player1Scored)
        {
            gameBall.GetComponent<Rigidbody>().linearVelocity = transform.TransformDirection(new Vector3(-1, 0, .25f) * 10.0f);
        }

        if (PowerUpMode)
        {
            if (roundCount % 3 == 0 && roundCount != 0)
            {
                PowerUpSpawn();  
            }
        }

    }

    public void ResetGame()
    {
        // Reset Score + Counter
        gameOver = false;
        leftScore = 0;
        rightScore = 0;
        roundCount = 0;
        leftScoreText.text = "0";
        rightScoreText.text = "0";
        rightScoreText.color = Color.white;
        leftScoreText.color = Color.white;
        // Hide end text
        endScreen.SetActive(false);
        paddles.SetActive(true);
        gameArea.SetActive(true);
        audio.Stop();
        audio.PlayOneShot(matchMusic);
        // Spawn the ball
        SpawnBall();
    }

    void PowerUpSpawn()
    {
        int selection = Random.Range(0, powerUps.Length);
        int randomX = Random.Range(-10, 10);
        int randomz = Random.Range(-7, 7);
        Vector3 spawnPos = new Vector3(randomX, 0.5f, randomz);
        GameObject powerUp = Instantiate(powerUps[selection], spawnPos, Quaternion.identity);
        spawnedPowerUps.Add(powerUp);
    }

    void ClearPowerUps()
    {
        foreach (GameObject powerUp in spawnedPowerUps)
        {
            Destroy(powerUp);
        }
    }

    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Destroy(gameBall);
                SpawnBall();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gamePaused = !gamePaused;
                if (gamePaused)
                {
                    pauseScreen.SetActive(true);
                    paddles.SetActive(false);
                    gameArea.SetActive(false);
                    if (gameBall != null)
                    {
                        gameBall.SetActive(false);
                    }

                    if (spawnedPowerUps != null)
                    {
                        foreach (GameObject powerUp in spawnedPowerUps)
                        {
                            powerUp.SetActive(false);
                        }
                    }
                    audio.Pause();
                    Time.timeScale = 0;
                }
                else
                {
                    pauseScreen.SetActive(false);
                    paddles.SetActive(true);
                    gameArea.SetActive(true);
                    if (gameBall != null)
                    {
                        gameBall.SetActive(true);
                    }
                    if (spawnedPowerUps != null)
                    {
                        foreach (GameObject powerUp in spawnedPowerUps)
                        {
                            powerUp.SetActive(true);
                        }
                    }
                    audio.UnPause();
                    Time.timeScale = 1;
                }
            }
        }
    }
}
