using UnityEngine;

public class SpawnCircle : MonoBehaviour {


    public void instantiate()
    {
        GameObject enemyCircle = (GameObject)Instantiate(Resources.Load("EnemyCircle"));
    }
	
}
