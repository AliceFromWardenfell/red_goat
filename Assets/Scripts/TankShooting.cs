using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankShooting : MonoBehaviour
{
    public GameObject m_Shell;
    public Transform m_ShellLaunchTransform;
    public float m_ShellSpeed = 20f;

    private PhotonView m_View;
    
    private void Start()
    {
        m_View = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && m_View.IsMine)
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject ShellInstance = PhotonNetwork.Instantiate(m_Shell.name, m_ShellLaunchTransform.position, m_ShellLaunchTransform.rotation);
        ShellInstance.GetComponent<Rigidbody>().velocity = m_ShellSpeed * m_ShellLaunchTransform.forward;
    }
}
