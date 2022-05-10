using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerTankSpawner : MonoBehaviour
{
    public Transform m_SpawnPoint;
    public GameObject m_PlayerTank;
    //public int m_MaxPlayerNumber = 2;
    //public static int m_CurrentPlayerNumber;
    //private LinkedList<GameObject> m_PlayerTanks;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        //if (m_CurrentPlayerNumber < m_MaxPlayerNumber)
       // {
            PhotonNetwork.Instantiate(m_PlayerTank.name, m_SpawnPoint.position, m_SpawnPoint.rotation);
            //m_CurrentPlayerNumber++;
        //}
    }

    //public void Despawn()
    //{
    //    m_CurrentPlayerNumber--;
    //}
}
