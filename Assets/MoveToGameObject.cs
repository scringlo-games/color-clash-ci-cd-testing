using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    [SerializeField] private string MoveToTag = "Player";
    [SerializeField] private float Velocity = 1;
    private GameObject MoveToObj;
    private Rigidbody2D MyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        MoveToObj = GameObject.FindGameObjectWithTag(MoveToTag);
        MyRigidBody = this.GameObject().GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    { 
        Vector2 moveDir = MoveToObj.transform.position - this.gameObject.transform.position;
        moveDir = moveDir.normalized;
        Vector2 MoveVelocity = moveDir * Velocity;
        MyRigidBody.velocity = MoveVelocity;
    }

    
}

