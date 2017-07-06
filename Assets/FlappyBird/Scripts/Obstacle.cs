using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private void Start() {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + Random.Range(-2.0f, 2.0f),
            transform.position.z
        );
    }

    private void FixedUpdate() { // Diferencia entre Update y FixedUpdate
        transform.position = new Vector3(
            transform.position.x - 0.1f,
            transform.position.y,
            transform.position.z
        );
    }
}
