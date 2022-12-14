using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private InputField _tileInputField;

    public InputField TileInputField
    {
        get => _tileInputField;
        set => _tileInputField = value;
    }

    public void StartGame()
    {
        int mazeTiles = int.Parse(TileInputField.text);
        ApplicationModel.MazeTiles = mazeTiles >= 5 ? mazeTiles : 5;
        SceneManager.LoadScene("Game");
    }
}
