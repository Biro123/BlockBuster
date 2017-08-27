using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoPlay)
        {
            AutoPlay();
        }
        else
        {
            MoveWithMouse();
        }

	}

    // Autopilot for paddle to always match ball position
    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0.0f);
        Vector3 ballPos = ball.transform.position;
        
        paddlePos.x = Mathf.Clamp(ballPos.x, -7.5f, 7.5f );
        this.transform.position = paddlePos;
    }

    // Move the paddle based on mouse position
    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0.0f);

        /// Relative horizontal position of mouse (between 0 and 1) 
        /// Multiplied by the number of GameBlocks to give a measurement 
        /// of gameblocks. Then subtract half as Gameblock 0 is the centre.
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16) - 8;

        /// Ensure it cannot leave the screen
        mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, -7.5f, 7.5f);

        /// set new paddle position based on horizontal mouse position
        paddlePos.x = mousePosInBlocks;
        this.transform.position = paddlePos;
    }

}
