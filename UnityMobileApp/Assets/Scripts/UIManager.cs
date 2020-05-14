using Photon.Pun;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject singlePlayGamePanel;
    public GameObject multiplayerGamePanel;
    public GameObject menu;
    public GameObject singleMode;
    public GameObject multiplayerMode;
    public GameObject profile;

    private GameObject singlePlayGamePanelInstance;
    private GameObject multiplayerGamePanelInstance;
    private GameObject menuInstance;
    private GameObject singleModeInstance;
    private GameObject multiplayerModeInstance;
    private GameObject profileInstance;

    private void Start()
    {
        OpenMenu();
    }

    public void OpenMenu()
    {
        menuInstance = Instantiate(menu, GameObject.Find("Canvas").transform);
    }

    public void CloseMenu()
    {
        for (int i = 0; i < menuInstance.transform.childCount; i++)
        {
            menuInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().Play(menuInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().clip.name + "Out");
        }
        Destroy(menuInstance, 1);
    }

    public void OpenSingleMode()
    {
        CloseMenu();
        singleModeInstance = Instantiate(singleMode, GameObject.Find("Canvas").transform);
    }

    public void CloseSingleMode()
    {
        for (int i = 0; i < singleModeInstance.transform.childCount; i++)
        {
            singleModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().Play(singleModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().clip.name + "Out");
        }
        Destroy(singleModeInstance, 1);
    }

    public void OpenMultiplayerMode()
    {
        CloseMenu();
        multiplayerModeInstance = Instantiate(multiplayerMode, GameObject.Find("Canvas").transform);
    }

    public void CloseMultiplayerMode()
    {
        for (int i = 0; i < multiplayerModeInstance.transform.childCount - 1; i++)
        {
            multiplayerModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().Play(multiplayerModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().clip.name + "Out");
        }
        Destroy(multiplayerModeInstance, 1);
    }

    public void MultiplayerModeRandomOponentStart()
    {
        for (int i = 0; i < multiplayerModeInstance.transform.childCount - 1; i++)
        {
            multiplayerModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().Play(multiplayerModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().clip.name + "Out");
        }
    }

    public void MultiplayerModeRandomOponentStop()
    {
        for (int i = 0; i < multiplayerModeInstance.transform.childCount - 1; i++)
        {
            multiplayerModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().Play(multiplayerModeInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().clip.name);
        }
        multiplayerGamePanelInstance = PhotonNetwork.Instantiate(multiplayerGamePanel, multiplayerGamePanel.transform);
    }

    public void OpenProfile()
    {
        CloseMenu();
        profileInstance = Instantiate(profile, GameObject.Find("Canvas").transform);
    }

    public void CloseProfile()
    {
        for (int i = 0; i < profileInstance.transform.childCount - 3; i++)
        {
            profileInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().Play(profileInstance.transform.GetChild(i).gameObject.GetComponent<Animation>().clip.name + "Out");
            if (profileInstance.transform.GetChild(i).childCount != 0)
            {
                for (int j = 0; j < profileInstance.transform.GetChild(i).childCount; j++)
                {
                    profileInstance.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Animation>().Play(profileInstance.transform.GetChild(i).GetChild(j).gameObject.GetComponent<Animation>().clip.name + "Out");
                }
            }
        }
        profileInstance.transform.GetChild(profileInstance.transform.childCount - 1).gameObject.GetComponent<Animation>().Play(profileInstance.transform.GetChild(profileInstance.transform.childCount - 1).gameObject.GetComponent<Animation>().clip.name + "Out");
        Destroy(profileInstance, 1);
    }

    public void StartSinglePlay()
    {
        singlePlayGamePanelInstance = Instantiate(singlePlayGamePanel, GameObject.Find("Canvas").transform);
    }

    public void StartMultiplayer()
    {
        multiplayerGamePanelInstance = PhotonNetwork.Instantiate(multiplayerGamePanel, multiplayerGamePanel.transform);
    }
}
