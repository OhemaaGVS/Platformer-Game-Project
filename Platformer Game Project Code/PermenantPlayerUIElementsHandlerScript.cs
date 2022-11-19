using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermenantPlayerUIElementsHandlerScript : MonoBehaviour
{
   
    [SerializeField]
    public int NumberOfGemsCollected;

public Text CollectedGemsText;

    
    private static PermenantPlayerUIElementsHandlerScript PermenantPlayerUIInstance;
    public static PermenantPlayerUIElementsHandlerScript GetPermenantPlayerUIInstance()
 
    {

        return PermenantPlayerUIInstance;
    }
    //static is a variable that belongs to the class itself


    private void Awake()
    {// singleton
        DontDestroyOnLoad(gameObject);

        if (!PermenantPlayerUIInstance)// if there is no instance
        {

            PermenantPlayerUIInstance = this;// this is the current instance
        }
        else
        {
            Destroy(gameObject);// destroy the game object that has this script
        }
    }
    public void Start()
    {
        //PlayerHealthBar.value = PlayerMaxHealth;
        NumberOfGemsCollected = PlayerPrefs.GetInt("GemsCollected", 0);
        CollectedGemsText.text = NumberOfGemsCollected.ToString();
    }

    public void IncrementPlayerGemsCollected()
    {

        NumberOfGemsCollected = NumberOfGemsCollected + 1;
        PlayerPrefs.SetInt("GemsCollected", NumberOfGemsCollected);

        CollectedGemsText.text = NumberOfGemsCollected.ToString();


    } 
}