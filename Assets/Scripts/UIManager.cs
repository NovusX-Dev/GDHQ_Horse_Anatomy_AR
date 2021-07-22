using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator anim;
    public int currentAnim = 0;
    public void Next()
    {
        currentAnim++;
        anim.SetInteger("nextAnim", currentAnim);

        if(currentAnim >= 3)
        {
            currentAnim = 2;
        }
    }

    public void Previous()
    {
        currentAnim --;
        anim.SetInteger("nextAnim", currentAnim);

        if(currentAnim <= 0)
        {
            currentAnim = 0;
        }
    }


}
