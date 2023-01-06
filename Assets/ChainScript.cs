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
        bullet.velocity = Vector2.up * bulletSpeed;
    }
}
