﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyButton : MonoBehaviour
{
    [SerializeField] TMP_InputField displayField;
    [SerializeField] TMP_Text text;

    [SerializeField] string num;

    void Start()
    {
        if (!text)
        {
            Debug.Log("Please assign an Text to: " + name);
        }
        else
        {
            text.text = num;
        }
    }

    public void AddButtonNumToInputField()
    {
        if (!displayField)
        {
            Debug.Log("Please assign an inputField to: " + name);
        }
        else
        {
            displayField.text += num;
        }
    }
}