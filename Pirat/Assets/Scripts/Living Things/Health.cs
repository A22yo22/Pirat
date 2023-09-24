using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum living_form
{
    cat,
    walking_rat,
    flying_rat
}

public class Health : MonoBehaviour
{
    public int health;

    public living_form form;

    [Header("Rat scores")]
    public int walking_rat = 50;
    public int flying_rat = 100;

    [Header("Animation")]
    public Animator rat_ani_contoller;

    public void Add_Health(int amount)
    {
        health += amount;
    }

    public void Subtract_Health(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        switch (form)
        {
            case living_form.cat:
                break;

            case living_form.walking_rat:
                ScoreManager.instance.Add_Score(walking_rat);
                GetComponent<RatMovement>().rat_move_speed = 0f;
                break;

            case living_form.flying_rat:
                ScoreManager.instance.Add_Score(flying_rat);
                break;
        }

        rat_ani_contoller.SetTrigger("Dead");

        yield return new WaitForSeconds(0.7f);

        Destroy(gameObject);
    }
}
