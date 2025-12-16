using UnityEngine;

public class Fruits : MonoBehaviour
{
    private Animator animator;
    private bool isCollected = false;

    // 과일 획득 시 추가될 점수
    public int scoreValue = 100;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isCollected) return;

        if (collision.CompareTag("Player"))
        {
             // 점수 추가
            GameManager.Instance.AddScore(scoreValue);
            
            isCollected = true;
            animator.SetTrigger("Collected");
        }
    }

    // 애니메이션 이벤트 호출용
    public void DisableFruit()
    {
        gameObject.SetActive(false);
    }
}
