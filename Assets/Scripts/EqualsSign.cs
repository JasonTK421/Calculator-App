using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualsSign : MyButton
{
    public void EqualsSignFunction()
    {
        if (myController.GetLastKeyPressed() != "=")
        {
            myController.AddToInfixArray(inputField.text);
            inputField.text = "";
            myController.DisplayInfixArray();
            ArrayList postfixArray = new ArrayList();
            postfixArray = CreatePostfixArray(myController.GetInfixArray());

            foreach (string str in postfixArray)
            {
                Debug.Log("Contents of postfixArray: " + str);
            }

            // run calculation on postfix array
            inputField.text = SolvePostfixArray(postfixArray);
            myController.SetLastKeyPressed(buttonName);
        }
    }

    ArrayList CreatePostfixArray(ArrayList infixExpression)
    {
        ArrayList postfixArray = new ArrayList();
        Stack tempStack = new Stack();

        foreach (string value in infixExpression)
        {
            if (IsNumeric(value))
            {
                postfixArray.Add(value);
            }
            else if (!IsNumeric(value))
            {
                switch (value)
                {
                    case "(":
                        tempStack.Push(value);
                        break;
                    case ")":
                        while (tempStack.Peek().ToString() != "(")
                        {
                            postfixArray.Add(tempStack.Pop());
                        }
                        tempStack.Pop();
                        break;
                    default:
                        while (tempStack.Count > 0 &&
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
        while (tempStack.Count > 0)
        {
            postfixArray.Add(tempStack.Pop());
        }

        return postfixArray;
    }

    string SolvePostfixArray(ArrayList postfix)
    {
        Stack tempStack = new Stack();
        string operand1;
        string operand2;

        foreach (string value in postfix)
        {
            // if not an operator
            if (!IsOperator(value))
            {
                Debug.Log("Operand being pushed to stack: " + value);
                // add to stack as double
                tempStack.Push(value);
            }// else if operator
            else if (IsOperator(value))
            {
                Debug.Log("Operator being used to calculate: " + value);
                // pop value from stack and place in operand2
                operand2 = tempStack.Pop().ToString();
                // pop value from stack and place in operand1
                operand1 = tempStack.Pop().ToString();
                // place result on stack
                tempStack.Push(RunCalculation(operand1, operand2, value));
            }
        }
        return tempStack.Pop().ToString();
    }

    double RunCalculation(string operator1, string operator2, string MyOperator)
    {
        double num1 = Convert.ToDouble(operator1);
        double num2 = Convert.ToDouble(operator2);

        switch (MyOperator)
        {
            case "x":
                return num1 * num2;
            case "/":
                return num1 / num2;
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            default:
                return 0;
        }
    }
    bool IsOperator(string value)
    {
        if (value == "x" || value == "/" || value == "+" || value == "-" )
        {
            return true;
        }
        return false;
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
}
