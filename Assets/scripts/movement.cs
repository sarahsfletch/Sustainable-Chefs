using UnityEngine;

public class movement : MonoBehaviour 
{
    public float speed;

    //get input from player
    //apply movement to sprite

    private void Update () 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical);

        transform.position += direction * speed * Time.deltaTime;
    }
}

