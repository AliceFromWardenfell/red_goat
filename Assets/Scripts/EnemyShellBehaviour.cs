using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShellBehaviour : MonoBehaviour
{
    public float m_ShellLifeTime = 4f;

    void Start()
    {
        Destroy(gameObject, m_ShellLifeTime);
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Destroy(Other.gameObject);
        }
        Destroy(gameObject);
    }
}
