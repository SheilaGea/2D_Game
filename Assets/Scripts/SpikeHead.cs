using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float waypoint1Speed = 2f; // Speed for Waypoint 1
    [SerializeField] private float waypoint2Speed = 1f; // Speed for Waypoint 2
    [SerializeField] private float waitTime = 2f; // Wait time at Waypoint 2

    private void Update()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        float currentSpeed = GetCurrentSpeed();
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * currentSpeed);

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            StartCoroutine(WaitForNextWaypoint());
        }
    }

    private float GetCurrentSpeed()
    {
        return (currentWaypointIndex == 0) ? waypoint1Speed : waypoint2Speed;
    }

    private IEnumerator WaitForNextWaypoint()
    {
        yield return new WaitForSeconds(waitTime);

        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }
}
