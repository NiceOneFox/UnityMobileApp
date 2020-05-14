using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOutButton : MonoBehaviour
{
    public SettingsButton settings;

    public void OnClick()
    {
        settings.currentPanel = settings.anonPanel;
    }
}
