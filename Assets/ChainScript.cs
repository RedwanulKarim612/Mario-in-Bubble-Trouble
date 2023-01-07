using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D bullet; 
    void Start()
    {
        
    }

    // Update is called once per frame
    public float bulletSpeed = 10f;
    void Update()
    {
        if(bullet.transform.position.y > 100) Destroy(gameObject);
        else bullet.velocity = Vector2.up * bulletSpeed;
    }
    
}
