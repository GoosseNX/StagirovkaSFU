using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

    private List<Rigidbody> _rigidbodys; // Списки с компонентами rigidbody и collider у дочерних объектов (костей)
    private List<Collider> _colliders;   //
    private Animator _animator; // аниматор персонажа
    private Collider MainCollider; // его коллайдер (капсула)

    // создание списков и получение компонентов
    private void Start()
    {
        _rigidbodys = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        _colliders = new List<Collider>(GetComponentsInChildren<Collider>());
        _animator = GetComponent<Animator>();
        MainCollider = GetComponent<Collider>();
        Disable(); // отключение регдола по умолчанию


    }

    // метод включает регдолл. он пробегает по спискам и включает коллайдеры и отключает iskinematic
    // чтобы физика начала влиять на кости а также выключает аниматор чтобы он не управлял костями и
    // выключает капсулу колайдер чтобы не мешать регдолу работать правильно
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

    // метод выключающий регдолл. он пробегает по спискам и отключает коллайдеры и включает iskinematic
    // чтобы не работала физика на кости а также включает аниматор чтобы он мог управлять костями и включает капсулу колайдер
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