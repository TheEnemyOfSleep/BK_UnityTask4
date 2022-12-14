using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CharacterController _playerObject;
    [SerializeField] private PauseMenu _pauseMenu;

    public CharacterController PlayerObject
    {
        get => _playerObject;
        set => _playerObject = value;
    }

    public PauseMenu PauseMenu
    {
        get => _pauseMenu;
        set => _pauseMenu = value;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (_playerObject == collider.GetComponent<CharacterController>())
        {
            _pauseMenu.GameFinished();
        }
    }

}
