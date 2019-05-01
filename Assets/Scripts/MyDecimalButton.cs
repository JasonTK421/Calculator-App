using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDecimalButton : MyButton
{
    public void DecimalPointButton()
    {
        if (myController.GetLastKeyPressed() == "=")
        {
            myController.ClearInputDisplayAndInfixArray();
            inputField.text = "0";
        }
        if (inputField.text == "")
        {
            inputField.text = "0";
        }
        if (myController.GetLastKeyPressed() != ".")
        {
            inputField.text += buttonName;
            myController.SetLastKeyPressed(text.text);
        }
    }
}
