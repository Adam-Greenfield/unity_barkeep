/*
 * TODO abstract comabt out into player and Enemy combat
 * 
 * using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Attack()
    {
        instWeapon = playerManager.GetInstWeapon();
        Debug.Log("Atacking with " + playerManager.equippedWeapon);

        motor.DisableMoving();
        motor.FaceMouse();

        StartCoroutine(PlayAttackAnimation("Attack", "Attack_punch", ResumeMoving));
    }

    delegate void OnFinishDelegate();

    IEnumerator PlayAttackAnimation(string trigger, string animation, OnFinishDelegate OnFinish = null)
    {
        animationLocked = true;

        animator.SetTrigger(trigger);

        //turn on hitbox
        HitBox hitBox = instWeapon.GetComponentInChildren<HitBox>();
        Debug.Log("got to hitbox");

        hitBox.onTriggerActivatedCallback += HitTarget;

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

        animationLocked = false;

        if (OnFinish != null)
            OnFinish.Invoke();
    }

    void HitTarget(Collider entity)
    {
        Debug.Log("entity recieved in the combat controller as " + entity);
    }
}
*/