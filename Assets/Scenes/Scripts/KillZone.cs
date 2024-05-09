using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, что в килл зону вошел игрок
        {
            GameManager.instance.PlayerDied();
            GameManager.instance.RestartScene();
        }
    }
}