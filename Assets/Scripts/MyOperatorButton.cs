using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOperatorButton : MyButton
{
    public void OperatorButtonFunction()
    {
        if (LastKeyPressedIsNotOperator())
        {
            myController.MoveInputToDisplayArray();
            myController.AddToInfixArray(buttonName);
            myController.DisplayInfixArray();
            inputField.text = "";
            myController.SetLastKeyPressed(text.text);
        }
    }
}
