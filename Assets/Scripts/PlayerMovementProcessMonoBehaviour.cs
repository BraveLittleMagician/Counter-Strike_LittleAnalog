using UnityEngine;

public class PlayerMovementProcessMonoBehaviour : MonoBehaviour
{
    private PlayerMonoBehaviour _player;
    private InputGetterMonoBehaviour _inputGetter;

    private bool _isAttack = false;

    private void OnEnable()
    {
        PerformBindings();
    }

    private void OnDisable()
    {
        _inputGetter.IsZoomPressed -= Zoom;
        _inputGetter.IsAttack -= Attack;
    }

    private void FixedUpdate()
    {
        if (_isAttack) _player.Attack();
        _player.Look(_inputGetter.LookDirection * _inputGetter.MetaConfigurationOfMovementOfPlayer.LookSpeed);
        _player.Move(_inputGetter.MoveDirection * _inputGetter.MetaConfigurationOfMovementOfPlayer.MoveSpeed);
    }

    private void Attack(bool isActive)
    {
        _isAttack = isActive;
    }
    private void Zoom()
    {
        _player?.Zoom();
    }
    public void SetPlayer(PlayerMonoBehaviour player)
    {
        _player ??= player;
    }
    public void SetInputProcess(InputGetterMonoBehaviour inputProcess)
    {
        _inputGetter ??= inputProcess;
        PerformBindings();
    }

    public void PerformBindings()
    {
        if (_inputGetter != null)
        {
            _inputGetter.IsZoomPressed += Zoom;
            _inputGetter.IsAttack += Attack;
        }
    }
}