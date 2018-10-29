using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float xVelocity = 5f;
    [SerializeField] float yVelocity = 15f;

    Vector2 paddleToBallDistance;
    bool hasStarted;

	// Use this for initialization
	void Start () 
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            BallStuckToPaddle();
            LaunchBallOnClick();
        }

    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
        }
    }

    private void BallStuckToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
        }
    }

}
