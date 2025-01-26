using UnityEngine;

public class MetaSettingsMonoBehaviour : MonoBehaviour
{
    [SerializeField]
    private MetaConfigurationOfPlayerMovement _metaConfigationOfPlayerMovement;

    public MetaConfigurationOfPlayerMovement PlayerMovementConfigationMeta => _metaConfigationOfPlayerMovement;
}