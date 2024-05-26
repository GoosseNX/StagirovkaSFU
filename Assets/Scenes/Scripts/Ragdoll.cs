using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    private List<Rigidbody> _rigidbodys; // ������ � ������������ rigidbody � collider � �������� �������� (������)
    private List<Collider> _colliders;   //
    private Animator _animator; // �������� ���������
    private Collider MainCollider; // ��� ��������� (�������)

    // �������� ������� � ��������� �����������
    private void Start()
    {
        _rigidbodys = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        _colliders = new List<Collider>(GetComponentsInChildren<Collider>());
        _animator = GetComponent<Animator>();
        MainCollider = GetComponent<Collider>();
        Disable(); // ���������� ������� �� ���������


    }

    // ����� �������� �������. �� ��������� �� ������� � �������� ���������� � ��������� iskinematic
    // ����� ������ ������ ������ �� ����� � ����� ��������� �������� ����� �� �� �������� ������� �
    // ��������� ������� �������� ����� �� ������ ������� �������� ���������
    public void Enable()
    {
        foreach (Rigidbody rigidbody in _rigidbodys)
        {
            if (rigidbody.gameObject != this.gameObject)
            {
                rigidbody.isKinematic = false;
            }
        }

        foreach (Collider collider in _colliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                collider.enabled = true;
            }
        }
        _animator.enabled = false;
        MainCollider.enabled = false;

    }

    // ����� ����������� �������. �� ��������� �� ������� � ��������� ���������� � �������� iskinematic
    // ����� �� �������� ������ �� ����� � ����� �������� �������� ����� �� ��� ��������� ������� � �������� ������� ��������
    public void Disable()
    {
        foreach (Rigidbody rigidbody in _rigidbodys)
        {
            if (rigidbody.gameObject != this.gameObject)
            {
                rigidbody.isKinematic = true;
            }

        }

        foreach (Collider collider in _colliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                collider.enabled = false;
            }
        }

        _animator.enabled = true;
        MainCollider.enabled = true;
    }
}