using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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

    /*void OnCollisionEnter(Collision other)
    {
        var paddleBounds = GetComponent<BoxCollider>().bounds;
        float maxPaddleHeight = paddleBounds.max.z;
        float minPaddleHeight = paddleBounds.min.z;
        
        float pctHeight = (other.transform.position.z - minPaddleHeight) / (maxPaddleHeight - minPaddleHeight);
        float bounceDirection = (pctHeight - 0.5f) / 0.5f;
        Debug.Log($"pct {pctHeight} + bounceDir {bounceDirection}");
        
        Vector3 currentVelocity = other.relativeVelocity;
        float newSign = -Math.Sign(currentVelocity.x);
        float newRotSign = -newSign;
        
        float newSpeed = currentVelocity.magnitude * 1.1f;
        
        Vector3 newVelocity = new Vector3(newSign, 0f, 0f) * newSpeed;
        newVelocity = Quaternion.Euler(0f, newRotSign * 60f * bounceDirection, 0f) * newVelocity;
        other.rigidbody.linearVelocity = newVelocity;
        
    }*/
}
