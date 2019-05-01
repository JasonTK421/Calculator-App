using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;
using System;

public class MyController : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_InputField displayField;

    ArrayList infixArray;
    string lastKeyPressed;

    void Start()
    {
        infixArray = new ArrayList();
    }

    void Update()
    {
        Debug.Log("Last key pressed: " + lastKeyPressed);
    }

    public void EqualButton()
    {
        float answer = Evaluate(inputField.text);
        inputField.text = answer.ToString();
    }

    public void SolveProblem()
    {
        MoveInputToDisplayArray();
        inputField.text = "";
        ArrayList postfixArray = new ArrayList();
        postfixArray = CreatePostfixArray(infixArray);
        foreach(string item in postfixArray)
        {
            inputField.text += item;
            inputField.text += " ";
        }
        //RunCaculations
    }

    ArrayList CreatePostfixArray(ArrayList expression)
    {
        ArrayList postfixArray = new ArrayList();
        Stack tempStack = new Stack();

        foreach(string value in expression)
        {
            if (!IsOperator(value))
            {
                postfixArray.Add(value);
            }
            else // Is operator
            {
                switch (value)
                {
                    case "(":
                        tempStack.Push(value);
                        break;
                    case ")":
                        while(tempStack.Peek().ToString() != "(")
                        {
                            postfixArray.Add(tempStack.Pop());
                        }
                        tempStack.Pop();
                        break;
                    default:
                        while(tempStack.Count > 0 && 
                            tempStack.Peek().ToString() != "(" && 
                            HasPrecedence(tempStack.Peek().ToString(), value))
                        {
                            postfixArray.Add(tempStack.Pop());
                        }
                        tempStack.Push(value);
                        break;
                }
            }
        }
        while(tempStack.Count > 0)
        {
            postfixArray.Add(tempStack.Pop());
        }
        
        // TODO remove when no longer needed for debuging
        foreach (string value in postfixArray)
        {
            Debug.Log(value);
        }

        return postfixArray;

    }

    // checks if character has precedence over stack / Order of Operations
    bool HasPrecedence(string expressionValue, string stackValue)
    {
        int a = AssignPrecedenceValueToOperators(expressionValue);
        int b = AssignPrecedenceValueToOperators(stackValue);

        if (a > b) { return true; }
        else { return false; }
    }

    // assign and return value to operators for comparison
    int AssignPrecedenceValueToOperators(string myOperator)
    {
        switch (myOperator)
        {
            case "-":
                return 0;
            case "+":
                return 1;
            case "/":
                return 2;
            case "x":
                return 3;
            default:
                return 0;
        }
    }

    public void MoveInputToDisplayArray()
    {
        infixArray.Add(inputField.text);
    }

    public void DisplayInfixArray()
    {
        displayField.text = "";
        foreach(string character in infixArray)
        {
            displayField.text += character;
            displayField.text += " ";
        }
    }

    bool IsOperator(string character)
    {
        if (character == "x" || character == "/" || character == "+" || character == "-")
        {
            return true;
        }
        return false;
    }

    static float Evaluate(string expression)
    {
        var loDataTable = new DataTable();
        var loDataColumn = new DataColumn("Eval", typeof(float), expression);
        loDataTable.Columns.Add(loDataColumn);
        loDataTable.Rows.Add(0);
        return (float)(loDataTable.Rows[0]["Eval"]);
    }

    public string GetLastKeyPressed() { return lastKeyPressed; }
    public void SetLastKeyPressed(string key) { lastKeyPressed = key; }

    public void AddToInfixArray(string value)
    {
        infixArray.Add(value);
    }

    public void ClearInputDisplayAndInfixArray()
    {
        displayField.text = "";
        inputField.text = "";
        infixArray.Clear();
    }
}
