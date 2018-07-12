using UnityEngine;

public class SpawnSquare : MonoBehaviour {


    public void instantiate()
    {
        Instantiate(Resources.Load("EnemySquare"));
    }
	
}
