using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;
using System;

public class MyController : MonoBehaviour
{
    static string ZERO = "0";
    
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_InputField displayField;

    ArrayList infixArray;
    string lastKeyPressed;

    void Start()
    {
        infixArray = new ArrayList();
    }

    public void EqualButton()
    {
        float answer = Evaluate(inputField.text);
        inputField.text = answer.ToString();
    }

    public void SolveProblem()
    {
        MoveInputToDisplayArray();
        ClearInputField();
        ArrayList postfixArray = new ArrayList();
        postfixArray = CreatePostfixArray(infixArray);
        foreach(string item in postfixArray)
        {
            inputField.text += item;
            inputField.text += " ";
        }
        //RunCaculations
    }

    ArrayList CreatePostfixArray(ArrayList infix)
    {
        ArrayList tempPostfixArray = new ArrayList();
        Stack tempStack = new Stack();

        foreach(string item in infix)
        {
            if (!IsOperator(item))
            {
                tempPostfixArray.Add(item);
            }
            else // Is operator
            {
                switch (item)
                {
                    case "(":
                        tempStack.Push(item);
                        break;
                    case ")":
                        while(tempStack.Peek().ToString() != "(")
                        {
                            tempPostfixArray.Add(tempStack.Pop());
                        }
                        tempStack.Pop();
                        break;
                    default:
                        while(tempStack.Count > 0 && 
                            //tempStack.Peek().ToString() != "(" && 
                            HasPrecedence(tempStack.Peek().ToString(), item))
                        {
                            tempPostfixArray.Add(tempStack.Pop());
                        }
                        tempStack.Push(item);
                        break;
                }
            }
        }
        while(tempStack.Count > 0)
        {
            tempPostfixArray.Add(tempStack.Pop());
        }
        
        // TODO remove when no longer needed for debuging
        foreach (string item in tempPostfixArray)
        {
            Debug.Log(item);
        }

        return tempPostfixArray;

    }

    // checks if character has precedence over stack / Order of Operations
    bool HasPrecedence(string character, string stack)
    {
        int a = AssignValueToOperators(character);
        int b = AssignValueToOperators(stack);

        if (a > b) { return true; }
        else { return false; }
    }

    // assign and return value to operators for comparison
    int AssignValueToOperators(string myOperator)
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
        if (character == "(" || character == ")" || character == "x" ||
            character == "/" || character == "+" || character == "-")
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

    public void AddToInfixArray(string symbol)
    {
        infixArray.Add(symbol);
    }

    public void ClearButton()
    {
        ClearDisplayField();
        ClearInputField();
        ClearLastKeyPressed();
        ClearInfixArray();
    }

    public void ClearInfixArray()
    {
        infixArray.Clear();
    }

    public void ClearDisplayField()
    {
        displayField.text = "";
    }

    public void ClearInputField()
    {
        inputField.text = ZERO;
    }

    public void ClearLastKeyPressed()
    {
        lastKeyPressed = "";
    }
}
