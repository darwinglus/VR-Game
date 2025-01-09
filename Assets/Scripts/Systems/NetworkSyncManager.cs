using UnityEngine;
using UnityEngine.Networking;

public class NetworkSyncManager : NetworkBehaviour
{
    [SyncVar] private Vector3 syncedPosition;
    [SyncVar] private Quaternion syncedRotation;

    private void Update()
    {
        if (isLocalPlayer)
        {
            CmdSyncTransform(transform.position, transform.rotation);
        }
        else
        {
            transform.position = syncedPosition;
            transform.rotation = syncedRotation;
        }
    }

    [Command]
    private void CmdSyncTransform(Vector3 position, Quaternion rotation)
    {
        syncedPosition = position;
        syncedRotation = rotation;
    }
}