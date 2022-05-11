using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyShellBehaviour : MonoBehaviourPun
{
    public float m_ShellLifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, m_ShellLifeTime);
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            PhotonView OtherView = Other.GetComponent<PhotonView>();
            if (OtherView)
            {
                photonView.RPC("DestroyPlayer", RpcTarget.All, OtherView.ViewID);
            }
        }
        photonView.RPC("BlowShell", RpcTarget.All);
    }

    [PunRPC]
    public void BlowShell()
    {
        Destroy(gameObject);
    }

    [PunRPC]
    public void DestroyPlayer(int EnemyViewID)
    {
        PhotonView EnemyView = PhotonView.Find(EnemyViewID);
        if (EnemyView.IsMine)
        {
            PhotonNetwork.Destroy(EnemyView.gameObject);
        }
    }

}
