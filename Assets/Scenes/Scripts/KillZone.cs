using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    [SerializeField] private GameObject player; // Ссылка на игрока

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что в килл зону вошел игрок
        {
            Ragdoll ragdoll = player.GetComponent<Ragdoll>();
            if (ragdoll != null)
            {
                ragdoll.Enable();
            }

        }
    }
}
