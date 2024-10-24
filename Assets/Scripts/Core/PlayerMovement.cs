using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField] 
    private float normalSpeed;
    [SerializeField]
    private float jumpForce;
    
    private float speed;

    private Vector2 moveDirection;

    private bool isWalk;
    private bool isJump;
    private bool isGround;
    
    private GameObject playerGameObject;
    
    private Animator playerAnimator;

    private void Start()
    {
        speed = 0f;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody.position, Vector2.down, 1f, LayerMask.GetMask("Platform"));

        if (hit.collider != null)
        {
            isGround = true;
            isJump = false;
        }
        else
        {
            isGround = false;
            isJump = true;
        }

        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isJump", isJump);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    public void MovePlayerRight()
    {
        playerGameObject.transform.rotation = new Quaternion(
            playerGameObject.transform.rotation.x,
            0,
            playerGameObject.transform.rotation.z, 0);
        
        isWalk = true;
        playerAnimator.SetBool("isWalk", isWalk);
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }

    public void MovePlayerLeft()
    {
        playerGameObject.transform.rotation = new Quaternion(
            playerGameObject.transform.rotation.x,
            180,
            playerGameObject.transform.rotation.z, 0);
        
        isWalk = true;
        playerAnimator.SetBool("isWalk", isWalk);
        if (speed >= 0f)
        {
            speed = -normalSpeed;
        }
    }

    public void ResetMove()
    {
        isWalk = false;
        playerAnimator.SetBool("isWalk", isWalk);
        speed = 0f;
        
    }

    public void JumpPlayer()
    {
        if (isGround)
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }
    }

    public void SetPlayerAnimator(Animator animator)
    {
        playerAnimator = animator;
    }

    public void SetPlayerSprite(GameObject player)
    {
        playerGameObject = player;
    }
}
