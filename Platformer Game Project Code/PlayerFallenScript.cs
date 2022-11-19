using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// to access the scenes in the game

public class PlayerFallenScript : MonoBehaviour
{
    [SerializeField]
    private string Name;
    public string Nae;
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);// the scene that we are currently in

        }

    }
}

