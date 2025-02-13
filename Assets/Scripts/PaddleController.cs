using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class PaddleController : MonoBehaviour
{
    // Reference Paddles and ball
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public GameObject ball;
    
    
    // Speed and Force Settings
    public float maxPaddleSpeed = 1f;
    public float paddleForce = 1f;
    private bool cpuMode = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cpuMode = GameProperties.CPUMode;
        Debug.Log("CPU MODE IS: " + cpuMode);
        ball = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Left Paddle
        float leftMovementAxis = Input.GetAxis("LeftPaddle");
        Transform leftPaddleTransform = leftPaddle.transform;
        
        Vector3 newLeftPaddlePosition = leftPaddleTransform.position + new Vector3(0f,0f, leftMovementAxis * maxPaddleSpeed * Time.deltaTime);
        newLeftPaddlePosition.z = Math.Clamp(newLeftPaddlePosition.z, -7.5f, 7.5f);
        
        leftPaddleTransform.position = newLeftPaddlePosition;
        
        // Right Paddle
        if (!cpuMode)
        {
            float rightMovementAxis = Input.GetAxis("RightPaddle");
            Transform rightPaddleTransform = rightPaddle.transform;
        
            Vector3 newRightPaddlePosition = rightPaddleTransform.position + new Vector3(0f,0f, rightMovementAxis * maxPaddleSpeed * Time.deltaTime );
            newRightPaddlePosition.z = Math.Clamp(newRightPaddlePosition.z, -7.5f, 7.5f);
        
            rightPaddleTransform.position = newRightPaddlePosition;
        }
        else
        {
            if (ball != null)
            {
                Transform rightPaddleTransform = rightPaddle.transform;
                float newBallPosition = ball.transform.position.z;

                if (newBallPosition >= rightPaddleTransform.position.z)
                {
                    Vector3 newRightPaddlePosition = rightPaddleTransform.position + new Vector3(0, 0, 1f  * maxPaddleSpeed * Time.deltaTime );
                    newRightPaddlePosition.z = Math.Clamp(newRightPaddlePosition.z, -7.5f, 7.5f);
                
                    rightPaddleTransform.position = newRightPaddlePosition;
                }
                if (newBallPosition <= rightPaddleTransform.position.z)
                {
                    Vector3 newRightPaddlePosition = rightPaddleTransform.position + new Vector3(0, 0, -1f  * maxPaddleSpeed * Time.deltaTime );
                    newRightPaddlePosition.z = Math.Clamp(newRightPaddlePosition.z, -7.5f, 7.5f);
                
                    rightPaddleTransform.position = newRightPaddlePosition;
                }
            }
        }
    }
}
