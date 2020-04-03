using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void OnClick()
    {
        switch (transform.parent.gameObject.name)
        {
            case "SingleMode(Clone)":
                GameManagement.Instance.uiManager.CloseSingleMode();
                GameManagement.Instance.uiManager.OpenMenu();
                break;
            case "MultiplayerMode(Clone)":
                GameManagement.Instance.uiManager.CloseMultiplayerMode();
                GameManagement.Instance.uiManager.OpenMenu();
                break;
            case "Profile(Clone)":
                GameManagement.Instance.uiManager.CloseProfile();
                GameManagement.Instance.uiManager.OpenMenu();
                break;
            default:
                GameManagement.Instance.uiManager.OpenMenu();
                break;
        }
    }
}
