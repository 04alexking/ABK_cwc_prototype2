using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // bounds for position before destruction
    private float topBoundZ = 30;
    private float lowerBoundZ = -15;
    private float topBoundX = 20;
    private float lowerBoundX = -20;

    // Update is called once per frame
    void Update()
    {
        // check if gameObject is above the topBound for Z
        if (transform.position.z > topBoundZ) {
            Destroy(gameObject);
        } else if (transform.position.z < lowerBoundZ) { // check if gameObject is below the lowerBound for Z
            // this is a Game Over Condition!
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
        // check if gameObject is above the topBound for X
        if (transform.position.x > topBoundX) {
            Destroy(gameObject);
        } else if (transform.position.x < lowerBoundX) { // check if gameObject is below the lowerBound for X
            Destroy(gameObject);
        }
    }
}
