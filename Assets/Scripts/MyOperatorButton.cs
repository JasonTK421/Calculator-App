﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOperatorButton : MyButton
{
    public void OperatorButtonFunction()
    {
        if (LastKeyPressedIsNumeric())
        {
            if (inputField.text != "")
            {
                myController.AddToInfixArray(inputField.text);
            }
            myController.AddToInfixArray(buttonName);
            myController.DisplayInfixArray();
            inputField.text = "";
            myController.SetLastKeyPressed(buttonName);
        }
    }
}
