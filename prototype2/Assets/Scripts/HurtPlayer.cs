using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        // check if the other gameObject has the "Player" tag
        if (other.gameObject.tag == "Player") {
            // GAME OVER!
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
