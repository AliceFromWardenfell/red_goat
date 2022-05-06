using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerTankSpawner : MonoBehaviour
{
    public Transform m_SpawnPoint;
    public GameObject m_PlayerTank;
    //public int m_MaxPlayerAmount = 2;
    //public static int m_CurrentEnemyAmount;
    
    private void Start()
    {
        PhotonNetwork.Instantiate(m_PlayerTank.name, m_SpawnPoint.position, m_SpawnPoint.rotation);
    }
}
