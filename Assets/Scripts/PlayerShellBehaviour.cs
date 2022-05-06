using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShellBehaviour : MonoBehaviour
{
    public float m_ShellLifeTime = 4f;

    void Start()
    {
        Destroy(gameObject, m_ShellLifeTime);
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy")
        {
            Destroy(Other.gameObject);
            EnemyTankSpawner.m_CurrentEnemyAmount--;
        }
        if (Other.tag == "Player")
        {
            // Heal Ally
        }
        Destroy(gameObject);
    }
}
