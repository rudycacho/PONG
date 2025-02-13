using System;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Audio Clips
    public AudioClip ballBounceSound;
    public AudioClip ballPowerUpSound;
    public new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        // Logs the contact and plays the appropriate sound
        Debug.Log($"Made Contact with {other.gameObject.name}");
        audio.PlayOneShot(ballBounceSound);
        
        // Grabs the rigidbody and manipulates the velocity of the ball.
        Rigidbody rb = GetComponent<Rigidbody>();
        
        float speed = other.relativeVelocity.magnitude;
        
        Vector3 newVelocity = other.relativeVelocity;
        newVelocity = newVelocity.normalized * speed;
        newVelocity.x = -newVelocity.x;

        rb.linearVelocity = newVelocity;
        
        Debug.Log($"Speed: {speed}, newVelocity: {newVelocity}");
        
    }
    
    // Check For Power Ups
    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        
        audio.PlayOneShot(ballPowerUpSound);
        // Wall Power Up
        if (other.gameObject.CompareTag("Big"))
        {
            Debug.Log("Big Ball power up picked up!");
            Destroy(other.gameObject);
            transform.localScale += new Vector3(2f, 0f, 2f);
            Invoke("RevertSize",6.0f);
        }
        // Multi-Ball Power Up
        if (other.gameObject.CompareTag("Slow"))
        {
            Debug.Log("Slow power up picked up!");
            Destroy(other.gameObject);
            rb.linearVelocity /= 2;
        }
    }

    void RevertSize()
    {
        transform.localScale -= new Vector3(2f, 0f, 2f);
    }
}
