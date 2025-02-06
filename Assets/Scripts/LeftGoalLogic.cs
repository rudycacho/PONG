using UnityEngine;

public class LeftGoalLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        transform.parent.GetComponent<GameManager>().LeftGoal(this);
        Destroy(collision.gameObject);
    }
}
