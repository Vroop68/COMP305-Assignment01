using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour
{
    //If anything gets past the border it is destroyed
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

}
