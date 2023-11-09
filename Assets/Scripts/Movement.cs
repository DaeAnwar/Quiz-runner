using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 5f;    // player movement speed
    public float xLimit = 5f;       // x-axis limit for player movement

    private float mouseX;           // current mouse x position

    private void Update()
    {
        // Get the current mouse position
        mouseX = Input.mousePosition.x;

        // Convert the mouse position to world space
        float mousePositionInWorld = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0f, 0f)).x;

        // Clamp the player's x position to the x-axis limits
        float clampedXPosition = Mathf.Clamp(transform.position.x, -xLimit, xLimit);

        // Move the player left or right based on the mouse position
        float moveDirection = Mathf.Sign(mousePositionInWorld - clampedXPosition);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, 0f, 0f);
    }

    private void FixedUpdate()
    {
        // Move the player forward continuously
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
    }
}

