using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerReputation))]
public class PlayerReputationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlayerReputation reputation = (PlayerReputation)target;
        if (GUILayout.Button("Add Reputation"))
        {
            reputation.AddReputation(0.1f);
        }
        if (GUILayout.Button("Remove Reputation"))
        {
            reputation.AddReputation(-0.1f);
        }
    }
}