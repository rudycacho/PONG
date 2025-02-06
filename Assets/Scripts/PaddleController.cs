using System;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Reference Paddles
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    
    // Speed and Force Settings
    public float maxPaddleSpeed = 1f;
    public float paddleForce = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        float rightMovementAxis = Input.GetAxis("RightPaddle");
        Transform rightPaddleTransform = rightPaddle.transform;
        
        Vector3 newRightPaddlePosition = rightPaddleTransform.position + new Vector3(0f,0f, rightMovementAxis * maxPaddleSpeed * Time.deltaTime);
        newRightPaddlePosition.z = Math.Clamp(newRightPaddlePosition.z, -7.5f, 7.5f);
        
        rightPaddleTransform.position = newRightPaddlePosition;
        
    }
}
