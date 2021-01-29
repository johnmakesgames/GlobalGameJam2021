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
    float timesincerefresh;
    bool onLink = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        agentController = this.GetComponent<AgentController>();

        GameObject[] locations;
        switch (agentController.AiType)
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
                locations = GameObject.FindGameObjectsWithTag("DriveToLocation");
                targetLocation = locations[Random.Range(0, locations.Length)].GetComponent<Transform>().position;
                timesincerefresh = 0;
                break;
            case AITypes.BOAT:
                navMeshAgent.speed = 30;
                navMeshAgent.angularSpeed = 80;
                navMeshAgent.acceleration = 8;
                navMeshAgent.autoBraking = true;
                locations = GameObject.FindGameObjectsWithTag("Boat");
                targetLocation = locations[Random.Range(0, locations.Length)].GetComponent<Transform>().position;
                timesincerefresh = 0;
                break;
            default:
                break;
        }

        navMeshAgent.SetDestination(targetLocation);
    }

    private void Update()
    {
        if (agentController.AiType == AITypes.CAR)
            Debug.DrawLine(this.GetComponent<Transform>().position, targetLocation, Color.green);

        timesincerefresh += Time.deltaTime;

        if (Vector3.Distance(targetLocation, this.GetComponent<Transform>().position) < 2)
        {
            Debug.Log("Going to new location");

            GameObject[] locations;
            switch (agentController.AiType)
            {
                case AITypes.PERSON:
                    break;
                case AITypes.CAR:
                    locations = GameObject.FindGameObjectsWithTag("DriveToLocation");
                    targetLocation = locations[Random.Range(0, locations.Length)].GetComponent<Transform>().position;
                    timesincerefresh = 0;
                    break;
                case AITypes.BOAT:
                    locations = GameObject.FindGameObjectsWithTag("SailToLocation");
                    targetLocation = locations[Random.Range(0, locations.Length)].GetComponent<Transform>().position;
                    timesincerefresh = 0;
                    break;
                default:
                    break;
            }

            navMeshAgent.SetDestination(targetLocation);
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
