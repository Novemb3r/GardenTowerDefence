using UnityEngine;

public class Waypoints : MonoBehaviour {

    public Transform[] waypoints;
    public static Transform[] points;
    public static int waypointIndex = 0;

    void Update()
    {
        points = new Transform[waypoints[waypointIndex].childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = waypoints[waypointIndex].GetChild(i);
        }
    }
}
