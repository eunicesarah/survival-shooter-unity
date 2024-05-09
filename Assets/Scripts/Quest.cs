using UnityEngine;


namespace Nightmare
{
    public class Quest : MonoBehaviour
    {
        Animator animator;
        QuestComplete questComplete;

        void Start()
        {
            // animator.SetTrigger("Quest");
            animator = GameObject.Find("HUDCanvas").GetComponent<Animator>();
            questComplete = FindObjectOfType<QuestComplete>();
            animator.SetTrigger("Quest");
        }

        void Update()
        {
        
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // animator.enabled = true;
                if(questComplete.isQuestCompleted){
                    animator.SetTrigger("QuestCompleted");
                }
                else
                {
                    if(questComplete.isQuestJendralCompleted){
                        animator.SetTrigger("QuestRaja");
                    }
                    else{
                        animator.SetTrigger("Quest");
                    
                    }
                    // animator.SetTrigger("Quest");
                }
            }
        }

        public void OnSwitchImageAnimationEnd()
        {
            // animator.enabled = false;
        }
    }
}