using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectType
{
    None = -1,
    touch,
    phaseShift,
    Max
}

public class TouchManager : MonoBehaviour {

    [SerializeField]
    private EffectPool pool;

	// Use this for initialization
	//void Start () {
		
	//}

#if UNITY_EDITOR
    //에디터 전용 파트
#elif UNITY_ANDROID || UNITY_IOD
    //안드 or ios 디바이스 전용파트
#endif

    // Update is called once per frame
    void Update () {

        if(Touch())
        {
            //클릭기능구현 implement click function
            GameController.instance.Touch();
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GenerateRay(Input.mousePosition);

            RaycastHit rayHit;

            if (Physics.Raycast(ray, out rayHit))
            {
                if (rayHit.collider.gameObject == gameObject)
                {
                    GameObject effect = pool.GetFromPool((int)eEffectType.touch);
                    effect.transform.position = rayHit.point;
                    GameController.instance.Touch();
                    // 이펙트 배치
                    // 터치기능 호출
                }
            }
        }
#endif
    }
    

    private Ray GenerateRay(Vector3 ScreenPoint)
    {
        Vector3 near = Camera.main.ScreenToWorldPoint(new Vector3(ScreenPoint.x, ScreenPoint.y, Camera.main.nearClipPlane));
        Vector3 far = Camera.main.ScreenToWorldPoint(new Vector3(ScreenPoint.x, ScreenPoint.y, Camera.main.farClipPlane));

        return new Ray(near, far - near);
    }

    private bool Touch()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = GenerateRay(touch.position);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit))
                {
                    if (rayHit.collider.gameObject == gameObject)
                    {
                        GameObject effect = pool.GetFromPool((int)eEffectType.touch);
                        effect.transform.position = rayHit.point;

                        return true;
                    }
                }
            }
        }

        return false;
    }
}
