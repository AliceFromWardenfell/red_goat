using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyTankSpawner : MonoBehaviour
{
    public Transform[] m_SpawnPoint;
    public GameObject m_EnemyTank;
    public int m_MaxEnemyAmount = 4;
    public static int m_CurrentEnemyAmount;

    private int m_SpawnPointsNumber;

    void Start()
    {
        m_SpawnPointsNumber = m_SpawnPoint.Length;
    }

    void Update()
    {
        if (m_CurrentEnemyAmount < m_MaxEnemyAmount && PhotonNetwork.IsMasterClient)
        {
            int RandomSpawnPoint = Random.Range(0, m_SpawnPointsNumber);
            m_CurrentEnemyAmount++;
            PhotonNetwork.Instantiate(m_EnemyTank.name, m_SpawnPoint[RandomSpawnPoint].position, m_SpawnPoint[RandomSpawnPoint].rotation);
        }
    }
}
