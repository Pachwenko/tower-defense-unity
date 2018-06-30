
using UnityEngine;

/// <summary>
/// Class to be inherited by the Towers. Used to set various propertys and perhaps do some functions.
/// 
/// </summary>
public class TowerBehavior : MonoBehaviour {
    public float towerDamage = 1f;
    //May appear not to work if enemy's health is too high and/or towerDamage is too low


    // Use this for initialization
    void Start() {
    

    }

    // Update is called once per frame
    void Update() {



    }

    public void OnTriggerEnter2D(Collider2D other) {
        other.SendMessage("AddDamage", towerDamage * Time.deltaTime);
        //Debug.Log("hey I'm in your collider");
    }
    public void OnTriggerStay2D(Collider2D other) {
        other.SendMessage("AddDamage", towerDamage * Time.deltaTime);
        //Debug.Log("Sent damage: " + towerDamage * Time.deltaTime);
    }

}

