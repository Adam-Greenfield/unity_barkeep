using UnityEngine;
using System.Collections;

public abstract class Combat : MonoBehaviour
{

    public Animator animator;

    [System.NonSerialized]
    public bool animationLocked = false;

    protected bool hitTargetInAnimation;

    protected CharacterStats stats;
    // Use this for initialization
    protected virtual void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public abstract void Attack();


    public abstract void Block();

    public abstract void StopBlocking();


    //get stats depending on class
    protected abstract void SetStats();

    protected delegate void OnFinishDelegate();

    protected void PlayAttackAnimation(Weapon weapon, GameObject instWeapon, OnFinishDelegate OnFinish = null)
    {
        animationLocked = true;
        hitTargetInAnimation = false;

        animator.SetTrigger(weapon.attackAnimation);

        //turn on hitbox
        HitBox hitBox = instWeapon.GetComponentInChildren<HitBox>();

        hitBox.onTriggerActivatedCallback += HitTarget;

        StartCoroutine(EnumerateAnimation(weapon.attackAnimation));

        animationLocked = false;

        if (OnFinish != null)
            OnFinish.Invoke();
    }

    protected void PlayDefendAnimation(IBlocker blockingEquipment, OnFinishDelegate OnFinish = null)
    {
        animationLocked = true;

        Debug.Log("defending coroutine");

        animator.SetTrigger(blockingEquipment.blockAnimation);

        StartCoroutine(EnumerateAnimation(blockingEquipment.blockAnimation));

        animationLocked = false;

        if (OnFinish != null)
            OnFinish.Invoke();
    }

    protected void StopDefendAnimation(IBlocker blockingEquipment)
    {
        animator.ResetTrigger(blockingEquipment.blockAnimation);
    }

    private IEnumerator EnumerateAnimation(string animationLayer)
    {
        //this function waits untill the animation starts, and then waits the length of the animations running time to finish
        while (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer." +  animationLayer))
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
    }

    void HitTarget(Collider entity)
    {
        if (!hitTargetInAnimation)
        {
            //figure out if we've hit a target or a block
            Debug.Log(stats.damage.GetValue());            
            Combat entityCombat = entity.GetComponent<Combat>();

            if(entityCombat != null)
            {
                entityCombat.RecieveHit(stats.damage.GetValue());
                hitTargetInAnimation = true;
            }

            BlockBox entityBlockBox = entity.GetComponent<BlockBox>();

            if(entityBlockBox != null)
            {
                //have we hit a block or a parry?
                Debug.Log("Something has blocked our attack!");
                hitTargetInAnimation = true;
            }
        }
    }

    public void RecieveHit(int damage)
    {
        Debug.Log(transform.name + " has been hit, taking " + damage + " damage");
        stats.TakeDamage(damage);
    }
}
