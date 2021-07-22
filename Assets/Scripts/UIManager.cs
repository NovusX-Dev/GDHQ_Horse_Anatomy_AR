using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance => _instance;

    public Animator anim;
    public int currentAnim = 0;

    private void Awake()
    {
        _instance = this;
    }

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
