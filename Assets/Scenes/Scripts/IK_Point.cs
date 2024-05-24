using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IK_Point : MonoBehaviour
{
    [SerializeField] private GameObject IK_Controller; // ����������
    [SerializeField] private GameObject IK_Position; // ������� ���� ����� ������� ����������
    [SerializeField] private MultiAimConstraint MAC = null; // MultiAimConstraint ��� ��������� ���� ��������
    [SerializeField] private float transitionDuration = 1.0f; // ����������������� ��������
    private bool YesOrNo;
    private Vector3 IKPosition; // ������� ������� ��� �����������
    private Vector3 DefaultIKPosition; // ������� �� ���������


    //��������� �� ���������
    private void Start()
    {
        YesOrNo = false;
        IKPosition = IK_Position.transform.position;
        MAC.weight = 0f;
        DefaultIKPosition = IK_Controller.transform.position;
    }


    // ������� ������� ����������� ���������� � ������� ������� (� � �������� ������ ������� �������)
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

    // ����� ���������� ������� IK
    public void IK_On()
    {
        YesOrNo = true;
        MAC.weight = 0.0f;
        StartCoroutine(Transition(1.0f));
    }

    // ����� ����������� ������� IK
    public void IK_Off()
    {
        YesOrNo = false;
        MAC.weight = 1.0f;
        StartCoroutine(Transition(0.0f));
    }

    //�������� ��� �������� ��������� ���� � MAC
    private IEnumerator Transition(float targetValue)
    {
        float timer = 0.0f;

        while (timer < transitionDuration)
        {
            MAC.weight = Mathf.Lerp(MAC.weight, targetValue, timer / transitionDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        MAC.weight = targetValue;
    }
}
