using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {


    public void instantiate()
    {
        GameObject enemyCircle = (GameObject)Instantiate(Resources.Load("EnemyCircle"));
    }
	
}
