using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllWordsButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManagement.Instance.uiManager.StartSinglePlay();
        Destroy(transform.parent.gameObject);
    }
}
