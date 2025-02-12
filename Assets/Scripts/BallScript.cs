using UnityEngine;

public class BallScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Made Contact with {other.gameObject.name}");
        GetComponent<AudioSource>().Play();
        Rigidbody rb = GetComponent<Rigidbody>();
        
        float speed = other.relativeVelocity.magnitude;
        
        Vector3 newVelocity = other.relativeVelocity;
        newVelocity = newVelocity.normalized * speed;
        newVelocity.x = -newVelocity.x;

        rb.linearVelocity = newVelocity;
        
        Debug.Log($"Speed: {speed}, newVelocity: {newVelocity}");
    }
}
