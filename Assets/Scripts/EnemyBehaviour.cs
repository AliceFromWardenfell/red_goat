using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject m_Shell;
    public Transform m_ShellLaunchTransform;
    public float m_ShootingRate = 5f;
    public float m_TankSpeed = 5f;
    public float m_ShellSpeed = 5f;

    private GameObject m_PersonalTarget;

    void Start()
    {
        if (!PhotonNetwork.IsMasterClient) return;
        GameObject[] PlayerTanks = GameObject.FindGameObjectsWithTag("Player");
        if (PlayerTanks.Length > 0)
        {
            m_PersonalTarget = PlayerTanks[Random.Range(0, PlayerTanks.Length)];
        }
        StartCoroutine(DelayedShot());
    }

    void Update()
    {
        if (!PhotonNetwork.IsMasterClient || !m_PersonalTarget) return;
        transform.LookAt(m_PersonalTarget.transform.position);
        GetComponent<Rigidbody>().velocity = transform.forward * m_TankSpeed;
    }

    IEnumerator DelayedShot()
    {
        yield return new WaitForSeconds(m_ShootingRate);
        GameObject ShellInstance = PhotonNetwork.Instantiate(m_Shell.name, m_ShellLaunchTransform.position, m_ShellLaunchTransform.rotation);
        ShellInstance.GetComponent<Rigidbody>().velocity = m_ShellSpeed * m_ShellLaunchTransform.forward;
        StartCoroutine(DelayedShot());
    }
}
