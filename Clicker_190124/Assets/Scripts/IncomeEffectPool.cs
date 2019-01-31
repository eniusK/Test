using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeEffectPool : MonoBehaviour {

    public static IncomeEffectPool instance;

    [SerializeField]
    private Transform canvas;
    [SerializeField]
    private IncomeEffect[] prefabs;

    private List<IncomeEffect>[] pool;

    private void Awake()
    {
        if (instance == null)
        {
            pool = new List<IncomeEffect>[prefabs.Length];

            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = new List<IncomeEffect>();
            }

            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    //void Start () {

    //}

    public IncomeEffect GetFromPool(int index)
    {
        for (int i = 0; i < pool[index].Count; i++)
        {
            if (!pool[index][i].gameObject.activeInHierarchy)
            {
                pool[index][i].gameObject.SetActive(true);
                return pool[index][i];
            }
        }
        IncomeEffect temp = Instantiate(prefabs[index], canvas);
        pool[index].Add(temp);
        return temp;
    }
}
