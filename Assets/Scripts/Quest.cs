using System.Collections;
using UnityEngine;


namespace Nightmare
{
    public class Quest : MonoBehaviour
    {
        Animator animator;
        QuestComplete questComplete;

        public bool isQuestRajaShowed = false;

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
            if(questComplete.isQuestJendralCompleted && !isQuestRajaShowed)
            {
                StartCoroutine(TriggerQuestRaja());
            }

            IEnumerator TriggerQuestRaja()
            {
                yield return new WaitForSeconds(2); // wait for 5 seconds
                animator.SetTrigger("QuestRaja");
                isQuestRajaShowed = true;
            }
        }

        public void OnSwitchImageAnimationEnd()
        {
            // animator.enabled = false;
        }
    }
}