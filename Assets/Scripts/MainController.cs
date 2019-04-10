using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    static float ZERO = 0;

    [SerializeField] TMP_InputField displayField;

    float num1;
    float num2;

    public void SetNum1(float tempNum1) { num1 = tempNum1; }
    public void SetNum2(float tempNum2) { num2 = tempNum2; }

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
