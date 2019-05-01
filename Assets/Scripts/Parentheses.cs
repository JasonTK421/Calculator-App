﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Parentheses : MyButton
{
    [SerializeField] TMP_InputField displayField;
    public void ClosingParenthesisFunction()
    {
        int openingParenthesis = 0;
        int closingParenthesis = 0;

        foreach (char value in displayField.text)
        {
            if (value == '(') { openingParenthesis += 1; }
            if (value == ')') { closingParenthesis += 1; }
        }

        // if (openingParenthesis == 0) do nothing
        // if (openingParenthsis == closingParenthesis) do nothing
        if (openingParenthesis != 0 && openingParenthesis != closingParenthesis && LastKeyPressedIsNotOperator())
        {
            myController.MoveInputToDisplayArray();
            myController.AddToInfixArray(buttonName);
            myController.DisplayInfixArray();
            inputField.text = "";
            myController.SetLastKeyPressed(buttonName);
        }
    }

    public void OpeningParenthesisFunction()
    {
        displayField.text += buttonName;
        myController.AddToInfixArray(buttonName);
        myController.DisplayInfixArray();
        myController.SetLastKeyPressed(buttonName);
    }
}