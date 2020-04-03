using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private static GameManagement instance;
    public static GameManagement Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManagement>();
            return instance;
        }
    }

    [HideInInspector]
    public InitializeAllWords allWords;
    [HideInInspector]
    public UIManager uiManager;

    private void Start()
    {
        allWords = GetComponent<InitializeAllWords>();
        uiManager = GetComponent<UIManager>();
    }
}
