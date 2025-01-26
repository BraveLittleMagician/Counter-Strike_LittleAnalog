using System;
using UnityEngine;

[RequireComponent(typeof(SettingsMonoBehaviour))]
[RequireComponent(typeof(MetaSettingsMonoBehaviour))]
[RequireComponent(typeof(PlayerMovementProcessMonoBehaviour))]
[RequireComponent(typeof(InputGetterMonoBehaviour))]

public class ApplicationProcessMonoBehaviour : MonoBehaviour
{
    private PlayerMonoBehaviour _mainPlayer;

    public void Awake()
    {
        LinkObjects();
        PlayerMonoBehaviour.IAmBorn += SetMainPlayer;
    }
    public void OnDestroy()
    {
        PlayerMonoBehaviour.IAmBorn -= SetMainPlayer;
    }

    private void LinkObjects() 
    {
        PlayerMovementProcessMonoBehaviour playerMovementProcess = GetComponent<PlayerMovementProcessMonoBehaviour>();
        GetComponent<InputGetterMonoBehaviour>().SetPlayerMovementProcess(playerMovementProcess);
    }
    private void SetMainPlayer(PlayerMonoBehaviour player)
    {
        _mainPlayer ??= player;

        if (_mainPlayer == null)
            return;

        ConfigurationOfPlayerMovement configOfPlayerMovement = GetComponent<SettingsMonoBehaviour>().PlayerMovementConfigation;
        _mainPlayer.SetConfigationOfPlayerMovement(configOfPlayerMovement);
        GetComponent<PlayerMovementProcessMonoBehaviour>().SetPlayer(_mainPlayer);
    }
}