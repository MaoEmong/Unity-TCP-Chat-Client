using UnityEngine;

public class Start : MonoBehaviour
{
    public Animator anim;
    public float timer = 6f;
    float curTime = 0f;
    void Update()
    {
        curTime += Time.deltaTime;

        if(curTime > timer)
        {
            curTime = 0f;
            anim.SetTrigger("Action");
        }
    }

}
