using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyButton : MonoBehaviour
{
    static string STAR = "*";
    static string X = "x";

    [SerializeField] TMP_InputField displayField;
    [SerializeField] TMP_Text text;
    [SerializeField] string num;

    MyController myController;

    void Start()
    {
        myController = FindObjectOfType<MyController>();

        if (num == STAR)
        {
            text.text = X;
        }
        else
        {
            text.text = num;
        }
    }

    public void AddButtonNumToInputField()
    {
        if (!CheckLastKeyPressed())
        {
            if (displayField.text == "0")
            {
                displayField.text = "";
            }
            displayField.text += num;
        }
    }

    public void SetLastKeyPressed()
    {
        myController.SetLastKeyPressed(text.text);
    }

    bool CheckLastKeyPressed()
    {
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
