﻿using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject livesTextObject;
    public GameObject moneyTextObject;


    private WaypointHolder firstPoint;
    private Vector3 spawnPosition;
    public int lives;
    public int money;

    // Use this for initialization
    void Start() {
        firstPoint = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<WaypointHolder>();
        spawnPosition = firstPoint.waypoints[0].position;
    }

    // Update is called once per frame
    void Update() {

    }

    public void InstantiateGameObject(GameObject objectToInstantiate) {
        GameObject clone = Instantiate(objectToInstantiate);
        clone.transform.position = spawnPosition;
        clone.SetActive(true);
    }

    public void UpdateLives(int livesLost) {
        lives -= livesLost;
        livesTextObject.GetComponent<Text>().text = "" + lives;
        if (lives < 0) {
            //TODO: END THE GAME
            Debug.Log("End of the game reached");
        }
    }

    /// <summary>
    /// Simply pass a positive number to increase the value of money, and a negative value to decrease it. If a negative value is passed it will check if there is enough and return bool accordingly.
    /// </summary>
    /// <param name="numMoneys"></param>
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
}