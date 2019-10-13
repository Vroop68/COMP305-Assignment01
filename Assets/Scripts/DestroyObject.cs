using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    // This script is used to destroy objects or the player
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
