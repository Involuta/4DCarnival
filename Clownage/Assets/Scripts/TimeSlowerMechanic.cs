using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowerMechanic : MonoBehaviour
{
    //Is time slowed down?
    private bool isSlowed;

    // Start is called before the first frame update
    void Start()
    {
        isSlowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player used the key to slow time down
        if(Input.GetKeyDown(KeyCode.E) && isSlowed == false)
        {
            isSlowed = true;
            GameStateManager._instance.SlowDownTime();
        }
        else if(Input.GetKeyDown(KeyCode.E) && isSlowed == true)
        {
            isSlowed = false;
            GameStateManager._instance.ReturnToNormalTime();
        }
    }
}
