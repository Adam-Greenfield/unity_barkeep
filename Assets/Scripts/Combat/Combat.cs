using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterAnimator))]
public abstract class Combat : MonoBehaviour, IHittable
{

    [System.NonSerialized]
    public bool animationLocked = false;

    public BlockBox blockBox;

    protected Animator animator;

    protected bool hitTargetInAnimation;

    protected CharacterStats stats;
    // Use this for initialization
    protected virtual void Start()
    {
        SetStats();
        animator = GetComponentInChildren<Animator>();
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

    protected IEnumerator PlayAttackAnimation(Weapon weapon, GameObject instWeapon, OnFinishDelegate OnFinish = null)
    {
        animationLocked = true;
        hitTargetInAnimation = false;

        Debug.Log(weapon.attackAnimation);
        animator.SetTrigger(weapon.attackAnimation);

        //aquire and enable hitbox
        HitBox hitBox = instWeapon.GetComponentInChildren<HitBox>();

        hitBox.onTriggerActivatedCallback += HitTarget;

        yield return StartCoroutine(EnumerateAnimation(weapon.attackAnimation));

        animationLocked = false;

        if (OnFinish != null)
            OnFinish.Invoke();
    }

    protected IEnumerator PlayDefendAnimation(IBlocker blockingEquipment, OnFinishDelegate OnFinish = null)
    {
        animationLocked = true;

        animator.SetTrigger(blockingEquipment.blockAnimation);

        blockBox.active = true;

        yield return StartCoroutine(EnumerateAnimation(blockingEquipment.blockAnimation));


        if (OnFinish != null)
            OnFinish.Invoke();
    }

    protected void StopDefendAnimation(IBlocker blockingEquipment)
    {
        animator.ResetTrigger(blockingEquipment.blockAnimation);

        blockBox.active = false;

        animationLocked = false;
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
            BlockBox blockBox = entity.GetComponent<BlockBox>();

            if (blockBox)
            {
                blockBox.RecieveHit(stats.damage.GetValue());
            }
            else
            {
                Combat entityCombat = entity.GetComponent<Combat>();

                if (entityCombat)
                    entityCombat.RecieveHit(stats.damage.GetValue());
            }
            
            hitTargetInAnimation = true;

        }
    }

    public void RecieveHit(int damage)
    {
        Debug.Log(transform.name + " has been hit, taking " + damage + " damage");
        stats.TakeDamage(damage);
    }
}
