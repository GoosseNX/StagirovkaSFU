using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private float interactionRange = 4f;
    [SerializeField] GameObject interactionNULL;
    [SerializeField] private Collider MainCollider;

    private void Update()
    {
        // �������� ������� ������ ��������������
        if (Input.GetKeyDown(interactionKey))
        {
            InteractWithRay();
        }
    }

    private void InteractWithRay()
    {
        // �������� ���� �� ������ ������
        Ray ray = new Ray(interactionNULL.transform.position, interactionNULL.transform.forward);
        RaycastHit hit;

        // �������� ����������� ���� � ���������
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            // �������� ������� ���� "Actor" � �������
            if (hit.collider.CompareTag("Actor"))
            {
                Actor actor = hit.collider.GetComponent<Actor>();
                if (actor != null)
                {
                    actor.StartAction();
                }
            }
            if (hit.collider.CompareTag("Coin"))
            {
                Actor _CoinEvent = hit.collider.GetComponent<Actor>();
                if (_CoinEvent != null)
                {
                    _CoinEvent.StartAction();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (MainCollider)
        {
            if (collision.CompareTag("Actor"))
            {
                Actor actor = collision.GetComponent<Actor>();
                if (actor != null)
                {
                    actor.StartAction();
                }
            }
            
        }
    }

    // ����� �� ������� ��������� ������ ��������
    private void OnTriggerExit(Collider collision)
    {
        if (MainCollider)
        {
            if (collision.CompareTag("Actor"))
            {
                Actor actor = collision.GetComponent<Actor>();
                if (actor != null)
                {
                    actor.StopAction();
                }
            }
        }
    }

}
