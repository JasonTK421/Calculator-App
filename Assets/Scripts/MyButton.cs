using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyButton : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text text;

    [SerializeField] float num;

    void Start()
    {
        if (!text)
        {
            Debug.Log("Please assign an Text to: " + name);
        }
        else
        {
            text.text = num.ToString();
        }
    }

    public void AddButtonNumToInputField()
    {
        if (!inputField)
        {
            Debug.Log("Please assign an inputField to: " + name);
        }
        else
        {
            inputField.text += num;
        }
    }
}
