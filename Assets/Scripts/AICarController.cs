using UnityEngine;

public class AICarController : MonoBehaviour
{
    public float speed = 10f; // Speed of the car
    public float turnSpeed = 5f; // Steering sensitivity
    public Transform[] waypoints; // Waypoints the car will follow
    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Update()
    {
        // Check if there are waypoints to follow
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to the AI car.");
            return;
        }

        // Calculate direction to the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.y = 0f; // Ensure no vertical movement

        // Move the car forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Rotate towards the current waypoint
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        // Check if the car has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 1f)
        {
            // Move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Loop back to the first waypoint
            }
        }
    }
}
