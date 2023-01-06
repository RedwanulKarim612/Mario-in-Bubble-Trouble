using System.Collections;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public GameObject ball; // Drag the ball prefab in the Inspector
    public float ballScale = 0.5f; // The scale of the cloned balls
    private GameObject previousBall; // The previous ball that was created

    void Start()
    {
        CreateBall(); // Create the first ball
    }

    void update()
    {
        transform.position = ball.transform.position;
    }

    void CreateBall()
    {
        // Cancel the previous invocation
       

        GameObject ball1 = Instantiate(ball, ball.transform.position, Quaternion.identity); // Create a ball at the current position of the ball prefab
        // GameObject ball2 = Instantiate(ball, ball.transform.position, Quaternion.identity); // Create another ball at the current position of the ball prefab

        ball1.transform.localScale = ball.transform.localScale * ballScale; // Set the scale of ball1
        // ball2.transform.localScale = ball.transform.localScale * ballScale; // Set the scale of ball2

       
        Invoke("CreateBall", 5f); // Invoke the CreateBall function again after 5 seconds
    }
}
