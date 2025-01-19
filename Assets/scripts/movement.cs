using UnityEngine;

public class movement : MonoBehaviour 
{
    public float speed;

    //get input from player
    //apply movement to sprite
    public Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interactiveLayer;

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

    //     if (IsWalkable(direction) == true) 
    //     {
    //         AnimateMovement(direction);
    //     }

    //     transform.position += direction * speed * Time.deltaTime;
    // 
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
        bool isWalkable = Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer | interactiveLayer) == null;

        // Debug log for walkability
        Debug.Log("Is Walkable: " + isWalkable + " at Position: " + targetPos);

        // Check for collisions at the target position
        return Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectsLayer | interactiveLayer) == null;

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

