using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private KeyCode interactionKey = KeyCode.E; // Кнопка для взаимодействия
    [SerializeField] private float interactionRange = 4f; // Расстояние для взаимодействия
    [SerializeField] GameObject interactionNULL; // Пустышка для пуска луча
    [SerializeField] private AudioClip[] footsteps;
    AudioSource playerAudio;


    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        // Проверка нажатия кнопки взаимодействия
        if (Input.GetKeyDown(interactionKey))
        {
            InteractWithRayForward();
        }
    }

    private void InteractWithRayForward()
    {
        // Создание луча от пустышки
        Ray RayFrwd = new Ray(interactionNULL.transform.position, interactionNULL.transform.forward);
        Ray RayDwn = new Ray(interactionNULL.transform.position, -interactionNULL.transform.up);
        RaycastHit hit;

        // Проверка пересечения луча с объектами
        if (Physics.Raycast(RayFrwd, out hit, interactionRange))
        {
            // Проверка наличия тега "Actor" у объекта
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
            // Проверка наличия тега "Actor" у объекта
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


    // Выход из тригера запускает второе действие
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

    // Метод для синхронизации звуков шагов. Вызывается только в самой анимации - на ней нужно ключи ставить.
    void FootStep()
    {
        int randInd = Random.Range(0, footsteps.Length);
        playerAudio.PlayOneShot(footsteps[randInd]);
    }
    void Grub()
    {


    }

}
