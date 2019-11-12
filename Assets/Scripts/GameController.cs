using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// new using statements
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Asteroid Wave settings")]
    public GameObject asteroid;
    public Vector2 spawnValue;
    public int asteroidCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;

    [Header("Enemy Ship Wave Settings")]
    public GameObject enemyShip;
    public Vector2 shipSpawnVal;
    public int shipCount;
    public float shipSpawnWait;
    public float shipWaveWait;

    [Header("Text Options")]
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    [Header("Audio Options")]
    public AudioClip gameOverClip;

    private bool gameOver;
    private bool restart;
    private int score;
    private AudioSource aSource;

    void Start()
    {
        score = 0;
        restart = false;
        gameOver = false;
        aSource = GetComponent<AudioSource>();

        scoreText.text = "";

        UpdateScore();

        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {


                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.x));

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); // wait time between spawning each asteroid
            }
            yield return new WaitForSeconds(waveWait); // delete between each wave


            for (int i = 0; i < shipCount; i++)
            {
                Vector2 spawnPosition = new Vector2(shipSpawnVal.x, Random.Range(-shipSpawnVal.y, shipSpawnVal.x));

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemyShip, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(shipSpawnWait); // wait time between spawning each asteroid
            }
            yield return new WaitForSeconds(shipWaveWait); // delete between each wave

            //Allows the player to restart the game
            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restartText.text = "Press R for restart";
                restart = true;
                break;
            }
        }
    }

    // Update text of score
    void UpdateScore()
    {

        scoreText.text = "Score: " + score;

    }

    // Accepts score vals and calls UpdateScore
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameOver = true;

        //Change clip from background music to game over
        aSource.clip = gameOverClip;
        //Play clip
        aSource.Play();
        aSource.loop = false;
    }


}
