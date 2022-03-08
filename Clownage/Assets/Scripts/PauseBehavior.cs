using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseBehavior : MonoBehaviour
{


    private Canvas canvas;
    //public bool isPaused { get; private set; }
    public StarterAssets.StarterAssetsInputs inputs;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        inputs.pauseEvents += val => { OnPauseEvent(); };
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Unpause()
    {
        //inputs.isPaused = false;
        canvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    private void Pause()
    {
        //inputs.isPaused = true;
        canvas.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }

    void OnPauseEvent()
    {
        //Debug.Log("received pause");
        if (!inputs.isPaused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    private void OnLook(InputValue value)
    {
        
    }

    private void OnResumeClick()
    {
        Debug.Log("resumed");
        if (inputs.isPaused)
        {
            inputs.PauseInput();
        }
    }

    private void OnQuitClick()
    {
        Application.Quit();
    }

}

