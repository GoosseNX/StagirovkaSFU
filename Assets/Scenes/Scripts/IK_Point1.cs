using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IK_Point1 : MonoBehaviour
{
    [SerializeField] private GameObject IK_Controller; //  онтроллер
    [SerializeField] private GameObject IK_Position; // ѕозици€ куда нужно ставить контроллер
    [SerializeField] private ChainIKConstraint CIKC = null; // MultiAimConstraint дл€ изменени€ веса контрол€
    [SerializeField] private float transitionDuration = 1.0f; // ѕродолжительность перехода
    private bool YesOrNo;
    private Vector3 IKPosition; // будуща€ позици€ дл€ контроллера
    private Vector3 DefaultIKPosition; // позици€ по умолчанию


    //настройки по умолчанию
    private void Start()
    {
        YesOrNo = false;
        IKPosition = IK_Position.transform.position;
        CIKC.weight = 0f;
        DefaultIKPosition = IK_Controller.transform.position;
    }

    // костыль который передвигает контроллер в позицию объекта (€ в процессе поиска лучшего решени€)
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

    // метод включающий вли€ние IK
    public void IK_On()
    {
        YesOrNo = true;
        CIKC.weight = 0.0f;
        StartCoroutine(Transition(1.0f));
        Invoke("IK_Off", 1.0f);
    }

    // метод выключающий вли€ние IK
    public void IK_Off()
    {
        YesOrNo = false;
        CIKC.weight = 1.0f;
        StartCoroutine(Transition(0.0f));

    }

    //корутина дл€ плавного изменени€ веса в CIKC
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
