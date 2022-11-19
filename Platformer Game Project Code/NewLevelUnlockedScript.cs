using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewLevelUnlockedScript : MonoBehaviour
{
    [SerializeField]
    private string SceneName;
    [SerializeField]
    private int LevelNumber;
    private static NewLevelUnlockedScript NewLevelInstance;
    public static NewLevelUnlockedScript GetNewLevelInstance()
    {

        return NewLevelInstance;
    }
    public int GetLevelNumber()
    public int GetLevelNumber()
    {

        return LevelNumber;
    }

    private void Awake()
    {

        NewLevelInstance = this;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("LevelCompleted");


            GameManagerScript.GetGameManagerInstance().LevelCompleted();
            SimpleSceneFader.ChangeSceneWithFade(SceneName);

            // SceneManager.LoadScene(SceneName);// the scene that we are currently in

        }


    }
}
