using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Rigidbody2D rb;
  private BoxCollider2D coll;
  private Animator anim;
  private SpriteRenderer sprite;
  private enum MovementState {idle, running, jumping, falling}
  private float dirX = 0f;
  [SerializeField] private LayerMask jumpableGround;
  [SerializeField] private float moveSpeed = 7f;
  [SerializeField] private float jumpForce = 14f;


  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    coll = GetComponent<BoxCollider2D>();
    sprite = GetComponent<SpriteRenderer>();
 
  }

    // Update is called once per frame
  private void Update()
  {
    dirX = Input.GetAxis("Horizontal");
    rb.velocity = new UnityEngine.Vector2(dirX * moveSpeed, rb.velocity.y);

    if(Input.GetButtonDown("Jump") && IsGrounded() == true)
    {
      rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpForce);
    }

    UpdateAnimationState();

      
  }

  private void UpdateAnimationState()
  {
    MovementState state;
    if(dirX > 0f)
    {
      state = MovementState.running;
      sprite.flipX = false; 
    }
    else if (dirX < 0f)
    {
      state = MovementState.running;
      sprite.flipX = true;
    }
    else
    {
      state = MovementState.idle;
    }
    if (rb.velocity.y > .1f)
    {
      state = MovementState.jumping;
    }
    else if (rb.velocity.y < -.1f)
    {
      state = MovementState.falling;
    }

    anim.SetInteger("state", (int)state);
  }

  private bool IsGrounded()
  {
    return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, UnityEngine.Vector2.down, .1f, jumpableGround );
  }

}
