using UnityEngine;
using System.Collections;

public abstract class Combat : MonoBehaviour
{

    public Animator animator;
    protected bool animationLocked = false;
    protected bool hitTargetInAnimation;

    [SerializeField]
    CharacterStats stats;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void Attack();


    protected delegate void OnFinishDelegate();

    protected IEnumerator PlayAttackAnimation(Weapon weapon, Animator animator, GameObject instWeapon, OnFinishDelegate OnFinish = null)
    {
        animationLocked = true;
        hitTargetInAnimation = false;

        animator.SetTrigger(weapon.attackAnimation);

        //turn on hitbox
        HitBox hitBox = instWeapon.GetComponentInChildren<HitBox>();

        hitBox.onTriggerActivatedCallback += HitTarget;

        while (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer." + weapon.attackAnimation))
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
        if (!hitTargetInAnimation)
        {
            Combat entityComabt = entity.GetComponent<Combat>();
            entityComabt.RecieveHit(stats.damage.GetValue());
        }
        hitTargetInAnimation = true;
    }

    public void RecieveHit(int damage)
    {
        Debug.Log(transform.name + " has been hit, taking " + damage + " damage");
        stats.TakeDamage(damage);
    }
}
