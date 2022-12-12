using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // speed with which to move the gameObject forwards
    public float speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // always move the gameObject forwards every frame
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
