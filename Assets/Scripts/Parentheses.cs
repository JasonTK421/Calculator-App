using System.Collections;
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
        if (openingParenthesis != 0 && openingParenthesis != closingParenthesis && 
            IsNumeric(myController.GetLastKeyPressed()))
        {
            myController.AddToInfixArray(inputField.text);
            myController.AddToInfixArray(buttonName);
            myController.DisplayInfixArray();
            inputField.text = "";
            myController.SetLastKeyPressed(buttonName);
        }
    }

    public void OpeningParenthesisFunction()
    {
        if(myController.GetLastKeyPressed() == "=")
        {
            myController.ClearDisplayInputAndInfixArray();
        }
        displayField.text += buttonName;
        myController.AddToInfixArray(buttonName);
        myController.DisplayInfixArray();
        myController.SetLastKeyPressed(buttonName);
    }
}
