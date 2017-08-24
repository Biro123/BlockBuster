using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0.0f);

        /// Relative horizontal position of mouse (between 0 and 1) 
        /// Multiplied by the number of GameBlocks to give a measurement 
        /// of gameblocks. Then subtract half as Gameblock 0 is the centre.
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16) - 8;

        /// Ensure it cannot leave the screen
        mousePosInBlocks =  Mathf.Clamp(mousePosInBlocks, -7.5f, 7.5f);

        /// set new paddle position based on horizontal mouse position
        paddlePos.x = mousePosInBlocks;
        this.transform.position = paddlePos;
	}
}
