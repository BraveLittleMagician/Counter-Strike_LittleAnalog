using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputGetterMonoBehaviour : MonoBehaviour
{
    private PlayerMovementProcessMonoBehaviour _playerMovementProcess;
    private Action _isZoomPressed;
    private Action<bool> _isAttack;

    public Vector2 MoveDirection { get; private set; }
    public Vector2 LookDirection { get; private set; }
    public MetaConfigurationOfPlayerMovement MetaConfigurationOfMovementOfPlayer { get; private set; }
    public event Action IsZoomPressed
    {
        add
        {
            if (_isZoomPressed == null || !_isZoomPressed.GetInvocationList().Contains(value))
                _isZoomPressed += value;
        }
        remove
        {
            _isZoomPressed -= value;
        }
    }
    public event Action<bool> IsAttack
    {
        add
        {
            if (_isAttack == null || !_isAttack.GetInvocationList().Contains(value))
                _isAttack += value;
        }
        remove
        {
            _isAttack -= value;
        }
    }

    private void Awake()
    {
        MetaConfigurationOfPlayerMovement metaConfigationOfPlayerMovement =
            GetComponent<MetaSettingsMonoBehaviour>().PlayerMovementConfigationMeta;
        MetaConfigurationOfMovementOfPlayer =
            metaConfigationOfPlayerMovement != null ? metaConfigationOfPlayerMovement :
            throw new ArgumentNullException($"{nameof(MetaConfigurationOfPlayerMovement)} не может быть null!");
    }

    public void SetPlayerMovementProcess(PlayerMovementProcessMonoBehaviour playerMovementProcess)
    {
        _playerMovementProcess ??= playerMovementProcess;
        if (_playerMovementProcess != null)
            _playerMovementProcess.SetInputProcess(this);
    }
    #region МетодыВвода
    public void OnMove(InputValue value)
    {
        MoveDirection = value.Get<Vector2>();
    }
    public void OnLook(InputValue value)
    {
        LookDirection = value.Get<Vector2>();
    }
    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
            _isAttack?.Invoke(true);
        else
            _isAttack?.Invoke(false);
    }
    public void OnZoom(InputValue value)
    {
        if (value.isPressed)
            _isZoomPressed?.Invoke();
    }
    #endregion
}
