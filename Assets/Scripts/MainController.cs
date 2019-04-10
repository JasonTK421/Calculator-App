using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    [SerializeField] Button button1;

    float num1;
    float num2;

    public void SetNum1(float tempNum1) { num1 = tempNum1; }
    public void SetNum2(float tempNum2) { num2 = tempNum2; }
}
