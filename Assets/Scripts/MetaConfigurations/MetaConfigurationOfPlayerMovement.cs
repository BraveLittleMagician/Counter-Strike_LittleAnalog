using UnityEngine;

[CreateAssetMenu(fileName = "MetaConfigationOfPlayerMovement", 
    menuName = "Scriptable Objects/MetaConfigation/MetaConfigationOfPlayerMovement")]
public class MetaConfigurationOfPlayerMovement : ScriptableObject
{
    [SerializeField]
    [Range(0.01f, 100f)]
    private float _moveSpeed = 1f;
    [SerializeField]
    [Range(0.01f, 100f)]
    private float _lookSpeed = 1f;

    public float MoveSpeed => _moveSpeed;
    public float LookSpeed => _lookSpeed;
}