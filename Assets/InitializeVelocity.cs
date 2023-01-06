using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeVelocity : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D ballRigidbody;

    public GameObject nextBall;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
        InvokeRepeating("Split", 2.0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Split()
    {
       
            GameObject rightBall = Instantiate(nextBall, ballRigidbody.position + Vector2.right / 4f, Quaternion.identity);
            GameObject leftBall = Instantiate(nextBall, ballRigidbody.position + Vector2.left/ 4f, Quaternion.identity);

            // GameController.Instance.AddBallToTracking(rightBall);
            // GameController.Instance.AddBallToTracking(leftBall);


            rightBall.GetComponent<InitializeVelocity>().velocity = this.ballRigidbody.velocity;
            leftBall.GetComponent<InitializeVelocity>().velocity = this.ballRigidbody.velocity;
     

        // GameController.Instance.RemoveBallFromTracking(this.gameObject);
            Destroy(this.gameObject);
    }
}
