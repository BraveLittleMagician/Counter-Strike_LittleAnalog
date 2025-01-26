using UnityEngine;
public class SettingsMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private ConfigurationOfPlayerMovement _configationOfPlayerMovement;

    public ConfigurationOfPlayerMovement PlayerMovementConfigation => _configationOfPlayerMovement;
}