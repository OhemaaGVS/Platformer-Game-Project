
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;// to access the scenes in the game

public class LevelSelecterScript : MonoBehaviour
{

    [SerializeField] private Button[] LevelButtons;

    // [SerializeField] private string SceneName; 

    public void SceneChange(string LevelName)
    {

        SimpleSceneFader.ChangeSceneWithFade(LevelName);
    }

    private void Start()
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached", 1);
        for (int Buttons = 0; Buttons < LevelButtons.Length; Buttons++)// for loop that goes through the buttons
        {
            if (Buttons + 1 > LevelReached)// if the button number is greater than the level that has been reached( +1 because the for loop starts at 0 and the levels start at 1)
            {
                LevelButtons[Buttons].interactable = false;// making the buttons interactable so they cant be clicked on

            }
        }

    }
}
    
}
