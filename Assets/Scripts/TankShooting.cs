using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public Rigidbody m_Shell;
    public Transform m_ShellLaunchTransform;
    public float m_ShellSpeed = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Rigidbody ShellInstance = Instantiate(m_Shell, m_ShellLaunchTransform.position, m_ShellLaunchTransform.rotation) as Rigidbody;
        ShellInstance.velocity = m_ShellSpeed * m_ShellLaunchTransform.forward;
    }
}
