using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerShellBehaviour : MonoBehaviourPun
{
    public float m_ShellLifeTime = 4f;

    private PhotonView m_View;

    void Start()
    {
        m_View = GetComponent<PhotonView>();
        Destroy(gameObject, m_ShellLifeTime);
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Enemy")
        {
            //PhotonNetwork.Destroy(Other.gameObject);
            PhotonView OtherView = Other.GetComponent<PhotonView>();
            if (OtherView)
            {
                photonView.RPC("DestroyEnemy", RpcTarget.MasterClient, OtherView.ViewID);
            }
        }
        if (Other.tag == "Player")
        {
            // Heal Ally
        }

        photonView.RPC("BlowUp", RpcTarget.All);
        

    }

    [PunRPC]
    public void BlowUp()
    {
        Destroy(gameObject);
    }

    [PunRPC]
    public void DestroyEnemy(int EnemyViewID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(EnemyViewID).gameObject);
        EnemyTankSpawner.m_CurrentEnemyAmount--;
    }
}
