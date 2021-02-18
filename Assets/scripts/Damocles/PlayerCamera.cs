using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Transform playerBody; // The players body
    public float mouseSensitivity = 150f;
    private float xRotation = 0f;

    /**
     * Rotates the body and mouse based on the mouse cursor movement.
     * 
     * @param mouseX: float representing the value to increment the body rotation by.
     * @param mouseY: float representing the value to increment the camera rotation by.
     */
    private void rotateBodyAndMouse(float mouseX, float mouseY) {
        xRotation -= mouseY; // Increment the xRotation on the x-axis
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Clamp the rotation value to -90 to 90 so you cant rotate through your body.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate the camera, only need to rotate the x axis, y is gathered from the players body.
        playerBody.Rotate(Vector3.up * mouseX); // Rotate the players body about the y axis.
    }
    
    // Start is called before the first frame update
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor
    }

    // Update is called once per frame
    private void Update() {
        rotateBodyAndMouse(Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime,
            Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);
    }
}
