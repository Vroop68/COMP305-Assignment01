// AsteroidController.cs - John Knoop - 300835103 - October 21 2019 - This script controls asteroids movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    //This script is used to cause the asteroids to move
    // Public Variables
    public float speed;

    // Private variables
    private Rigidbody2D rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
    }
}
