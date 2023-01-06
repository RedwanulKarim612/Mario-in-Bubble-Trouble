using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D myrigidbody2d;
    public float flapStrength = 4;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public GameObject spikeToThrow;

    public void throwSpike(){
        // Vector3 position = transform.localPosition;
        // Vector3 localScale = myrigidbody2d.transform.localScale;
        // Debug.Log(position.x);
        // if(localScale.x > 0) {
        //     position = Vector3.forward * 4;
        // }else position = Vector3.back * 4;
        GameObject spike = Instantiate(spikeToThrow, transform.localPosition, Quaternion.identity);
        spike.transform.localPosition = transform.localPosition;
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
}
