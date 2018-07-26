using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject livesTextObject;
    public GameObject moneyTextObject;
    public GameObject gameOverButtonText;
    public int lives;
    public int money;

    private WaypointHolder firstPoint;
    private Vector3 spawnPosition;


    // Use this for initialization
    void Start() {
        gameOverButtonText.SetActive(false);
        firstPoint = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<WaypointHolder>();
        spawnPosition = firstPoint.waypoints[0].position;
        UpdateLives(0);
        MoneyWithdrawlOrDeposit(0);
    }

    // Update is called once per frame
    void Update() {

    }

    public void InstantiateGameObject(GameObject objectToInstantiate) {
        GameObject clone = Instantiate(objectToInstantiate);
        clone.transform.position = spawnPosition;
        clone.SetActive(true);
    }

    /// <summary>
    /// Subtracts the number given to the number of lives left
    /// </summary>
    /// <param name="livesLost"> The amount of lives lost </param>
    public void UpdateLives(int livesLost) {
        lives -= livesLost;
        livesTextObject.GetComponent<Text>().text = "" + lives;
        if (lives < 0) {
            GameOver();
            Debug.Log("End of the game reached");
        }
    }

    /// <summary>
    /// Simply pass a positive number to increase the value of money, and a negative value to decrease it. If a negative value is passed it will check if there is enough and return bool accordingly.
    /// </summary>
    /// <param name="numMoneys"> The amount of money to add or subtract</param>
    /// <returns> returns true if the balance of money doesnt go negative, and false if it does. </returns>
    public bool MoneyWithdrawlOrDeposit(int numMoneys) {
        if ((money + numMoneys) > 0) {
            money += numMoneys;
            moneyTextObject.GetComponent<Text>().text = "" + money;
            return true;
        } else {
            //wwhatever calls this and decreases money value needs to handle this
            return false;
        }
    }

    public void GameOver() {
        gameOverButtonText.SetActive(true);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<WaveManager>().setGameOver(true);
    }
}
