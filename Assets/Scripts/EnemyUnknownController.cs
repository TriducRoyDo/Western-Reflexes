using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnknownController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject npcUnknownShowdown;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // this guy just moves from the left side of the right side of the screen
    // however, he has a small chance to become hostile by spawning the hostile
    // variant at his positions
    void Update() {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
        if(Random.Range(0,10000) < 20) {
            Debug.Log("Showdown!");
            Instantiate(npcUnknownShowdown, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible() {
        Debug.Log("Unknown became invisible");
        Destroy(gameObject);
    }
}
