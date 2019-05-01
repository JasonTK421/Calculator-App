using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNumericButton : MyButton
{
    public void NumericButonFunction()
    {
        if (myController.GetLastKeyPressed() == "=")
        {
            myController.ClearInputDisplayAndInfixArray();
        }

        inputField.text += buttonName;
        myController.SetLastKeyPressed(text.text);
    }
}
