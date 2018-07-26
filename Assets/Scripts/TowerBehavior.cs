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
    public float fireSpawnRate;
    public int leadingProjectileOffset = 15;
    public float projectileSpeed = 2500.0f;

    private float fireSpawnRateReset;
    private Collider2D firstEnemy;

    // Use this for initialization
    void Start() {
        fireSpawnRateReset = fireSpawnRate;
    }

    // Update is called once per frame
    void Update() {
        fireProjectile();
        fireSpawnRate -= Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            if (firstEnemy == null) {
                firstEnemy = other;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            if (firstEnemy == null) {
                firstEnemy = other;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        firstEnemy = null;
    }

    public int getCost() {
        return cost;
    }


    private void fireProjectile() {
        if (fireSpawnRate < 0 && firstEnemy != null)
        {
            fireSpawnRate = fireSpawnRateReset;
            RotateTowardsEnemy();
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed);
            //Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), projectile.GetComponent<Collider2D>());
            Destroy(projectile, 1.0f);
        }
    }

    private void RotateTowardsEnemy()
    {
        Vector3 dir = firstEnemy.gameObject.transform.position - transform.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + leadingProjectileOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

