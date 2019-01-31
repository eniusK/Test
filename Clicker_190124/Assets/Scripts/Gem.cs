using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer rand;
    private float promoteGap;
    private int currentProgressPivot;

    [SerializeField]
    private EffectPool pool;


    private void Awake()
    {
        rand = GetComponent<SpriteRenderer>();
        promoteGap = 1f / sprites.Length;
    }

    private void OnEnable()
    {
        rand.sprite = sprites[0];
        currentProgressPivot = 1;
    }

    // Use this for initialization
    void Start()
    {
        pool = GameObject.FindGameObjectWithTag("EffectPool").GetComponent<EffectPool>();
    }

    public void HideGem()
    {
        gameObject.SetActive(false);
    }

    public void SetProgress(float progress)
    {
        while (currentProgressPivot * promoteGap <= progress)
        {
            if (sprites.Length > currentProgressPivot)
            {
                rand.sprite = sprites[currentProgressPivot];
                pool.GetFromPool((int)eEffectType.phaseShift).transform.position = transform.position;
            }
            currentProgressPivot++;
        }
    }
}
