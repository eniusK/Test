using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncomeEffect : Timer {

    [SerializeField]
    private Text income;

    public void SetText(string value)
    {
        income.text = value;
    }
}
