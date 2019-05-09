using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour {

    public int hp;

    public void Damage(int damage)
    {
        if (GamePhases.instance.gamePhases == Phases.FPS)
        {
            hp -= damage;
            if (hp <= 0)
            {
                this.GetComponent<Renderer>().enabled = false;
                this.GetComponent<Collider>().enabled = false;
                this.transform.GetChild(0).GetComponent<FenceTrigger>().Retarget();
                Invoke("Destroy", 1f);
            }
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up * hp);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
