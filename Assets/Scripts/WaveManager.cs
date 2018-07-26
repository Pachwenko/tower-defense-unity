using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {
    public float initialHealth;
    public float waveTimer;
    public float spawnInterval;
    public float spawnIntervalDecreaseBy;
    public float enemyHealthIncreaseBy;
    public GameObject circleEnemy;
    public GameObject squareEnemy;
    public GameObject wavesTextObject;
    public int maxWaves;
    public int enemiesToSpawn;

    private bool gameOver;
    private float healthIncreaseBy;
    private int enemiesSpawned;
    private int waveNumber;
    private int counter;

    // Use this for initialization
    void Start() {
        SetInitialDifficulty();
        healthIncreaseBy = enemyHealthIncreaseBy;
        counter = 2;
        waveNumber = 1;
        gameOver = false;
    }

    IEnumerator CreateEnemies() {
        for (int i = 0; i < enemiesToSpawn + (counter*2); i++) {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    public void SpawnWave() {
        //Debug.Log("SpawnWave called");
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 || gameOver) {
           return;
        }
        counter += 1;
        StartCoroutine(CreateEnemies());
        enemyHealthIncreaseBy += healthIncreaseBy;
        spawnInterval -= spawnIntervalDecreaseBy;
        UpdateWaveText();
    }

    public void setGameOver(bool gameStatus) {
        gameOver = gameStatus;
    }

    private void SpawnEnemy() {
        if ((counter % 2) == 0) { //changes enemy type every other wave
            GameObject instance = Instantiate(circleEnemy);  //TODO: increase enemy health as waves increase
            instance.GetComponent<EnemyBehavior>().setHealth(initialHealth + enemyHealthIncreaseBy);
            enemiesSpawned++;
        } else {
            GameObject instance = Instantiate(squareEnemy);  //TODO: increase enemy health as waves increase
            instance.GetComponent<EnemyBehavior>().setHealth(initialHealth + enemyHealthIncreaseBy);
            enemiesSpawned++;
        }
    }

    private void UpdateWaveText() {
        waveNumber += 1;
        wavesTextObject.GetComponent<Text>().text = "Round \n" + waveNumber + "/" + maxWaves;
    }

    private void SetInitialDifficulty()
    {
        circleEnemy.GetComponent<EnemyBehavior>().setHealth(initialHealth);
        squareEnemy.GetComponent<EnemyBehavior>().setHealth(initialHealth);
    }

}
