using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public float m_ShellLifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, m_ShellLifeTime);
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Vehicle")
        {
            Destroy(Other.gameObject);
        }
        Destroy(gameObject);
    }
}
