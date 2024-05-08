using UnityEngine;

public class Quest : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator.SetTrigger("Quest");
    }

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.enabled = true;
            animator.SetTrigger("Quest");
        }
    }

    public void OnSwitchImageAnimationEnd()
    {
        animator.enabled = false;
    }
}