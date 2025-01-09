using UnityEngine;
using System.Collections.Generic;

public class DynamicNPCManager : MonoBehaviour
{
    public List<GameObject> npcs; // List of NPCs in the scene
    public float interactionRadius = 5f; // Radius for NPC interaction
    public PlayerBehaviorTracker playerTracker; // Reference to player tracker

    private void Update()
    {
        foreach (var npc in npcs)
        {
            if (Vector3.Distance(npc.transform.position, playerTracker.transform.position) < interactionRadius)
            {
                TriggerNPCInteraction(npc);
            }
        }
    }

    private void TriggerNPCInteraction(GameObject npc)
    {
        string npcName = npc.name;
        Debug.Log($"Interacting with NPC: {npcName}");
        // Add custom behavior for each NPC
    }
}