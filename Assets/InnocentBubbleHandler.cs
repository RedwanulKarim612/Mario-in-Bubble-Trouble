using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InnocentBubbleHandler : MonoBehaviour
{

    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    private float deceiveRate = 5;
    private float deceiveTimer = 0;
    private int counter = 0;
    public GameObject nextBall;
    public TMP_Text scoreText;
    public Vector2 velocity;
    public Rigidbody2D ballRigidbody;
       
    // Start is called before the first frame update
    void Start()
    {   
    	 GetComponent<Rigidbody2D>().velocity = new Vector2(4,2);
    	 spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(deceiveTimer<deceiveRate){
        	deceiveTimer+=Time.deltaTime;
        }
        else{
        	deceiveTimer=0;
        	counter = 1-counter;
        	spriteRenderer.sprite = sprites[counter];
        }
        if(this.gameObject.transform.localPosition.y >= 1.5){
           ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, 0);
    }
    }
    
    public void Split()
    {
            if(this.gameObject.transform.localScale.x>0.2){
            Debug.Log("ind");
                GameObject rightBall = Instantiate(nextBall, ballRigidbody.position + Vector2.right / 4f, Quaternion.identity);
                GameObject leftBall = Instantiate(nextBall, ballRigidbody.position + Vector2.left/ 4f, Quaternion.identity);

                // GameController.Instance.AddBallToTracking(rightBall);
                // GameController.Instance.AddBallToTracking(leftBall);


                rightBall.GetComponent<InnocentBubbleHandler>().velocity = this.ballRigidbody.velocity;
                leftBall.GetComponent<InnocentBubbleHandler>().velocity = this.ballRigidbody.velocity * 2.0f;

                rightBall.transform.localScale = this.gameObject.transform.localScale * 0.5f;
                leftBall.transform.localScale = this.gameObject.transform.localScale * 0.5f;

                rightBall.GetComponent<Rigidbody2D>().velocity = this.ballRigidbody.velocity;
                leftBall.GetComponent<Rigidbody2D>().velocity = this.ballRigidbody.velocity * -1f;
            }
        // GameController.Instance.RemoveBallFromTracking(this.gameObject);
            Destroy(this.gameObject);
    }

     
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="spike") {
            Destroy(other.gameObject);
            if(counter==1) {
            	Debug.Log("split");
            	Debug.Log(this.gameObject.transform.localScale.x);
            	Split();
                this.scoreText.GetComponent<CalculateScore>().score = this.scoreText.GetComponent<CalculateScore>().score+1;
            }
            else {
                this.scoreText.GetComponent<CalculateScore>().score = this.scoreText.GetComponent<CalculateScore>().score-2;
            	Debug.Log("killed innocent bubble");
            	Destroy(this.gameObject);
            }
        }
    }
}
