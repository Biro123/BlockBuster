using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smoke;

    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;
    private Score score;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        score = GameObject.FindObjectOfType<Score>();

        timesHit = 0;

        /// Determine how many breakable bricks are in the level
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }

    }
	
    private void OnCollisionExit2D(Collision2D collision)
    {
        /// audosource adds a sound to where the brick is in the world
        /// as opposed to playing the sound within the brick object as it will be
        /// destroyed, and the sound cut-off
        AudioSource.PlayClipAtPoint(crack, transform.position);

        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            score.IncrementScore(10);
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    private void PuffSmoke()
    {
        // Create smoke at the Brick's position
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);

        // Extract the main class from the particle system of the smokepuff we just
        // created (see the smoke prefab in Unity for this to make sense)
        ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;

        // set the colour of the smokepuff to be that of the current gameObject(Brick)
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }


    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick Sprite Not Found");
        }
    }
    
}
