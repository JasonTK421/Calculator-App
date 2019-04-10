using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    static float ZERO = 0;

    [SerializeField] TMP_InputField displayField;

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

    public void ClearButton()
    {
        if (!displayField)
        {
            Debug.Log("Please assign an displayField to: " + name);
        }
        else
        {
            displayField.text = ZERO.ToString();
        }
    }
}
