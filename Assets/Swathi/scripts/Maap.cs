using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Maap : MonoBehaviour
{
    public void Attractions()
    {
        Debug.Log("Attractions");
        SceneManager.LoadScene("Attractions");

    }
    public void Games()
    {
        SceneManager.LoadScene("Games");

    }
    public void Hanuted()
    {
        SceneManager.LoadScene("haunted");

    }
    public void welcome()
    {
        SceneManager.LoadScene("Entrance");

    }
    public void Forest()
    {
        SceneManager.LoadScene("forest");

    }

}

