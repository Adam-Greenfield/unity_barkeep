using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerCombat : MonoBehaviour
{
    bool animationLocked;

    public Animator animator;
    PlayerMotor motor;
    // Use this for initialization
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        animationLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!animationLocked)
                Attack();
        }
    }

    void ResumeMoving()
    {
        motor.EnableMoving();
    }

    void Attack()
    {
        motor.DisableMoving();
        StartCoroutine(PlayAnimation("Attack", "Attack_punch", ResumeMoving));
    }

    delegate void OnFinishDelegate();

    IEnumerator PlayAnimation(string trigger, string animation, OnFinishDelegate OnFinish = null)
    {
        animationLocked = true;

        animator.SetTrigger("Attack");

        while (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer." + animation))
        {
            yield return null;
        }

        float counter = 0;
        float waitTime = animator.GetCurrentAnimatorStateInfo(0).length;

        while (counter < (waitTime))
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Done playing. Do something below!
        Debug.Log("Done Playing");

        animationLocked = false;

        if (OnFinish != null)
            OnFinish();
    }
}
