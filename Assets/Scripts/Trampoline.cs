using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpPower = 15f;
    public Animator anim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            player.rigidbody.AddForce(Vector3.up * jumpPower,ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }
    }
}
