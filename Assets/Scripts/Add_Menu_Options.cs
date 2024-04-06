using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;
public class Add_Menu_Options : MonoBehaviour
{
    public TextMeshProUGUI ipAddressInputField;
    public NetworkManager networkManager;

    public void SetNetworkAddress()
    {
        string ipAddress = ipAddressInputField.text;
        networkManager.networkAddress = ipAddress;
        Debug.Log("Network address set to: " + ipAddress);
    }
}

