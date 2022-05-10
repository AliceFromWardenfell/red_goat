using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField m_CreateInput;
    public TMP_InputField m_JoinInput;
    public int m_MaxPLayerNumber = 2;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(m_CreateInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(m_JoinInput.text);
    }
   
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("GameScene");
    }
}
