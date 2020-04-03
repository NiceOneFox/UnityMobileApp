using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManagement.Instance.uiManager.OpenSingleMode();
    }
}
