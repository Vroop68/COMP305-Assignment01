// DestroyObject.cs - John Knoop - 300835103 - October 25 2019 - This script is used to destroy objects or the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{


    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
