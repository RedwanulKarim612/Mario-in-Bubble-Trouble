using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CalculateScore : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(score==10) {
            Debug.Log(SceneManager.GetActiveScene().name);
        	if(SceneManager.GetActiveScene().name=="Level_2"){
        		SceneManager.LoadScene("YouWon");
        	}
        	else{
        		SceneManager.LoadScene("Banner_Level_2");
        	}
        }
    	GetComponent<TMPro.TextMeshProUGUI>().text = "score " + score.ToString() + "/10";
    }
    
}
