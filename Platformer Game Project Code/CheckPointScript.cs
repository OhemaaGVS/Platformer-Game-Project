using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class CheckPointScript : MonoBehaviour
{
    //private static CheckPointScript CheckPointInstance;
    //public static CheckPointScript GetCheckPointInstance()
    //{
    //    return CheckPointInstance;

    //}
    //public Vector2 GetCheckPointPosition()
    //{
    //    return CheckPointPosisition;

    //}
    [SerializeField]
    private GameObject Levels; // game object for th levels
     [SerializeField]
    private GameObject BackGroundLevelImage;// the game object for the background
    // Start is called before the first frame update


    public void OpenMenu()
    {// this function would open the menu
        //if (Levels.active == true)
        //{


        //    Levels.active = false;

        //}
        //else
        //{
        //    Levels.active = true;
        //}
    }
    [SerializeField]
    private string ChecPointReached;// whether the check point has been reched or not 
    [SerializeField]
    private Button CheckPointButton;  // the button inside the check point    
    private bool IsCheckPointActivated = false;// bool for if the check point has been reached or not
    public void OpenTravelMap()
    {//this function will open the travel map 
        if (Levels.active == true)
        {
            Levels.active = false;
            BackGroundLevelImage.active = false;

        }
        else
        {   
            Levels.active = true;
            BackGroundLevelImage.active = true;
        }
    }
    [SerializeField]
    private GameObject ActivatedCheckPoint;
    // Start is called before the first frame update
    void Start()
    {
        CheckPointButton.interactable = false;
        ActivatedCheckPoint.active = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            CheckPointButton.interactable = true;
          //  IsCheckPointActivated = true;
            ActivatedCheckPoint.active = true;
        //    GameManagerScript.GetGameManagerInstance().LevelCompleted();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
            CheckPointButton.interactable = false;
      //  IsCheckPointActivated = true;
        ActivatedCheckPoint.active = false;
    }
    private void Awake()
    {
        //CheckPointInstance = this;

    }
}