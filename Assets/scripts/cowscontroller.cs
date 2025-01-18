using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// public class cowscontroller : MonoBehaviour, Interactable
// {
//     public void Interact()
//     {
//         Debug.Log("Feed me!!!!!");
//     }
// }


// Declare the Interactable interface if it's not already declared


public class CowsController : MonoBehaviour, Interactive
{
    public void Interact()
    {
        Debug.Log("Feed me!!!!!");
    }
}

