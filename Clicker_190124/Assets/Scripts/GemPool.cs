using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPool : MonoBehaviour {

    [SerializeField]
    private Gem[] prefabs;

    private List<Gem>[] pool;

    private void Awake()
    {
        pool = new List<Gem>[prefabs.Length];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = new List<Gem>();
        }
    }
    
    // Use this for initialization
 //   void Start () {
		
	//}

    public Gem GetFromPool(int index)
    {
        for (int i = 0; i < pool[index].Count; i++)
        {
            if (!pool[index][i].gameObject.activeInHierarchy)
            {
                pool[index][i].gameObject.SetActive(true);
                return pool[index][i];
            }
        }
        Gem temp = Instantiate(prefabs[index]);
        pool[index].Add(temp);
        return temp;
    }
}
