using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public AudioClip crack;

    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;

        /// Determine how many breakable bricks are in the level
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
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
            breakableCount--;
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

}
