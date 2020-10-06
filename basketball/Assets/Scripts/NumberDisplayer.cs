﻿using System;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;

public class NumberDisplayer : MonoBehaviour
{
    public IntVariable number;
    public TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent.text = number.Value.ToString();
    }

    public void OnValueUpdate ()
    {
        textComponent.text = number.Value.ToString();
    }
}
