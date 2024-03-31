using Mirror;
using UnityEngine;
public class PlayerMenu : MonoBehaviour
{
    public GameObject menu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                menu.SetActive(false);
            }
            else
            {
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void Contontion()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menu.SetActive(false);
    }
    public void Exit()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        else if (NetworkClient.isConnecting)
        {
            NetworkManager.singleton.StopClient();
        }
        else if (!NetworkServer.active)
        {
            NetworkManager.singleton.StopServer();
        }
    }
}
