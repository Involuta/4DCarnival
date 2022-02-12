using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySlowMechanic : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    //Speed Settings
    private float originalSpeed;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();
        originalSpeed = agent.speed;
        currentSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if time is getting slowed
        if (GameStateManager._instance != null)
        {
            if (GameStateManager._instance.getCurrentState() == GameStateManager.GAMESTATE.SLOWDOWNTIME)
            {
                currentSpeed = originalSpeed / 2;
                agent.speed = currentSpeed;
                Debug.Log("W");
            }
            else if (GameStateManager._instance.getCurrentState() == GameStateManager.GAMESTATE.PLAYING)
            {
                currentSpeed = originalSpeed;
            }
        }
    }
}
