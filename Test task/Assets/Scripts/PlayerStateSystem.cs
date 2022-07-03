using UnityEngine;

public class PlayerStateSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerStateData[] _playerState;
    [SerializeField]
    private PlayerStateData _currentPlayerState;

 
    private void Update()
    {

        if (_currentPlayerState._isStateFinished)
        {
            _currentPlayerState.ResetState();
            SetCurrentState();
        }
        else
        {
            _currentPlayerState.StateRun();
        }
    }

    public void SetCurrentState()
    {
        foreach (PlayerStateData state in _playerState)
        {
            if (_currentPlayerState != state)
            {
                _currentPlayerState = state;
                break;
            }
        }
    }
}
