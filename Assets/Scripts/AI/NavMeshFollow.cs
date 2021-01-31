using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AgentController))]
[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshFollow : MonoBehaviour
{
    public Vector3 targetLocation;
    private NavMeshAgent navMeshAgent;
    private AgentController agentController;
    bool onLink = false;

    public Vector3 scriptedAgentLocation1;
    public Vector3 scriptedAgentLocation2;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        agentController = this.GetComponent<AgentController>();

        SetupNavAgent(agentController.AiType);
    }

    private void Update()
    {
        if (Vector3.Distance(targetLocation, this.GetComponent<Transform>().position) < 2)
        {
            switch (agentController.AiType)
            {
                case AITypes.PERSON:
                    break;
                case AITypes.CAR:
                    targetLocation = GetLocationToGoToFromTag("DriveToLocation");
                    break;
                case AITypes.BOAT:
                    targetLocation = GetLocationToGoToFromTag("SailToLocation");
                    break;
                case AITypes.SCRIPTED_AGENT:
                    targetLocation = GetFurthestOfScritpedLocations();
                    break;
                default:
                    break;
            }

            navMeshAgent.SetDestination(targetLocation);
        }
    }

    void SetupNavAgent(AITypes aiType)
    {
        switch (aiType)
        {
            case AITypes.PERSON:
                break;
            case AITypes.CAR:
                navMeshAgent.speed = 10;
                navMeshAgent.angularSpeed = 400;
                navMeshAgent.autoTraverseOffMeshLink = true;
                navMeshAgent.acceleration = 10;
                navMeshAgent.autoBraking = true;
                navMeshAgent.avoidancePriority = 1;
                targetLocation = GetLocationToGoToFromTag("DriveToLocation");
                break;
            case AITypes.BOAT:
                navMeshAgent.speed = 30;
                navMeshAgent.angularSpeed = 80;
                navMeshAgent.acceleration = 8;
                navMeshAgent.autoBraking = true;
                targetLocation = GetLocationToGoToFromTag("SailToLocation");
                break;
            case AITypes.SCRIPTED_AGENT:
                navMeshAgent.speed = 10;
                navMeshAgent.angularSpeed = 600;
                navMeshAgent.autoTraverseOffMeshLink = true;
                navMeshAgent.acceleration = 10;
                navMeshAgent.autoBraking = true;
                navMeshAgent.avoidancePriority = 1;
                targetLocation = GetFurthestOfScritpedLocations();
                break;
        }

        navMeshAgent.SetDestination(targetLocation);
    }

    Vector3 GetLocationToGoToFromTag(string tag)
    {
        var locations = GameObject.FindGameObjectsWithTag(tag);
        return locations[Random.Range(0, locations.Length)].GetComponent<Transform>().position;
    }

    Vector3 GetFurthestOfScritpedLocations()
    {
        float distanceToOne = Vector3.Distance(this.transform.position, scriptedAgentLocation1);
        float distanceToTwo = Vector3.Distance(this.transform.position, scriptedAgentLocation2);

        if (distanceToOne > distanceToTwo)
        {
            return scriptedAgentLocation1;
        }
        else
        {
            return scriptedAgentLocation2;
        }

    }

    void FixedUpdate()
    {
        if (navMeshAgent.isOnOffMeshLink && !onLink)
        {
            onLink = true;
            navMeshAgent.speed = 3;
        }
        else if (!navMeshAgent.isOnOffMeshLink && onLink)
        {
            onLink = false;
            navMeshAgent.speed = 10;
        }
    }
}
