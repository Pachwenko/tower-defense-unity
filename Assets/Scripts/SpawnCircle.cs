using UnityEngine;

public class SpawnCircle : MonoBehaviour {


    public void instantiate()
    {
        Instantiate(Resources.Load("EnemyCircle"));
    }
	
}
