using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    [SerializeField] private GameObject player; // ������ �� ������

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���������, ��� � ���� ���� ����� �����
        {
            Ragdoll ragdoll = player.GetComponent<Ragdoll>();
            if (ragdoll != null)
            {
                ragdoll.Enable();
            }

        }
    }
}
