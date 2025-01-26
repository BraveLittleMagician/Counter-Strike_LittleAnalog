using System;
using UnityEngine;

public class PlayerMonoBehaviour : MonoBehaviour
{
    private bool _isZoomed = false;

    [SerializeField]
    private Transform _head;
    private ConfigurationOfPlayerMovement _configationOfPlayerMovement;

    private void Start()
    {
        IAmBorn.Invoke(this);
    }

    public void SetConfigationOfPlayerMovement(ConfigurationOfPlayerMovement configationOfPlayerMovement)
    { 
        _configationOfPlayerMovement ??= configationOfPlayerMovement;
    }
    public void Attack()
    {
        Debug.Log("Attack!");
    }
    public void Zoom()
    {
        _isZoomed = !_isZoomed;
        if (_isZoomed)
            Debug.Log("ZoomIn");
        else
            Debug.Log("ZoomOut");
    }
    public void Look(Vector2 direction)
    {
        Vector3 loodDirection = new Vector3(direction.y, direction.x);
        _head.eulerAngles += loodDirection * _configationOfPlayerMovement.LookSpeed;
    }
    public void Move(Vector2 direction)
    {
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * Time.deltaTime;
    }

    public static event Action<PlayerMonoBehaviour> IAmBorn;
}