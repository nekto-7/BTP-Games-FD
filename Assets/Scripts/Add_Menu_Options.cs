using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class Add_Menu_Options : MonoBehaviour
{
    public InputField inputField;
    public NetworkManager networkManager;

    private void Start()
    {
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    private void OnEndEdit(string text)
    {
        networkManager.networkAddress = text;
    }
}
