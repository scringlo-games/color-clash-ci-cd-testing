using UnityEngine;

namespace ScringloGames.ColorClash.Runtime
{
    public class MoveToGameObject : MonoBehaviour
    {
        [SerializeField] private string MoveToTag = "Player";
        [SerializeField] public float Velocity = 1;
        private GameObject MoveToObj;
        private Rigidbody2D MyRigidBody;

        // Start is called before the first frame update
        void Start()
        {
            MoveToObj = GameObject.FindGameObjectWithTag(MoveToTag);
            MyRigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        { 
            Vector2 moveDir = MoveToObj.transform.position - this.gameObject.transform.position;
            moveDir = moveDir.normalized;
            Vector2 MoveVelocity = moveDir * Velocity;
            MyRigidBody.velocity = MoveVelocity;
        }

    
    }
}

