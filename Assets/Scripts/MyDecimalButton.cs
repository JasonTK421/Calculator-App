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
        if (myController.GetLastKeyPressed() != "." && !InputFieldHasDecimalPoint())
        {
            inputField.text += buttonName;
            myController.SetLastKeyPressed(text.text);
        }
    }

    bool InputFieldHasDecimalPoint()
    {
        foreach (char value in inputField.text)
        {
            if (value == '.') { return true; }
        }

        return false;
    }
}
