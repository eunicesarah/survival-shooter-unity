using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{

    public Image background;
    public Animator animator;
    private Sprite tempsprite;
    private int transitionCount = -1;

    public void SwitchImage(Sprite sprite)
    {
        transitionCount++;
        tempsprite = sprite;
        //background.sprite = tempsprite;
        animator.enabled = true;
        animator.SetTrigger("Trans" + transitionCount.ToString());
        //Debug.Log("SwitchImageToNext" + transitionCount.ToString());
    }

    public void SetImage(Sprite sprite)
    {
       
      background.sprite = sprite;
        
    }

    public void OnSwitchImageAnimationEnd()
    {

        animator.enabled = false;
        background.sprite = tempsprite;
        //Debug.Log("Masuk");
    }
}
