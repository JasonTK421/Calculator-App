using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyController : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_InputField displayField;

    ArrayList infixArray;
    string lastKeyPressed;

    public ArrayList GetInfixArray() { return infixArray; }
    public string GetLastKeyPressed() { return lastKeyPressed; }
    public void SetLastKeyPressed(string key) { lastKeyPressed = key; }

    void Start()
    {
        infixArray = new ArrayList();
    }

    public void AddToInfixArray(string value)
    {
        infixArray.Add(value);
    }

    public void DisplayInfixArray()
    {
        displayField.text = "";
        foreach(string value in infixArray)
        {
            displayField.text += value;
            displayField.text += " ";
        }
    }

    public void ClearDisplayInputAndInfixArray()
    {
        displayField.text = "";
        inputField.text = "";
        infixArray.Clear();
    }
}
