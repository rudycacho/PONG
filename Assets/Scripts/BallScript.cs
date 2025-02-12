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
    /*void OnTriggerEnter(Collider other)
    {
        audio.PlayOneShot(ballPowerUpSound);
        // Wall Power Up
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall power up picked up!");
            Destroy(other.gameObject);
        }
        // Multi-Ball Power Up
        if (other.gameObject.CompareTag("Multi"))
        {
            Debug.Log("Multi-Ball power up picked up!");
            GameObject multiBall = GameObject.Instantiate(this.gameObject);
            multiBall.transform.position = new Vector3(0, 0, 0); //this.transform.position;
            multiBall.transform.rotation = this.transform.rotation;
            multiBall.GetComponent<Rigidbody>().linearVelocity = this.GetComponent<Rigidbody>().linearVelocity;
            Destroy(other.gameObject);
        }
    }*/
}
