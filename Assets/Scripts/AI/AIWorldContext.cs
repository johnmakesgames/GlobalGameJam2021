using UnityEngine;

/// <summary>
/// <see cref="AIWorldContext"/> provides general information about the world such
/// as th
/// </summary>
public class AIWorldContext : MonoBehaviour
{
    /// <summary>
    /// Locations placed around the world that pedestrians can use as destinations, like city block corners.
    /// </summary>
    private GameObject[] pedestrianPathingNodes = null;

    /// <summary>
    /// The players game object.
    /// </summary>
    private GameObject playerGameObject = null;

    private void Start()
    {
        // Find the pedestrian pathing nodes.
        pedestrianPathingNodes = GameObject.FindGameObjectsWithTag("Pedestrian Path Node");

        // Find the player.
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    public GameObject GetPlayerGameObject()
    {
        return playerGameObject;
    }

    public GameObject GetRandomPedestrianPathNode()
    {
        return pedestrianPathingNodes[Random.Range(0, pedestrianPathingNodes.Length)];
    }

    public int GetPedestrianPathNodeCount()
    {
        return pedestrianPathingNodes.Length;
    }
}
