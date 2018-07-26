using UnityEngine;


/// <summary>
/// Should later be changed to abstract class.
/// A class to be inherited by every enemy. Does various functions in the game such as follows a predefined path and taking damage.
/// </summary>
public class EnemyBehavior : MonoBehaviour {
    public float speed;
    public float health;
    public int worth;

    private WaypointHolder Wpoints;
    private GameController gameController;
    private int wayPointIndex = 0;

    // Use this for initialization
    void Start() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        if (gameController == null) {
            Debug.Log("Could not find 'GameController' scipt");
        }
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<WaypointHolder>();
        //This didn't do anything: Physics2D.IgnoreLayerCollision(0, 15);
        transform.position = Wpoints.waypoints[0].position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[wayPointIndex].position, speed * Time.deltaTime);
        if (health <= 0) {
            gameController.MoneyWithdrawlOrDeposit(worth);
            Destroy(this.gameObject);
        }

        if (Vector2.Distance(transform.position, Wpoints.waypoints[wayPointIndex].position) < 0.1f) {
            //rotates the sprite to look at the next waypoint
            //Vector3 dir = Wpoints.waypoints[wayPointIndex].position - transform.position;
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);

            //now make sure the array never runs out of bounds and if it has it reached end of the map.
            if (wayPointIndex < Wpoints.waypoints.Length - 1) {
                wayPointIndex += 1;
            } else {
                Destroy(gameObject);
                gameController.UpdateLives(1);
            }
        }

    }


    public void AddDamage(float damage) {
        health -= damage;
        //Debug.Log("I just took damage :(");
        if (health <= 0) {
            gameController.MoneyWithdrawlOrDeposit(worth);
            Destroy(gameObject);
        }
    }

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float newHealth) {
        health = newHealth;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("projectile"))
        {
            float damageToTake = other.GetComponent<ProjectileBehavior>().damage;
            health -= damageToTake;
        }
        //Debug.Log("hey I entered your collider");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("projectile"))
        {
            float damageToTake = other.GetComponent<ProjectileBehavior>().damage;
            health -= damageToTake;
        }
        //Debug.Log("hey I entered your collider");
    }
}

