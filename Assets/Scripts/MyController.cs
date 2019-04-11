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

    public void EqualButton()
    {
        float answer = Evaluate(displayField.text);

        displayField.text = answer.ToString();
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
