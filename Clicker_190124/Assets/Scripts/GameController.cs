using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    public static GameController instance;

    private SaveData userData;

    private double maxValue;
    private double currentValue;
    private double gap;
    
    [SerializeField]
    private GemPool gemPool;
    private Gem currentGem;

    [SerializeField]
    private float levelValueWaight, levelBaseValue;
    private int levelCount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        userData = new SaveData();
        userData.money = 100;

        levelCount = 0;
        CalcMaxValue();
        currentValue = 0;
        maxValue = 100;
        gap = 5;
        
        float progress = (float)(currentValue / maxValue);
        UIController.instance.ShowGauge(progress);
        currentGem = gemPool.GetFromPool(Random.Range(0, 3));

        //currentGem.SetProgress(0);
    }
	
	// Update is called once per frame
	//void Update () {
		
	//}

    public void Touch()
    {
        currentValue += gap;
        if (currentValue > maxValue)
        {
            currentValue = 0;
            currentGem.HideGem();
            currentGem = gemPool.GetFromPool(Random.Range(0, 3));
        }
        float progress = (float)(currentValue / maxValue);
        UIController.instance.ShowGauge(progress);
        currentGem.SetProgress(progress);
    }

    public void AddMoney(double value)
    {
        userData.money += value;
    }

    private void CalcMaxValue()
    {
        maxValue = levelBaseValue * System.Math.Pow(levelValueWaight, levelCount);
    }
}

public class SaveData
{
    public double money;
    public int touchLevel;
}