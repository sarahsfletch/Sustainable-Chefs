using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Movement : MonoBehaviour 
{
    public float speed;

    //get input from player
    //apply movement to sprite
    public Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask InteractiveLayer;

    private void Update () 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        // Debug log for input direction
        Debug.Log("Input Direction: " + direction);

        if (direction.magnitude > 0) 
        {
            if (IsWalkable(direction)) 
            {
                transform.position += direction * speed * Time.deltaTime;

                Debug.Log("Sprite moved to: " + transform.position);
            }
            
            AnimateMovement(direction);

        }
        else 
        {
            AnimateMovement(Vector3.zero);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Sprite clicked!");
            
            Interact();
        }

        //OnMouseDown();

        // if (Input.GetKeyDown(KeyCode.Z)) 
        // {
        //     Debug.Log("Z key pressed!");

        //     Interact();
        // }

    //     if (IsWalkable(direction) == true) 
    //     {
    //         AnimateMovement(direction);
    //     }

    //     transform.position += direction * speed * Time.deltaTime;
    // 
    }

    // void OnMouseDown()
    // {
    //     // Debug message to confirm the sprite was clicked
    //     Debug.Log("Sprite clicked!");

    //     // Call your interaction logic
    //     Interact();
    // }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("horizontal"), animator.GetFloat("vertical"));
         // Set a default direction if facingDir is zero
        if (facingDir == Vector3.zero)
        {
            facingDir = new Vector3(1, 0); // Default to right
        }

        var interactPos = transform.position + facingDir;

        Debug.Log("facingDir:" + facingDir);

        Debug.Log("interactPos" + interactPos);

        //Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, InteractiveLayer);

        if (collider != null) 
        {
            Debug.Log("there is a cow here!");
        }
    }
    void AnimateMovement(Vector3 direction)
    {   
        if (animator != null)
        {
            if (direction.magnitude > 0) 
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);

            }
            else 
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

    private bool IsWalkable(Vector3 direction) 
    {
        // Predict the next position based on direction
        Vector3 targetPos = transform.position + direction * speed * Time.deltaTime;

        // Check for collisions at the target position
        bool isWalkable = Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer | InteractiveLayer) == null;

        // Debug log for walkability
        Debug.Log("Is Walkable: " + isWalkable + " at Position: " + targetPos);

        // Check for collisions at the target position
        return Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer | InteractiveLayer) == null;

        // sad old code
        // Vector3 targetPos = transform.position + direction * speed * Time.deltaTime;

        // if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactiveLayer) != null) 
        // {
        //     return false;
        // }
        // return true;
    }

    // void Interact()
    // {
    //     float horizontal = Input.GetAxisRaw("Horizontal");
    //     float vertical = Input.GetAxisRaw("Vertical");

    //     Vector3 direction = new Vector3(horizontal, vertical);

    //     Vector3 interactPos = transform.position + direction * speed * Time.deltaTime;

    //     var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactiveLayer);
    //     if (collider != null)
    //     {
    //         collider.GetComponent<Interactive>()?.Interact();
    //     }
    // }
}

