using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerTankSpawner : MonoBehaviour
{
    public Transform m_SpawnPoint;
    public GameObject m_PlayerTank;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.Instantiate(m_PlayerTank.name, m_SpawnPoint.position, m_SpawnPoint.rotation);
    }
}
