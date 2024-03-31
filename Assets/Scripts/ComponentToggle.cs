using Mirror;
using UnityEngine;

public class ComponentToggle : NetworkBehaviour
{
    public GameObject componentToToggle;

    public override void OnStartServer()
    {
        base.OnStartServer();

        // Включаем компонент при подключении нового клиента
        componentToToggle.SetActive(true);
        componentToToggle.SetActive(false);
    }

    public override void OnStopServer()
    {
        base.OnStopServer();

        // Выключаем компонент при отключении клиента
        componentToToggle.SetActive(false);
        componentToToggle.SetActive(true);
        
    }
}
