using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {

            //Debug.Log("player hit");
        if(other.gameObject.name=="Character"){
        	Debug.Log("hitttt");
        }
        Destroy(this.gameObject);
    }
}
