using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class MyButton : MonoBehaviour
{
    [SerializeField] protected TMP_InputField inputField;
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected string buttonName;

    protected MyController myController;

    void Start()
    {
        myController = FindObjectOfType<MyController>();
        text.text = buttonName;
    }

    protected bool LastKeyPressedIsNumeric()
    {
        // Check for charaters that should not be entered consecutively e.g. (/, x, -, +, .)
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
