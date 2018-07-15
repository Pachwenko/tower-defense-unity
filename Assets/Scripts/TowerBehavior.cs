using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Class to be inherited by the Towers. Used to set various propertys and perhaps do some functions.
/// 
/// </summary>
public class TowerBehavior : MonoBehaviour {
    public float towerDamage = 1f;
    //May appear not to work if enemy's health is too high and/or towerDamage is too low
    public int cost;
    public GameObject projectilePrefab;
    public float spawnTimer;

    private float spawnTimerReset;
    private Collider2D firstEnemy;

    // Use this for initialization
    void Start() {
        spawnTimerReset = spawnTimer;

    }

    // Update is called once per frame
    void Update() {
        SendDamage();
        spawnTimer -= Time.deltaTime;


    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            if (firstEnemy == null) {
                firstEnemy = other;
            }
        }
        //Debug.Log("hey I'm in your collider");
    }

    public void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            if (firstEnemy == null) {
                firstEnemy = other;
            }
        }
        //Debug.Log("Sent damage: " + towerDamage * Time.deltaTime);
    }

    public void OnTriggerExit2D(Collider2D other) {
        firstEnemy = null;
        //Debug.Log("Sent damage: " + towerDamage * Time.deltaTime);
    }

    public int getCost() {
        return cost;
    }

    private void SendDamage() {
        if (firstEnemy != null) {
            firstEnemy.SendMessage("AddDamage", towerDamage * Time.deltaTime);
            fireProjectile();
        }
    }

    private void fireProjectile() {
        if (spawnTimer < 0 && firstEnemy != null) {
            spawnTimer = spawnTimerReset;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            Vector3 dir = firstEnemy.gameObject.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            projectile.GetComponent<Rigidbody>().AddForce(transform.right * 1000.0f);
            Destroy(projectile, 1.0f);
        }
    }
}

