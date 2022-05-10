using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TankMovement : MonoBehaviour
{
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public Vector3 m_CurrentPosition;

    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private PhotonView m_View;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    void Start()
    {
        m_View = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (m_View.IsMine)
        {
            m_CurrentPosition = transform.position;
            m_MovementInputValue = Input.GetAxis("Vertical");
            m_TurnInputValue = Input.GetAxis("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        if (m_View.IsMine)
        {
            Move();
            Turn();
        }
    }

    private void Move()
    {
        Vector3 NewMovement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + NewMovement);
    }

    private void Turn()
    {
        float NewTurn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion TurnRotation = Quaternion.Euler(0f, NewTurn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * TurnRotation);
    }
}
