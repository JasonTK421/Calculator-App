using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;

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

    ArrayList CreateInfixArray(string displayText)
    {
        ArrayList infix = new ArrayList();
        string temp = "";
        char lastPosition = '0';

        for (int i = 0; i < displayText.Length; i++)
        {
            char currentPosition = displayText[i];

            if (!IsOperand(currentPosition)) { temp += currentPosition; }
            else if (IsOperand(lastPosition)) { infix.Add(currentPosition); }
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

    bool IsOperand(char character)
    {
        if (character == '(' || character == ')' || character == '*' ||
            character == '/' || character == '+' || character == '-')
        {
            return true;
        }
        return false;
    }

    void CreatePostfixArray(ArrayList infix)
    {
        Stack postfix = new Stack();
        Stack TempStack = new Stack();
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
