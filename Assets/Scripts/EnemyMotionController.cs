using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script supplements certain npcs by allowing them to move at a specified speed using rigidbody2D.
public class EnemyMotionController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    float speedX;
    float speedY;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speedX = Random.Range(-1, 2) * speed;
        speedY = Random.Range(-1, 2) * speed;
        InvokeRepeating("changeDirection", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update(){
        rb.velocity = new Vector2(speedX,speedY);
        stayInBounds();
    }

    // makes so this npc moves unpredictably by randomizing x and y directions every second
    void changeDirection() {
        speedX = Random.Range(-1, 2) * speed;
        speedY = Random.Range(-1, 2) * speed;
    }

    // doesn't allow npc to move off-screen.
    void stayInBounds() {
        if ((transform.position.x < -4.4f) || (transform.position.x > 3.6f)) {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.7f, 4.7f),
                Mathf.Clamp(transform.position.y, -2.4f, 2.8f), transform.position.z);
            speedX = speedX * -1;
        }
        else if ((transform.position.y < -2.4f) || (transform.position.y > 2.4f)) {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.7f, 4.7f),
                Mathf.Clamp(transform.position.y, -2.4f, 2.8f), transform.position.z);
            speedY = speedY * -1;
        }
    }
}
