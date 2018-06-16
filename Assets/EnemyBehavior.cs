using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Should later be changed to abstract class.
/// A class to be inherited by every enemy. Does various functions in the game such as follows a predefined path and taking damage.
/// </summary>
public class EnemyBehavior : MonoBehaviour
{
    public float health;
    public float speed;

    // Use this for initialization
    void Start()
    {
        health = 6f;
        speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void addDamage(float damage)
    {
        if (health - damage <= 0) {
            Destroy(gameObject);
        }
        health -= damage;
    }
}
