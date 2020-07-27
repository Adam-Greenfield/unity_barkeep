using UnityEngine;
using System.Collections;

public abstract class Combat : MonoBehaviour
{

    public Animator animator;
    protected bool animationLocked;

    [SerializeField]
    CharacterStats stats;

    // Use this for initialization
    void Start()
    {
        animationLocked = false;
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

        

        animator.SetTrigger(weapon.attackAnimation);

        //turn on hitbox
        HitBox hitBox = instWeapon.GetComponentInChildren<HitBox>();
        Debug.Log("got to hitbox");

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
        Debug.Log("entity recieved in the combat controller as " + entity);
        Combat entityComabt = entity.GetComponent<Combat>();
        //entityComabt.RecieveHit(stats.damage.GetValue() + equippedWeapon.damage);
    }

    public void RecieveHit(int damage)
    {
        Debug.Log(transform.name + " has been hit, taking " + damage + " damage");
    }
}
