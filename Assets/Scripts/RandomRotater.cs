// RandomRotater.cs - John Knoop - 300835103 - October 27 2019 - This script gives asteroids the ability to be rotated at random degrees

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour
{

    public float tumble;


    private Rigidbody2D rBody;


    // Randomly rotates the asteroids
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.angularVelocity = Random.value * tumble;
    }


}
