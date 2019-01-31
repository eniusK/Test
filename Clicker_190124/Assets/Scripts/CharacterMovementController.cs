using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour {

    private static readonly int moveHash = Animator.StringToHash("IsMove");


    [SerializeField]
    private Animator m_anim;
    [SerializeField]
    private Transform m_incomePos;
    [SerializeField]
    private int id;
    [SerializeField]
    private float xMin, xMax;

    private Rigidbody2D rb;
    private Coroutine incomeRoutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Movement());
	}

    // Update is called once per frame
    void Update()
    {
        rb.position = new Vector2( Mathf.Clamp(rb.position.x, xMin, xMax), rb.position.y);
    }

    public void SetIncomePreriod(float period)
    {
        if (incomeRoutine != null)
        {
            StopCoroutine(incomeRoutine);
        }
        incomeRoutine = StartCoroutine(Income(period));
    }

    private IEnumerator Income(float period)
    {
        WaitForSeconds gap = new WaitForSeconds(period);
        while (true)
        {
            yield return gap;
            IncomeEffect incomeEffect = IncomeEffectPool.instance.GetFromPool(0);
            incomeEffect.transform.position = m_incomePos.position;
            string income = CoworkersController.instance.GetIncome(id);
            incomeEffect.SetText(income);

            //income.SetText(count.ToString());
        }
    }

    private IEnumerator Movement()
    {
        WaitForSeconds one = new WaitForSeconds(Random.Range(1f, 2f));
        while(true)
        {
            if (Random.Range(0, 2) == 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            m_anim.SetBool(moveHash, true);
            rb.velocity = -transform.right * Random.Range(0.3f, 0.5f);
            yield return one;

            rb.velocity = Vector2.zero;
            m_anim.SetBool(moveHash, false);
            yield return one;
        }
    }
}
