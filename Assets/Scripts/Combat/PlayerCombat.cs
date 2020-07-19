using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerCombat : MonoBehaviour
{
    bool animationLocked;

    public Animator animator;
    PlayerMotor motor;
    PlayerManager playerManager;
    Weapon equippedWeapon;
    GameObject instWeapon;

    // Use this for initialization
    void Start()
    {
        playerManager = PlayerManager.instance;
        motor = GetComponent<PlayerMotor>();
        animationLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!animationLocked && playerManager.equippedWeapon != null)
                Attack();
        }
    }

    void ResumeMoving()
    {
        motor.EnableMoving();
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
