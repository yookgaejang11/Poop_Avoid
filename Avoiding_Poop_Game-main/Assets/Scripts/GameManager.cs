using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject Poop;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject gameOverSet;


    public float GameTime = 0;
    public Text Stopwatchtext;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        Stopwatchtext.text = "Time\n" + (int)GameTime;


        curSpawnDelay += Time.deltaTime;
        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnPoop();
            maxSpawnDelay = Random.Range(0.2f, 0.4f);
            curSpawnDelay = 0;
        }

    void SpawnPoop()
        {
            int ranPoop = Random.Range(0, 1);
            int ranPoint = Random.Range(0, 9);
            Instantiate(Poop,
                        spawnPoints[ranPoint].position,
                        spawnPoints[ranPoint].rotation);
        }

       

    }

    public void GameOver()
    {
        
        gameOverSet.SetActive(true);
        Time.timeScale = 0f;
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(0);
        
    }
}
