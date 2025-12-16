using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public Vector3 pointA = new (-5, 0, 0); // Start position
    public Vector3 pointB = new (5, 0, 0);  // End position
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        // Start moving towards pointB
        target = pointB;
    }

    void Update()
    {
        // Move towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // If reached target, switch to the other point
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}

