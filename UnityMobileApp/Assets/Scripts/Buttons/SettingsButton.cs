using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject[] profileObjects;
    public GameObject anonPanel;
    public GameObject userPanel;
    public GameObject currentPanel;
    public bool isOnProfile = true;

    public void OnClick()
    {
        if (isOnProfile)
        {
            if (1 == 0) // проверка на авторизованость
            {
                OpenAnon();
            }
            else
            {
                OpenUser();
            }
        }
        else
        {
            OpenProfile();
        }
    }

    private void OpenAnon()
    {
        anonPanel.SetActive(true);
        currentPanel = anonPanel;
        isOnProfile = false;
        for (int i = 0; i < profileObjects.Length; i++)
        {
            profileObjects[i].SetActive(false);
        }
    }

    private void OpenUser()
    {
        userPanel.SetActive(true);
        currentPanel = userPanel;
        isOnProfile = false;
        for (int i = 0; i < profileObjects.Length; i++)
        {
            profileObjects[i].SetActive(false);
        }
    }

    private void OpenProfile()
    {
        for (int i = 0; i < profileObjects.Length; i++)
        {
            profileObjects[i].SetActive(true);
        }
        isOnProfile = true;
        currentPanel.SetActive(false);
    }
}
