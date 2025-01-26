using UnityEngine;

[CreateAssetMenu(fileName = "ConfigationOfPlayerMovement", 
    menuName = "Scriptable Objects/Configation/ConfigationOfPlayerMovement")]
public class ConfigurationOfPlayerMovement : ScriptableObject
{
    [SerializeField]
    [Range(0.01f, 100f)]
    private float _lookSpeed = 1f;

    public float LookSpeed => _lookSpeed;
}