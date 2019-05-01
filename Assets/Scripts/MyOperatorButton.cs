using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOperatorButton : MyButton
{
    public void OperatorButtonFunction()
    {
        if (LastKeyPressedIsNotAnOperator())
        {
            myController.MoveInputToDisplayArray();
            myController.AddToInfixArray(buttonName);
            myController.DisplayInfixArray();
            inputField.text = "";
            myController.SetLastKeyPressed(text.text);
        }
    }

    bool LastKeyPressedIsNotAnOperator()
    {
        // Check for charaters that should not be entered consecutively e.g. (/, x, -, +, .,)
        if (myController.GetLastKeyPressed() != "/" &&
            myController.GetLastKeyPressed() != "x" &&
            myController.GetLastKeyPressed() != "-" &&
            myController.GetLastKeyPressed() != "+" &&
            myController.GetLastKeyPressed() != ".")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
