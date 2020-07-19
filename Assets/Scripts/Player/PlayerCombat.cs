using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    bool animationLocked;

    public Animator animator;
    // Use this for initialization
    void Start()
    {
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

    void Attack()
    {
        StartCoroutine(PlayAnimation("Attack"));
    }

    IEnumerator PlayAnimation(string trigger)
    {
        animationLocked = true;

        animator.SetTrigger("Attack");

        while (animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Attack_punch"))
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
    }
}
