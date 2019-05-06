using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public int hp;

    public void Damage(int damage)
    {
        if(GamePhases.instance.gamePhases == Phases.FPS)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
