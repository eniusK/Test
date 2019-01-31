using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {
    [SerializeField]
    private Text name, level, contents, costAndPurchase, costAndPurchase10;
    [SerializeField]
    private Button purchaseButton, purchaseButton10;

    public void Init(string inputName, string inputLevel, string inputContents, string inputCost)
    {
        name.text = inputName;
        level.text = inputLevel;
        contents.text = inputContents;
        costAndPurchase.text = inputCost;
    }

    public void Renew(string inputLevel, string inputContents, string inputCost)
    {
        level.text = inputLevel;
        contents.text = inputContents;
        costAndPurchase.text = inputCost;
    }

}
