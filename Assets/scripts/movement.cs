using UnityEngine;

public class movement : MonoBehaviour 
{
    public float speed;

    //get input from player
    //apply movement to sprite
    public Animator animator;

    public LayerMask solidObjectsLayer;

    private void Update () 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        if (direction.magnitude > 0) 
        {
            if (IsWalkable(direction)) 
            {
                transform.position += direction * speed * Time.deltaTime;
                AnimateMovement(direction);
            }
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
        Vector3 targetPos = transform.position + direction * speed * Time.deltaTime;

        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null) 
        {
            return false;
        }
        return true;
    }
}

