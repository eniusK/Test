using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public static UIController instance;

    public static readonly int windowOpenHash = Animator.StringToHash("IsOn");

    [SerializeField]
    private Image gaugeBar;
    [SerializeField]
    private Text gaugeText;

    [SerializeField]
    private Animator[] slideWindowAnim;

    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //// Use this for initialization
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update () {

    //}

    public void ShowGauge(float amount)
    {
        gaugeBar.fillAmount = amount;
        gaugeText.text = amount.ToString("P0");
    }

    //public void ShowGauge(float amount, double current, double max)
    //{
    //    gaugeBar.fillAmount = amount;
    //    gaugeText.text = amount.ToString("P0");
    //    gaugeText.text = string.Format("{0}/{1}", current.ToString("F0"), max.ToString("F0"));
    //}

    public void OpenWindow(int id)
    {
        slideWindowAnim[id].SetBool(windowOpenHash, true);
    }

    public void CloseWindow(int id)
    {
        slideWindowAnim[id].SetBool(windowOpenHash, false);
    }
}
