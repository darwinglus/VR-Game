using UnityEngine;
using UnityEngine.Networking;

public class MultiplayerManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        Debug.Log("Player added to server.");
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        Debug.Log("Player disconnected.");
        base.OnServerDisconnect(conn);
    }
}