using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� � ���� ���� ����� �����
        {
            GameManager.instance.PlayerDied();
            GameManager.instance.RestartScene();
        }
    }
}