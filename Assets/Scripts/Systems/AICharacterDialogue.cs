using UnityEngine;

public class AICharacterDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager; // Reference to dialogue manager
    public AdvancedTaskCharacterVR virtualCharacter; // Virtual character reference

    private string[] aiResponses = {
        "That's interesting, can you tell me more?",
        "I see! Let's move on to the next task.",
        "Hmm, that sounds challenging. Let's figure it out together."
    };

    public void GenerateResponse(string playerInput)
    {
        // Simple keyword-based AI
        if (playerInput.Contains("help"))
        {
            dialogueManager.StartDialogue(virtualCharacter.characterName, "Don't worry, I'm here to assist you.");
        }
        else if (playerInput.Contains("lost"))
        {
            dialogueManager.StartDialogue(virtualCharacter.characterName, "It seems you're lost. Follow the light!");
        }
        else
        {
            // Random fallback response
            int randomIndex = Random.Range(0, aiResponses.Length);
            dialogueManager.StartDialogue(virtualCharacter.characterName, aiResponses[randomIndex]);
        }
    }
}