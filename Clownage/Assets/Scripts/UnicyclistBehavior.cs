using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
using System;
using Random = System.Random;

public class UnicyclistBehavior : MonoBehaviour
{
    private Random r = new Random();

    public Transform player;

    private NavMeshAgent agent;

    public Vector3[] radialPointList;
    public int currentRadialPoint;
    public int radius;
    public int radialDirection;
    public bool radPointSet;

    public string attackMode;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        AttackSwitcher();
    }

    // Update is called once per frame
    void Update()
    {
        // Choose the next destination point when the agent gets close to the current one.
        if (attackMode == "circling")
        {
            if (agent.remainingDistance < 1f) GotoNextRadialPoint();
        }
        if (attackMode == "ramming")
        {
            agent.SetDestination(player.position);
        }
    }

    async void AttackSwitcher() //loop that runs a new SwitchAttack task every time the current SwitchAttack task ends
    {
        //ensures that this loop doesn't begin at the same time as Start, which will help later - Ryan
        float startingDelayEndTime = Time.time + .5f;
        while (Time.time < startingDelayEndTime)
        {
            await Task.Yield();
        }

        Debug.Log("attack switcher has run");
        while (1 > 0) //will be changed to while(playerHealth > 0) once we have playerHealth
        {
            await SwitchAttack();
        }
    }

    async Task SwitchAttack() //task that switches attack modes
    {
        //determine how long each attack mode is
        float modeDurationEndTime = Time.time;
        if (attackMode == "circling") modeDurationEndTime += 10;
        if (attackMode == "ramming") modeDurationEndTime += 2;

        while (Time.time < modeDurationEndTime)
        {
            await Task.Yield();
        }

        //switch attacks
        if (attackMode == "circling")
        {
            attackMode = "ramming";

            agent.speed = 16.5f;
            agent.acceleration = 6f;
        }
        else
        {
            attackMode = "circling";

            agent.speed = 7f;
            agent.acceleration = 10f;

            int directionPicker = r.Next(2);
            if (directionPicker == 0) radialDirection = -1;
            if (directionPicker == 1) radialDirection = 1;

        }
    }

    void GotoNextRadialPoint() //when in circling mode, constantly feeds new points
    {
        // Returns if no points have been set up
        if (radialPointList.Length == 0)
            return;

        //Update the radial point list based on the player's new position
        for (int i = 0; i < 16; i++)
        {
            radialPointList[i] = new Vector3(player.position.x + radius * (float)Math.Cos(i * radialDirection * Math.PI / 8), player.position.y, player.position.z + radius * (float)Math.Sin(i * radialDirection * Math.PI / 8));
        }

        // Choose the next point in the array as the destination, cycling to the start if necessary.
        currentRadialPoint = (currentRadialPoint + 1) % radialPointList.Length;

        // Set the agent to go to the currently selected destination.
        agent.SetDestination(radialPointList[currentRadialPoint]);
    }
}
