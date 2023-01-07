using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuHandler : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadScene("Banner_Level_1");
   
        //SceneManager.LoadScene("Level_1");
    }
    
    public void quit(){
    	Application.Quit();
    }
    
    
}
