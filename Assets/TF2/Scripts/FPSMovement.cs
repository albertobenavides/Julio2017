using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour {

    Rigidbody rb;
    public float force;
    public float velocity;
    bool isJumping;

	void Start () {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && !isJumping) {
            rb.AddForce(Vector3.up * force);
            isJumping = true;
        }

        
        rb.velocity = new Vector3(
            Input.GetAxis("Horizontal") * velocity,
            rb.velocity.y,
            Input.GetAxis("Vertical") * velocity
        );

        transform.Rotate(
            0,
            Input.GetAxis("Mouse X"),
            0
        );
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Terrain")) {
            isJumping = false;
        }
    }
}
