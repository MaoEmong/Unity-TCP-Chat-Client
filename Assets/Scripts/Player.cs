using UnityEngine;

public class Player : MonoBehaviour
{
    private float hAxis;                
    public float moveSpeed = 3;
    public float jumpSpeed = 3;
    private bool m_isJump = false;
    
    public Animator anim;
    public SpriteRenderer sprite;
    public Rigidbody2D rigidbody;

    void Update()
    {
        // 좌우 키입력
        hAxis = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Move", (hAxis != 0));

        // 좌우 반전
        if (hAxis > 0) sprite.flipX = false;
        else if (hAxis < 0) sprite.flipX = true;

        // 이동
        transform.position += new Vector3(hAxis, 0, 0) * moveSpeed * Time.deltaTime;

        // 점프
        if (!m_isJump && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode2D.Impulse);
            m_isJump = true;

            anim.SetBool("Jump", true);
        }

        UpdateJumpState();
    }

    // 점프 / 낙하 상태 전환
    void UpdateJumpState()
    {
        float yVel = rigidbody.linearVelocity.y;

        if (m_isJump)
        {
            // 상승 중일 때
            if (yVel > 0.1f)
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Fall", false);
            }
            // 하강 중일 때
            else if (yVel < -0.1f)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", true);
            }
        }
    }

    // 땅 충돌
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            m_isJump = false;
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
    }

    public void PlayAnimationDeath()
    {
        anim.SetTrigger("Death");
    }

    public void CallPlayerActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
