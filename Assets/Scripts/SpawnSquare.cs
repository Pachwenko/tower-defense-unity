using UnityEngine;

public class SpawnSquare : MonoBehaviour {


    public void instantiate()
    {
        GameObject enemyCircle = (GameObject)Instantiate(Resources.Load("EnemySquare"));
    }
	
}
