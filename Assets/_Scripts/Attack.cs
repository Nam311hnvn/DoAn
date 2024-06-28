using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Collider2D attackCollider;
    /*[SerializeField] public int attackBonus;*/

    public int attackDamage ;
    public int damageBonus ;
    public Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check hit 
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {   
            //target danh huong nao thi knock back x huong day
            Vector2 deliveredKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            //Hit target
            bool gotHit = damageable.Hit(attackDamage+damageBonus, deliveredKnockback);

            if (gotHit)
            {

                Debug.Log(collision.name + "hit for" + attackDamage+damageBonus);
            }
        }
    }

}
