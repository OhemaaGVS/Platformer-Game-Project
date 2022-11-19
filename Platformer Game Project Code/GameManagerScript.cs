using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{   
    private static GameManagerScript GameManager;
    public static GameManagerScript GetGameManagerInstance()
    {

        return GameManager;

    }
    private void Awake()
    {


        GameManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelCompleted()
    {
        int CurrentLevelNumber = NewLevelUnlockedScript.GetNewLevelInstance().GetLevelNumber();
        //print(NewLevelUnlockedScript.GetNewLevelInstance().GetLevelNumber());
        PlayerPrefs.SetInt("LevelReached",CurrentLevelNumber+1);

    }
    
}
