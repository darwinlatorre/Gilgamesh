using UnityEngine;
namespace GILGAMESH
{
    public class CharacterLocomotionManager : MonoBehaviour
    {
        CharacterManager character;

        [Header("Ground Check & Jumping")]
        [SerializeField] protected float gravityForce = -5.55f;
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float groundCheckSphereRaius = 1;
        [SerializeField] protected Vector3 yVelocity;
        [SerializeField] protected float groundedYVelocity = -20;
        [SerializeField] protected float dallStartYVelocity = -5;
        protected bool fallingVelocityHasBeenSet = false;
        [SerializeField] protected float inAirTimer = 0;

        [Header("Flags")]
        public bool isRolling = false;
        public bool canRotate = true;
        public bool canMove = true;
        public bool isGrounded = true;

        protected virtual void Awake()
        {

        }

        protected virtual void Update()
        {
        }

        protected void HandleGroundCheck()
        {
        }

        protected void OnDrawGizmosSelected()
        {
            
        }

        public void EnableCanRotate()
        {
            canRotate = true; 
        }
        public void DisableCanRotate()
        {
            canRotate = false;
        }
    }
}
