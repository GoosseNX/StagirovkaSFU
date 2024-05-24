using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour
{
    public Transform handAttachmentPoint; // пустышка на руке персонажа
    private Collider _collider; // колайдер объекта(ключа)
    private Transform _transform; //трансформ объекта(ключа)

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _transform = GetComponent<Transform>();
    }
    public void GrubItem()
    {
        Invoke("Grub",1.0f);

    }

    // метод который привязывает объект к пустышке которая находиться на руке а также устанавливает позицию и поворот как у пустышки
    private void Grub()
    {
        _transform.SetParent(handAttachmentPoint, true);
        _transform.position = handAttachmentPoint.position;
        _transform.rotation = handAttachmentPoint.rotation;
        _collider.enabled = false;
    }

}
