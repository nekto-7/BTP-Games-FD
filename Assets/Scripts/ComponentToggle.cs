using Mirror;
using UnityEngine;

public class ComponentToggle : NetworkBehaviour
{
    public Camera playerCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(playerCamera.gameObject);
        }
    }

    void OnStartLocalPlayer()
    {
        playerCamera.enabled = true;
    }
}
