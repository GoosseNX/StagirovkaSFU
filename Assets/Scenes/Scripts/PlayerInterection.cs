using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E; // ������ ��� ��������������
    [SerializeField] private float interactionRange = 4f; // ���������� ��� ��������������
    [SerializeField] GameObject interactionNULL; // �������� ��� ����� ����
    [SerializeField] private AudioClip[] footsteps;
    AudioSource playerAudio;


    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        // �������� ������� ������ ��������������
        if (Input.GetKeyDown(interactionKey))
        {
            InteractWithRayForward();
        }
    }

    private void InteractWithRayForward()
    {
        // �������� ���� �� ��������
        Ray RayFrwd = new Ray(interactionNULL.transform.position, interactionNULL.transform.forward);
        Ray RayDwn = new Ray(interactionNULL.transform.position, -interactionNULL.transform.up);
        RaycastHit hit;

        // �������� ����������� ���� � ���������
        if (Physics.Raycast(RayFrwd, out hit, interactionRange))
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
        }
        if (Physics.Raycast(RayDwn, out hit, interactionRange))
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
        }
    }

    private void OnTriggerEnter(Collider collision)
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


    // ����� �� ������� ��������� ������ ��������
    private void OnTriggerExit(Collider collision)
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

    // ����� ��� ������������� ������ �����. ���������� ������ � ����� �������� - �� ��� ����� ����� �������.
    void FootStep()
    {
        int randInd = Random.Range(0, footsteps.Length);
        playerAudio.PlayOneShot(footsteps[randInd]);
    }
    void Grub()
    {


    }

}
