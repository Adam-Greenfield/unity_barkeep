using UnityEngine;
using System.Collections;

public abstract class Combat : MonoBehaviour
{

    public Animator animator;
    public Weapon equippedWeapon;
    public GameObject rightHandObject;

    protected GameObject instWeapon;
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

    public void EquipWeapon(Weapon weapon)
    {
        Debug.Log("Equipping weapon " + weapon);
        equippedWeapon = weapon;
        InstantiateWeapon(weapon);
    }

    public void InstantiateWeapon(Weapon weapon)
    {
        Debug.Log("Creating weapon as " + weapon.name);
        instWeapon = Instantiate(weapon.prefab);
        instWeapon.transform.SetParent(rightHandObject.transform, false);
    }

    public abstract void Attack();


    protected delegate void OnFinishDelegate();

    protected IEnumerator PlayAttackAnimation(string trigger, string animation, Animator animator, GameObject instWeapon, OnFinishDelegate OnFinish = null)
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
        Combat entityComabt = entity.GetComponent<Combat>();
        entityComabt.RecieveHit(stats.damage.GetValue() + equippedWeapon.damage);
    }

    public void RecieveHit(int damage)
    {
        Debug.Log(transform.name + " has been hit, taking " + damage + " damage");
    }
}
