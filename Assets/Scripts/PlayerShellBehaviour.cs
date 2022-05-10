using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerShellBehaviour : MonoBehaviour
{
    public float m_ShellLifeTime = 4f;

    void Start()
    {
        Destroy(gameObject, m_ShellLifeTime);
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy" && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Destroy(Other.gameObject);
            EnemyTankSpawner.m_CurrentEnemyAmount--;
        }
        if (Other.tag == "Player" && PhotonNetwork.IsMasterClient)
        {
            // Heal Ally
        }
        Destroy(gameObject);
    }
}
