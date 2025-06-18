using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManger : MonoBehaviour
{
    public GameObject[] fishPrefab;
    public Vector2 spawnRateRange;
    float spanTimer;

    public Text scoreText;
    int Score;


    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            SpawnNewFish();
        }
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        spanTimer -= Time.deltaTime;

        if(spanTimer < 0)
        {
            SpawnNewFish();
            spanTimer=Random.Range(spawnRateRange.x,spawnRateRange.y);
        }
    }

    void SpawnNewFish()
    {
        GameObject fishToSpawn = fishPrefab[Random.Range(0, fishPrefab.Length)];
        int dir = Random.value > 0.5f ? 1 : -1;
        Vector2 randomSpawnPos = new Vector2(dir * 7f, Random.Range(-4.7f, 4.7f));

        GameObject fish=Instantiate(fishToSpawn,randomSpawnPos,Quaternion.identity);
        fish.GetComponent<Finsh>().SpawnFish();


        if (dir == 1)
        
            fish.transform.Rotate(Vector3.up, 180f);
        
    }

    public void GainScore(int amount)
    {
        Score += amount;
        string zero = "00000";

        scoreText.text = zero.Substring(0, zero.Length - Score.ToString().Length) + Score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
