using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private bool isAttached = false; // To track if the cube is attached to the stationary box.

    void Update()
    {
        if (!isAttached)
        {
            // Get input from arrow keys
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate the movement direction
            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

            // Normalize the movement vector to prevent faster diagonal movement
            movement.Normalize();

            // Move the cube based on input
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

    // Called when a trigger collider (e.g., the sphere collider) is entered
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stationary"))
        {
            isAttached = true;
            transform.SetParent(other.transform); // Attach the cube to the stationary box
        }
    }
}
