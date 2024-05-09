using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject ObjectForAction;
    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip Clip;

    // Метод для включения обьекта
    public void ObjectOn()
    {
        ObjectForAction.SetActive(true);
        Source.PlayOneShot(Clip);
    }

    // Метод для выключения обьекта
    public void ObjectOff()
    {
        Source.PlayOneShot(Clip); // Воспроизвести звук
        float delay = Clip.length; // Получить длину звука
        StartCoroutine(DisableObjectDelayed(delay)); // Запустить корутину для отключения объекта с задержкой
    }

    private IEnumerator DisableObjectDelayed(float delay)
    {
        yield return new WaitForSeconds(delay); // Ждать заданное количество секунд (длину звука)
        ObjectForAction.SetActive(false); // Отключить объект
    }

}
