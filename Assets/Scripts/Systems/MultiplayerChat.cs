using UnityEngine;

public class MultiplayerChat : MonoBehaviour
{
    private string chatLog = "";
    private string currentMessage = "";

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, Screen.height - 200, 300, 200));
        GUILayout.Label("Chat Log:");
        GUILayout.TextArea(chatLog, GUILayout.Height(100));
        GUILayout.Space(10);
        GUILayout.Label("Type Message:");
        currentMessage = GUILayout.TextField(currentMessage);
        if (GUILayout.Button("Send"))
        {
            SendMessageToChat(currentMessage);
            currentMessage = "";
        }
        GUILayout.EndArea();
    }

    private void SendMessageToChat(string message)
    {
        chatLog += "\n" + message;
        Debug.Log("Message sent: " + message);
    }
}