using UnityEngine;


/// <summary>
/// Should later be changed to abstract class.
/// A class to be inherited by every enemy. Does various functions in the game such as follows a predefined path and taking damage.
/// </summary>
public class EnemyBehavior : MonoBehaviour {
    public float speed;
    private Waypoints Wpoints;
    private int wayPointIndex = 0;
    public float health = 6f;
    public float rateOfDamage = 0.2f;



    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();

    }

    // Update is called once per frame
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[wayPointIndex].position, speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, Wpoints.waypoints[wayPointIndex].position) < 0.1f) {
            //rotates the sprite to look at the next waypoint
            Vector3 dir = Wpoints.waypoints[wayPointIndex].position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //now make sure the array never runs out of bounds and if it has it reached end of the map.
            if (wayPointIndex < Wpoints.waypoints.Length - 1) {
                wayPointIndex += 1;
            } else {
                Destroy(gameObject); //TODO: decrease player's score
            }
        }

    }


    public void AddDamage(float damage) {
        health -= damage;
        //Debug.Log("I just took damage :(");
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}

