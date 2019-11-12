// BoundaryDestroyer.cs - John Knoop - 300835103 - October 21 2019 - This script is used to destory anything which passes the boundary

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
