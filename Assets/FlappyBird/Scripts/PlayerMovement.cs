using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;
    public Vector3 jumpForce = new Vector3(0, 1, 0); // Es lo mismo que Vector3.Up

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")) {
            rb.velocity = Vector3.zero;
            rb.AddForce(jumpForce);
        }

        transform.Rotate(Vector3.forward, rb.velocity.y);

        if (transform.rotation.eulerAngles.z < 30) {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                30
            );
        } else if (transform.rotation.eulerAngles.z > 105) {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                105
            );
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0) {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GameOver();
    }

    void GameOver() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
