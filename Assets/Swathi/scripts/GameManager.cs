using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CameraController camera;
    private bool awake = false;
    public GameObject player;
    private void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {

    }


    private void Update()
    {
        if (awake == false)
        {
            Fungus.Flowchart.BroadcastFungusMessage("Restart");
            awake = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            camera.enabled = false;
        }
    }

    public void CamActive()
    {
        camera.enabled = true;
        Debug.Log("Event");
        awake = false;
    }
    public void Reset() {
        //Debug.Log("Running");
        player.transform.position = new Vector2(0, 0);
} }