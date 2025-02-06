using UnityEngine;

public class RightGoalLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        transform.parent.GetComponent<GameManager>().RightGoal(this);
        Destroy(collision.gameObject);
    }
}
