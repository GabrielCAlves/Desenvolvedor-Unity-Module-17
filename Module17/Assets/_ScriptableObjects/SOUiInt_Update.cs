using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUiInt_Update : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;

    void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }
}
