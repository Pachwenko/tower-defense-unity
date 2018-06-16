using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to be inherited by the Towers. Used to set various propertys and perhaps do some functions.
/// 
/// </summary>
public class TowerBehavior : MonoBehaviour {
    public static float damage;

    // Use this for initialization
    void Start () {
        damage = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.addDamage(damage);
    }
}
