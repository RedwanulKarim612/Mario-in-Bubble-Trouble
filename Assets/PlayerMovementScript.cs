using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D myrigidbody2d;
    public float flapStrength = 4;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        health = 5;
    }

    public GameObject spikeToThrow;

    public void throwSpike(){
        Vector3 localScale = myrigidbody2d.transform.localScale;
        GameObject spike = Instantiate(spikeToThrow, transform.localPosition, Quaternion.identity);
        spike.transform.localPosition = transform.localPosition;
        if(localScale.x > 0) {
            spike.transform.localPosition += Vector3.right * .32f;
        }else spike.transform.localPosition += Vector3.left * .32f;
    }

    // Update is called once per frame
    private int counter = 0;
    void decreaseVelocity(){
        Vector3 v = myrigidbody2d.velocity;
        Vector3 lc = myrigidbody2d.transform.localScale;
        if(v.x > -.15f && v.x < 0.15f) v.x = 0;
        if(v.x > 0){
            v.x -= 0.15f;
            lc.x = 4;
            spriteRenderer.sprite = sprites[(counter++)/5];
        }else if(v.x < 0){
            v.x += 0.15f;
            lc.x = -4;
            spriteRenderer.sprite = sprites[(counter++)/5];
        }else {
            spriteRenderer.sprite = sprites[0];
        }
        counter = counter % 20;
        myrigidbody2d.velocity = v;
        myrigidbody2d.transform.localScale = lc;
    }
    void Update()
    {
        decreaseVelocity();
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            myrigidbody2d.velocity = Vector2.left * flapStrength;
        }else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            myrigidbody2d.velocity = Vector2.right * flapStrength;
        }else if(Input.GetKeyDown(KeyCode.Space)){
            throwSpike();
        }
    }
    
    public TMP_Text currentScore;
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("player hit");
            
        Debug.Log("hit by capsule");
        health--;
        other.gameObject.GetComponent<InitializeVelocity>().Split();
        // Destroy(other.gameObject);
        // int cscore = this.currentScore.GetComponent<CalculateScore>().score;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // this.currentScore.GetComponent<CalculateScore>().score = cscore;
    }
}
