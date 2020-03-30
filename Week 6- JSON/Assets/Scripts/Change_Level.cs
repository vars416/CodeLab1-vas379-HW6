using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Level : MonoBehaviour
{
    AudioSource Sound; //sound effect

    private void Start()
    {
        Sound = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter(Collider other) //on entering trigger
    {
        Sound.Play(); //play sound effect
        Invoke("SceneChanger", 2.0f); //change scene 2 seconds after hitting trigger
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload level on collision
    }

    void SceneChanger()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //go to next scene
    }

    public void Restart()
    {
        SceneManager.LoadScene(0); //restart game 
    }
}
