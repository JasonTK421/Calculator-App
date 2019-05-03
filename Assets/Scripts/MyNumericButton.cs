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

        inputField.text += buttonName;
        myController.SetLastKeyPressed(buttonName);
    }
}
