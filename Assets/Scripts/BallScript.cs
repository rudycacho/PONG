using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(0f, 1f, 0f);
        Quaternion posRotation = Quaternion.Euler(45f, 0f, 0f);
        Quaternion negRotation = Quaternion.Euler(-45f, 0f, 0f);

        Vector3 posVector = posRotation * up;
        Vector3 negVector = negRotation * up;
        
        /*Debug.DrawRay(transform.position, posVector, Color.red);
        Debug.DrawRay(transform.position, negVector, Color.green);*/
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Made Contact with {collision.gameObject.name}");
        
        Rigidbody rb = GetComponent<Rigidbody>();
        
        float speed = collision.relativeVelocity.magnitude;
        float newSpeed = speed * 1.1f;
        
        Vector3 newVelocity = Vector3.Reflect(rb.linearVelocity, collision.contacts[0].normal);
        newVelocity = newVelocity.normalized * newSpeed;
        
        rb.linearVelocity = newVelocity;
    }
}
