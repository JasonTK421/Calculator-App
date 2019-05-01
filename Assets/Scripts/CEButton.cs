using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEButton : MyButton
{
    public void CEButtonFunction()
    {
        inputField.text = "";
        myController.SetLastKeyPressed("");
    }

    public void DeleteButtonFunction()
    {
        if(inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);
        }    
    }
}
