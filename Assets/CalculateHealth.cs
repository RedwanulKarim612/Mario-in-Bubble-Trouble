using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CalculateHealth : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(player.GetComponent<PlayerMovementScript>().health == 0 ) SceneManager.LoadScene("GameOver");
        GetComponent<TMPro.TextMeshProUGUI>().text = "health " + player.GetComponent<PlayerMovementScript>().health.ToString() + "/5";
    }
}
