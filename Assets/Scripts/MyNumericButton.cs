using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNumericButton : MyButton
{
    public void NumericButonFunction()
    {
        if (myController.GetLastKeyPressed() == "=")
        {
            myController.ClearDisplayInputAndInfixArray();
        }
        else if (myController.GetLastKeyPressed() == ")")
        {
            myController.AddToInfixArray("x");
            myController.DisplayInfixArray();
        }

        inputField.text += buttonName;
        myController.SetLastKeyPressed(buttonName);
    }
}
