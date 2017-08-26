using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

    // Use this for initialization
    void Start()
    {
        /// Find the paddle in the scene
        paddle = GameObject.FindObjectOfType<Paddle>();

        /// difference between ball and paddle
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() {

        if (!hasStarted)
        {
            /// 'stick' the ball to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;
        
            if (Input.GetMouseButtonDown(0))
            {
                print("mouse clicked");
                GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
                hasStarted = true;
            }
        }

	}
}
