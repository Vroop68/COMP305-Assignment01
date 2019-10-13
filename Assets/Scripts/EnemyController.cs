using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //This script is used to cause the asteroids to move
    // Public Variables
    public float speed;
    private float myTime = 0.0f;

    public float fireRate = 0.5f;
    public GameObject laser;
    public Transform laserSpawn;

    // Private variables
    private Rigidbody2D rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        myTime += Time.deltaTime;
        if (Time.time > this.fireRate && myTime > fireRate)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
            myTime = 0.0f;
        }
    }


    void EnemyShooting()
    {
        //test
    }
}

