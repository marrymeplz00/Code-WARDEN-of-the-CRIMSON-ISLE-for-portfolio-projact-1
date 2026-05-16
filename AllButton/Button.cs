using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial"); 
    }

    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game"); 

        Application.Quit(); 
    }

    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToCredits()
{
    SceneManager.LoadScene("Credit");
}
}
