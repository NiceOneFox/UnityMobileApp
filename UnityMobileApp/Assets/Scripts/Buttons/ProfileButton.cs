using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManagement.Instance.uiManager.OpenProfile();
    }
}
