using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private MainPlayer player;

    [SerializeField]
    private string PlayerTag;

    public InputManager GetInputManager => inputManager;
    public MainPlayer GetPlayer => player;
    public string GetPlayerTag => PlayerTag;


    private static GameManager instance;
    public static GameManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }

}
