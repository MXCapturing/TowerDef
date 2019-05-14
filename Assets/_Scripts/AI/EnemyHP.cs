using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public Animator _anim;

    public int hp;
    public int money;

    public void Damage(int damage)
    {
        if(GamePhases.instance.gamePhases == Phases.FPS)
        {
            hp -= damage;
            if (hp <= 0)
            {
                this.GetComponent<NavmeshTarget>().dead = true;
                Currency.instance.money += money;
                int dead = Random.Range(0, 4);
                _anim.SetTrigger("Death " + dead);
            }
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up * hp, Color.red);
    }
}
