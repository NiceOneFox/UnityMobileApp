using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOponentButton : MonoBehaviour
{
    public void OnClick()
    {
        LobbyManager.Instance.JoinRoom();
        GameManagement.Instance.uiManager.MultiplayerModeRandomOponentStart();
    }

    public void OnCancelClick()
    {
        GameManagement.Instance.uiManager.MultiplayerModeRandomOponentStop();
        LobbyManager.Instance.Leave();
    }
}
