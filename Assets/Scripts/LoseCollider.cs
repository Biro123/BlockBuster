using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;
    private Lives lives;
    private Ball ball;

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        lives = GameObject.FindObjectOfType<Lives>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives.DecreaseLives();

        if (Lives.lives <= 0)
        {
            levelManager.LoadLevel("Lose");
        }
        else
        {
            ball.SetHasStarted(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

}
