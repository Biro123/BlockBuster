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
                GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
                hasStarted = true;
            }
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /// introduce a small random element to the bounce angles to avoid 
        /// getting stuck in bounce 'loops'
        Vector2 tweak = new Vector2( Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f) );

        if (hasStarted && collision.gameObject.tag != "Breakable") 
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
