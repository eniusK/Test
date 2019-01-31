using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField]
    protected float time;
    protected WaitForSeconds waiting;

    protected void Awake()
    {
        waiting = new WaitForSeconds(time);
    }

    protected void OnEnable()
    {
        StartCoroutine(Timeout());
    }

    protected IEnumerator Timeout()
    {
        yield return waiting;
        gameObject.SetActive(false);
    }
}
