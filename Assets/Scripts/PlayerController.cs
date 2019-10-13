using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float minX, maxX, minY, maxY;
}

public class PlayerController : MonoBehaviour {

    // Public variables
    public float speed = 5.0f;
    public Boundary boundary;
    public float fireRate = 0.5f;
    public GameObject laser;
    public Transform laserSpawn;

    // Private variables
    private Rigidbody2D rBody;
    private float myTime = 0.0f;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}

    //Call once per frame but inconsistent
    void Update()
    {
        myTime += Time.deltaTime; //DeltaTime represent the amount of time elapsed since the last Update() call
        //myTime= myTime + Time.deltaTime

        if (Input.GetButton("Fire1") && myTime > fireRate)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
            myTime = 0.0f;
        }
    }

    // Called once per frame and is guaranteed to be consistent
    // Used for Physics calculations
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Debug.Log("Horizontal value: " + moveHorizontal + " Vertical value: " + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Debug.Log(movement);

        rBody.velocity = movement * speed;

        // Restrict the player from leaving the play area
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, boundary.minX, boundary.maxX),  // Restrict X to minX and maxX
            Mathf.Clamp(rBody.position.y, boundary.minY, boundary.maxY)); // Restrict Y to minY and maxY
    }
}
