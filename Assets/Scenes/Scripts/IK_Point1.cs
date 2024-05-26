using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IK_Point1 : MonoBehaviour
{
    [SerializeField] private GameObject IK_Controller; // Контроллер
    [SerializeField] private GameObject IK_Position; // Позиция куда нужно ставить контроллер
    [SerializeField] private ChainIKConstraint CIKC = null; // MultiAimConstraint для изменения веса контроля
    [SerializeField] private float transitionDuration = 1.0f; // Продолжительность перехода
    private bool YesOrNo;
    private Vector3 IKPosition; // будущая позиция для контроллера (точка интереса)
    private Vector3 DefaultIKPosition; // позиция по умолчанию


    //настройки по умолчанию
    private void Start()
    {
        YesOrNo = false;
        IKPosition = IK_Position.transform.position;
        CIKC.weight = 0f;
        DefaultIKPosition = IK_Controller.transform.position;
    }

    // Здесь я обновляю позицию пустышки-контроллера и ставлю в позицию точки интереса
    public void FixedUpdate()
    {
        if (YesOrNo == true)
        {
            IK_Controller.transform.position = IKPosition;
        }
        else
        {
            IK_Controller.transform.position = DefaultIKPosition;
        }
    }

    // метод включающий влияние IK
    public void IK_On()
    {
        YesOrNo = true;
        CIKC.weight = 0.0f;
        StartCoroutine(Transition(1.0f));
        Invoke("IK_Off", 1.0f);
    }

    // метод выключающий влияние IK
    public void IK_Off()
    {
        YesOrNo = false;
        CIKC.weight = 1.0f;
        StartCoroutine(Transition(0.0f));

    }

    //корутина для плавного изменения веса в CIKC
    private IEnumerator Transition(float targetValue)
    {
        float timer = 0.0f;

        while (timer < transitionDuration)
        {
            CIKC.weight = Mathf.Lerp(CIKC.weight, targetValue, timer / transitionDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        CIKC.weight = targetValue;
    }
}
