using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// to access the scenes in the game

public class SceneChangerScript : MonoBehaviour
{
    [SerializeField] private string SceneName; 
    //private void OnTriggerEnter2D(Collider2D col)
   // {
   
      //  if (col.gameObject.tag == "Player")
      //  {
    public void LoadLevelSelecterScene()
    {

            SceneManager.LoadScene(SceneName);// the scene that we are currently in

        }

    
}
