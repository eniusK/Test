using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPool : MonoBehaviour {

    [SerializeField]
    private GameObject[] prefabs;

    private List<GameObject>[] pool;

    private void Awake()
    {
        pool = new List<GameObject>[prefabs.Length];

        for(int i=0; i<pool.Length; i++)
        {
            pool[i] = new List<GameObject>();
        }
    }

	// Use this for initialization
	//void Start () {
		
	//}
	
    public GameObject GetFromPool(int index)
    {
        for (int i = 0; i < pool[index].Count; i++)
        {
            if (!pool[index][i].activeInHierarchy)
            {
                pool[index][i].SetActive(true);
                return pool[index][i];
            }
        }
        GameObject temp = Instantiate(prefabs[index]);
        pool[index].Add(temp);
        return temp;
    }
}
