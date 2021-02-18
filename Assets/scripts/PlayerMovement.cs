using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public CharacterController controller;
    
    private float movementSpeed = 6f;
    private float velocity = 0f;
    private float gravity = -9.811f;
    private float jumpHeight = 1f;
    private bool isOnGround = false;

    // Update is called once per frame
    private void Update() {
        isOnGround = controller.isGrounded;
        if (isOnGround && velocity < 0) {
            velocity = 0f;
        }
        
        var movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        controller.Move(movement * movementSpeed * Time.deltaTime);

        if (isOnGround && Input.GetKeyDown(KeyCode.Space)) {
            velocity += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        
        velocity += gravity * Time.deltaTime;
        controller.Move(new Vector3(0,velocity * Time.deltaTime,0));

    }
}
