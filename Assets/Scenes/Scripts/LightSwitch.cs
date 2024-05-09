using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject ObjectForAction;
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip Clip;

    // ����� ��� ��������� �������
    public void ObjectOn()
    {
        ObjectForAction.SetActive(true);
        Source.PlayOneShot(Clip);
    }

    // ����� ��� ���������� �������
    public void ObjectOff()
    {
        Source.PlayOneShot(Clip); // ������������� ����
        float delay = Clip.length; // �������� ����� �����
        StartCoroutine(DisableObjectDelayed(delay)); // ��������� �������� ��� ���������� ������� � ���������
    }

    private IEnumerator DisableObjectDelayed(float delay)
    {
        yield return new WaitForSeconds(delay); // ����� �������� ���������� ������ (����� �����)
        ObjectForAction.SetActive(false); // ��������� ������
    }

}
