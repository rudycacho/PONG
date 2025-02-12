using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public GameObject statusText;

    public GameObject leftGoal;
    public GameObject rightGoal;
    public GameObject ball;

    public int scoreToWin;
    private int leftScore = 0;
    private int rightScore = 0;
    
    private bool player1Scored = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        statusText.SetActive(false);
        Invoke("SpawnBall",2.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftGoal(LeftGoalLogic leftGoalLogic)
    {
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
            Debug.Log("Game Over, Left Paddle Wins!");
            statusText.GetComponent<TextMeshProUGUI>().text = "Game Over, Left Paddle Wins!";
            statusText.SetActive(true);
            Invoke("ResetGame", 2.0f);
        }

        else if (rightScore >= scoreToWin)
        {
            Debug.Log("Game Over, Right Paddle Wins!");
            statusText.GetComponent<TextMeshProUGUI>().text = "Game Over, Right Paddle Wins!";
            statusText.SetActive(true);
            Invoke("ResetGame", 2.0f);
        }
        else
        {
            Invoke("SpawnBall",2.0f);
        }
    }
    // Logic relating to the ball spawning and who scored last
    void SpawnBall()
    {
        GameObject gameBall = Instantiate(ball, this.transform.position, Quaternion.identity);

        if (player1Scored)
        {
            gameBall.GetComponent<Rigidbody>().linearVelocity = transform.TransformDirection(new Vector3(1, 0, 0.5f) * 10.0f);
        }
        if (!player1Scored)
        {
            gameBall.GetComponent<Rigidbody>().linearVelocity = transform.TransformDirection(new Vector3(-1, 0, 0.5f) * 10.0f);
        }
    }

    void ResetGame()
    {
        // Reset Score + Counter
        leftScore = 0;
        rightScore = 0;
        leftScoreText.text = "0";
        rightScoreText.text = "0";
        rightScoreText.color = Color.white;
        leftScoreText.color = Color.white;
        // Hide end text
        statusText.SetActive(false);
        // Spawn the ball
        SpawnBall();
    }
}
