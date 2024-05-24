using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour
{
    public Transform handAttachmentPoint; // �������� �� ���� ���������
    private Collider _collider; // �������� �������(�����)
    private Transform _transform; //��������� �������(�����)

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _transform = GetComponent<Transform>();
    }
    public void GrubItem()
    {
        Invoke("Grub",1.0f);

    }

    // ����� ������� ����������� ������ � �������� ������� ���������� �� ���� � ����� ������������� ������� � ������� ��� � ��������
    private void Grub()
    {
        _transform.SetParent(handAttachmentPoint, true);
        _transform.position = handAttachmentPoint.position;
        _transform.rotation = handAttachmentPoint.rotation;
        _collider.enabled = false;
    }

}
