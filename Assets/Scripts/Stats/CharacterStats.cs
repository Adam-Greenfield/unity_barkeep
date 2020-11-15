using System.Dynamic;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public class CharacterStats : MonoBehaviour
{
    protected Animator animator;

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat armour;
    public Stat damage;

    public bool isDead = false;
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;

        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " dies");

        animator.SetTrigger("Death");

        isDead = true;
    }

    public void OnEquipmentChanged(Equipment newItem, Equipment oldItem, GameObject instItem)
    {
        if (newItem != null)
        {
            armour.AddModifier(newItem.armourMod);
            damage.AddModifier(newItem.damageMod);
        }

        if (oldItem != null)
        {
            armour.RemoveModifier(oldItem.armourMod);
            damage.RemoveModifier(oldItem.damageMod);
        }
    }
}
