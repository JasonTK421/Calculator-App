using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class MyButton : MonoBehaviour
{
    static string STAR = "*";
    static string X = "x";

    [SerializeField] TMP_InputField displayField;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text text;
    [SerializeField] string buttonName;

    MyController myController;

    void Start()
    {
        myController = FindObjectOfType<MyController>();

        DisplayButtonName();
    }

    private void DisplayButtonName()
    {
        if (buttonName == STAR)
        {
            text.text = X;
        }
        else
        {
            text.text = buttonName;
        }
    }

    public void OperatorButtonFunction()
    {
        myController.MoveInputToDisplayArray();
        AddOperatorToInfixArray();
        myController.DisplayInfixArray();
        myController.ClearInputField();
        SetLastKeyPressed();
    }

    public void AddNumToInputField()
    {
        if (!CheckLastKeyPressed())
        {
            // Clear leading 0 
            if (inputField.text == "0") { inputField.text = ""; }

            inputField.text += buttonName;
        }
    }

    public void AddOperatorToInfixArray()
    {
        myController.AddToInfixArray(buttonName);
    }

    public void SetLastKeyPressed()
    {
        myController.SetLastKeyPressed(text.text);
    }

    bool CheckLastKeyPressed()
    {
        // Check for caraters that should not be entered consecutively e.g. (/, x, -, +, .,)
        if ((myController.GetLastKeyPressed() == "/" ||
            myController.GetLastKeyPressed() == "x" ||
            myController.GetLastKeyPressed() == "-" ||
            myController.GetLastKeyPressed() == "+" ||
            myController.GetLastKeyPressed() == ".") &&
            myController.GetLastKeyPressed() == text.text)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
