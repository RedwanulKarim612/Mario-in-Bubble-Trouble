using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class InitializeVelocity : MonoBehaviour
{
    public Vector2 velocity;
    public Rigidbody2D ballRigidbody;
    public GameObject capsule;
    private float fireRate = 5;
    private float fireTimer = 0;
    private bool isClone = false;
    private bool isClonable = true;
    private float cloneTimer = 0;
    private float cloneRate = 15;
    private System.Random rand ;
    public GameObject nextBall;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = this.velocity;
        // InvokeRepeating("Split", 2.0f, 5f);
        rand = new System.Random();
    }

    // Update is called once per frame

    void Update()
    {
	if(fireTimer<fireRate){
		fireTimer+=Time.deltaTime;
	}
	else{
		fire();
		fireTimer=0;
	}
	if(this.gameObject.transform.localScale.x>0.2){
		if(cloneTimer<cloneRate){
			cloneTimer+=Time.deltaTime;
		}
		else{
			if(isClonable)clone();
			cloneTimer=0;
		}
	}

    if(this.gameObject.transform.localPosition.y >= 1.5){
        ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, 0);
    }

    }
    
    public void clone(){
    	GameObject clonedBall = Instantiate(nextBall, ballRigidbody.position + Vector2.right / 4f, Quaternion.identity);
    	clonedBall.GetComponent<InitializeVelocity>().isClone = true;

	if (rand.Next(0, 2) == 0)
	    clonedBall.GetComponent<InitializeVelocity>().isClonable = true;
	else
	    clonedBall.GetComponent<InitializeVelocity>().isClonable = false;

    }
    
    public void fire(){
    		Vector3 position = transform.localPosition;
    		position.y-=1f;
    	        GameObject spike = Instantiate(capsule, position, Quaternion.identity);
    	        spike.GetComponent<Rigidbody2D>().velocity = this.ballRigidbody.velocity;
    	  
    	        
    }

    public void Split()
    {
            if(this.gameObject.transform.localScale.x>0.2){
                GameObject rightBall = Instantiate(nextBall, ballRigidbody.position + Vector2.right / 4f, Quaternion.identity);
                GameObject leftBall = Instantiate(nextBall, ballRigidbody.position + Vector2.left/ 4f, Quaternion.identity);

                // GameController.Instance.AddBallToTracking(rightBall);
                // GameController.Instance.AddBallToTracking(leftBall);


                rightBall.GetComponent<InitializeVelocity>().velocity = this.ballRigidbody.velocity;
                leftBall.GetComponent<InitializeVelocity>().velocity = this.ballRigidbody.velocity * 2.0f;

                rightBall.transform.localScale = this.gameObject.transform.localScale * 0.5f;
                leftBall.transform.localScale = this.gameObject.transform.localScale * 0.5f;

                rightBall.GetComponent<Rigidbody2D>().velocity = this.ballRigidbody.velocity ;
                leftBall.GetComponent<Rigidbody2D>().velocity = this.ballRigidbody.velocity * -1f;
                
		        
		if (rand.Next(0, 2) == 0)
		    rightBall.GetComponent<InitializeVelocity>().isClonable = true;
		else
		    rightBall.GetComponent<InitializeVelocity>().isClonable = false;
		    
		if (rand.Next(0, 2) == 0)
		    leftBall.GetComponent<InitializeVelocity>().isClonable = true;
		else
		    leftBall.GetComponent<InitializeVelocity>().isClonable = false;
            }
        // GameController.Instance.RemoveBallFromTracking(this.gameObject);
            Destroy(this.gameObject);
    }

     
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="spike") {
            //Debug.Log(this.scoreText.GetComponent<CalculateScore>().score);
            this.scoreText.GetComponent<CalculateScore>().score = this.scoreText.GetComponent<CalculateScore>().score+1;
            Destroy(other.gameObject);
            if(!isClone)Split();
            else Destroy(this.gameObject);
        }
    }

}

