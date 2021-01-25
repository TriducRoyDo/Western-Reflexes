using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int lives;
    float timeToShoot;
    // how much the enemy is worth in points when killed
    int score;
    float timeElapsed;
    

    public enum EnemyType {
        npc1,
        npcarmor,
        npcbaby,
        npcMoving,
        npcMovingArmor,
        npcUnknown,
        npcUnknownShowdown

    }
    public EnemyType type;

    // Start is called before the first frame update
    // set the npc parameters based on their enemyType
    void Start()
    {
        if(type == EnemyType.npc1) {
            lives = 1;
            timeToShoot = 3;
            score = 50;
            transform.position = new Vector2(Random.Range(-4.4f, 3.6f), Random.Range(-2.4f, 2.4f));
        }
        else if(type == EnemyType.npcarmor) {
            lives = 2;
            timeToShoot = 4;
            score = 75;
            transform.position = new Vector2(Random.Range(-4.4f, 3.6f), Random.Range(-2.4f, 2.4f));
        }
        else if(type == EnemyType.npcbaby) {
            lives = 1;
            timeToShoot = 4;
            score = 0;
            transform.position = new Vector2(Random.Range(-4.4f, 3.6f), Random.Range(-2.4f, 2.4f));
        }
        else if (type == EnemyType.npcMoving) {
            lives = 1;
            timeToShoot = 4;
            score = 100;
            transform.position = new Vector2(Random.Range(-4.4f, 3.6f), Random.Range(-2.4f, 2.4f));

        }
        else if (type == EnemyType.npcMovingArmor) {
            lives = 2;
            timeToShoot = 5;
            score = 150;
            transform.position = new Vector2(Random.Range(-4.4f, 3.6f), Random.Range(-2.4f, 2.4f));
        }
        else if (type == EnemyType.npcUnknown) {
            lives = 1;
            timeToShoot = 100;
            score = 0;
            transform.position = new Vector2(4, Random.Range(-2.4f, 2.4f));
        }
        else if(type == EnemyType.npcUnknownShowdown) {
            lives = 1;
            timeToShoot = 1.5f;
            score = 200;
        }
    }

    // Update is called once per frame
    void Update()
    {
        shootPlayer();   

        //If the game is paused by the tutorial or a game over, then all enemies should be erased from the screen.
        if(Time.timeScale == 0.0f) {
            Destroy(gameObject);
        }
    }

    // when sprite is clicked on/touched
    void OnMouseDown() {
        // if we can fire a bullet, reduce npc lives by 1. If they're out of lives then destroy the gameobject.
        if (FindObjectOfType<PlayerController>().shootGun()) {
            lives--;
            if (lives <= 0) {

                // if the player has shot a baby or unarmed civilian, they lose 2 lives. 
                if((type == EnemyType.npcbaby) || (type == EnemyType.npcUnknown)) {
                    Debug.Log("baby destroyed");
                    FindObjectOfType<PlayerController>().playerHurt();
                    FindObjectOfType<PlayerController>().playerHurt();
                    
                }
                Debug.Log("gameobject destroyed");
                Destroy(gameObject);
                FindObjectOfType<GameController>().updateScore(score);
            }
            else {
                Debug.Log("gameobject clicked");
            }
        }
    }

    // timeElapsed counts how much time has passed since the NPC has been active. If it passes the 
    // NPC's timeToShoot, the player loses a life and the enemy disappears.
    void shootPlayer() {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= timeToShoot) {

            // babies leave the game with no conssequence.
            if ((type == EnemyType.npcbaby) || (type == EnemyType.npcUnknown)) {

            }
            else {
                FindObjectOfType<PlayerController>().playerHurt();

            }
            // POSSIBLE FEATURE: If we want the npc to stay even after they shoot the player
            // then the timer to shoot again should reset (timeElapsed) and the Destroy(gameObject) should be removed.
            timeElapsed = 0;
            Debug.Log("Enemy fires!");
            Destroy(gameObject);
        }
    }


}
