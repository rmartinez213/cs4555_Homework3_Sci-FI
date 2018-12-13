using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{

    private int damage = 1;


    void OnTriggerStay(Collider collisionObject)
    {
        Debug.Log(collisionObject.gameObject.name);

        if (collisionObject.gameObject.name == "parasite_l_starkie" || collisionObject.gameObject.name == "vanguard_t_choonyung" || collisionObject.gameObject.name == "parasite_l_starkie(Clone)" || collisionObject.gameObject.name == "vanguard_t_choonyung(Clone)" || collisionObject.gameObject.name == "mutant")
        {
            ReactiveTarget target = collisionObject.GetComponent<ReactiveTarget>();
            target.ReactToHit(damage);
            Debug.Log("enemy get hurt");
        }
    }
}