using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInputFieldValidator : MonoBehaviour
{
    [SerializeField] private InputField _tileInputField;

    public InputField TileInputField
    {
        get => _tileInputField;
        set => _tileInputField = value;
    }

    private void Awake()
    {
        TileInputField.onValidateInput += PositiveNumbersValidate;
    }

    private char PositiveNumbersValidate(string text, int pos, char ch)
    {
        //Checks if a digit is entered....
        if (ch >= '0' && ch <= '9')
            //Checks if a whole number is not greater than 50....
            if (int.Parse(text.Insert(text.Length, ch.ToString())) <= 50)
                return ch;
        return (char)0;
    }
}
