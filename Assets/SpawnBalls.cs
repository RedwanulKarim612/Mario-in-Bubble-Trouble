using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnBalls : MonoBehaviour
{
    public GameObject ball; // Drag the ball prefab in the Inspector
    public float ballScale = 0.5f; // The scale of the cloned balls
    private GameObject previousBall; // The previous ball that was created
    public TMP_Text scoreText;
    public Vector2 velocity;
    void Start()
    {
        CreateBall(); // Create the first ball
    }

    void update()
    {
        transform.position = ball.transform.position;
    }

    int spawnCount = 0;
    void CreateBall()
    {
        // Cancel the previous invocation
        if(spawnCount == 4) return;
        GameObject ball1 = Instantiate(ball, ball.transform.position, Quaternion.identity); // Create a ball at the current position of the ball prefab
        // GameObject ball2 = Instantiate(ball, ball.transform.position, Quaternion.identity); // Create another ball at the current position of the ball prefab
	ball1.GetComponent<InitializeVelocity>().velocity = new Vector2(3,1);
        //ball1.transform.localScale = ball.transform.localScale * ballScale; // Set the scale of ball1
        ball1.GetComponent<InitializeVelocity>().scoreText = this.scoreText;
        // ball2.transform.localScale = ball.transform.localScale * ballScale; // Set the scale of ball2

        spawnCount++;
        
        Invoke("CreateBall", 10f);
    }
}
