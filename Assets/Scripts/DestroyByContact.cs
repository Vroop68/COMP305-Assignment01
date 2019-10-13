using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosionAsteroid;
    public GameObject playerExplosion;
    public int scoreValue = 10;


    private GameController gameControllerScript;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameControllerScript.GameOver();
        }
        else
        {
            gameControllerScript.AddScore(scoreValue); // passes score value to AddScore function
        }



        //Instantiate asteroid explosion
        Instantiate(explosionAsteroid, this.transform.position, this.transform.rotation);


        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

}
