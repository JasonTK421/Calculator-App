using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class MyButton : MonoBehaviour
{
    [SerializeField] TMP_InputField displayField;
    [SerializeField] protected TMP_InputField inputField;
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected string buttonName;

    protected MyController myController;

    void Start()
    {
        myController = FindObjectOfType<MyController>();
        text.text = buttonName;
    }
}
