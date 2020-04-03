using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManagement.Instance.uiManager.OpenMultiplayerMode();
    }
}
