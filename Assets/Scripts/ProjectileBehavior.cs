using UnityEngine;

public class ProjectileBehavior : MonoBehaviour {
    public float damage;
    public int peirceCount;
    
    private int hitCounter;

    private void Update() {
        if (hitCounter > peirceCount) {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("AddDamage", damage);
            hitCounter++;
        }
        //Debug.Log("hey I entered your collider, TAKE DAMAGE!");
    }
}
