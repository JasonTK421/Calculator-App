using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;
using System;

public class MyController : MonoBehaviour
{
    static string ZERO = "0";
    
    [SerializeField] TMP_InputField displayField;

    string lastKeyPressed;

    void Start()
    {
        SolveProblem();
    }

    public void EqualButton()
    {
        float answer = Evaluate(displayField.text);

        displayField.text = answer.ToString();
    }

    void SolveProblem()
    {
        CreatePostfixArray(CreateInfixArray("6+5*3-(21/6.54)"));     
    }

    void CreatePostfixArray(ArrayList infix)
    {
        ArrayList postfix = new ArrayList();
        Stack tempStack = new Stack();

        foreach(string item in infix)
        {
            if (!IsOperator(item))
            {
                postfix.Add(item);
            }
            else
            {
                switch (item)
                {
                    case "(":
                        tempStack.Push(item);
                        break;
                    case ")":
                        while(tempStack.Peek().ToString() != "(")
                        {
                            postfix.Add(tempStack.Pop());
                        }
                        tempStack.Pop();
                        break;
                    default:
                        while(tempStack.Count > 0 && 
                            tempStack.Peek().ToString() != "(" && 
                            !HasPrecedence(item, tempStack.Peek().ToString()))
                        {
                            postfix.Add(tempStack.Pop());
                        }
                        tempStack.Push(item);
                        break;
                }
            }
        }
        while(tempStack.Count > 0)
        {
            postfix.Add(tempStack.Pop());
        }

        foreach (string item in postfix)
        {
            Debug.Log(item);
        }
    }

    // checks if character has precedence over stack
    bool HasPrecedence(string character, string stack)
    {
        int a = AssignValue(character);
        int b = AssignValue(stack);

        if (a > b) { return true; }
        else { return false; }
    }

    // assign and return value to operators for comparison
    int AssignValue(string myOperator)
    {
        switch (myOperator)
        {
            case "-":
                return 0;
            case "+":
                return 1;
            case "/":
                return 2;
            case "*":
                return 3;
            default:
                return 0;
        }
    }

    ArrayList CreateInfixArray(string displayText)
    {
        ArrayList infix = new ArrayList();
        string temp = "";
        string lastPosition = "";

        for (int i = 0; i < displayText.Length; i++)
        {
            string currentPosition = displayText[i].ToString();

            if (!IsOperator(currentPosition)) { temp += currentPosition; }
            else if (IsOperator(lastPosition)) { infix.Add(currentPosition); }
            else
            {
                infix.Add(temp);
                temp = "";
                infix.Add(currentPosition);
            }
            lastPosition = currentPosition;
        }
        return infix;
    }

    bool IsOperator(string character)
    {
        if (character == "(" || character == ")" || character == "*" ||
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

    public void ClearDisplayFieldAndLastKeyPressed()
    {
        displayField.text = ZERO;
        lastKeyPressed = "";
    }
}
