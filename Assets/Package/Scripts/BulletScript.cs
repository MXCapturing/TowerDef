using UnityEngine;
using System.Collections;


public class BulletScript : MonoBehaviour {

	[Tooltip("Furthest distance bullet will look for target")]
	public float maxDistance = 1000000;
	RaycastHit hit;
	[Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
	public GameObject decalHitWall;
	[Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
	public float floatInfrontOfWall;
	[Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
	public GameObject bloodEffect;
	[Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
	public LayerMask ignoreLayer;

    public int damage;
    public string bulletType;

	/*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/
	void Update () {

        Debug.Log(bulletType);
        if(bulletType == "pistol" || bulletType == "assault" || bulletType == "sniper")
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
            {
                if (decalHitWall)
                {
                    if (hit.transform.tag == "Map")
                    {
                        Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
                        Destroy(gameObject);
                    }
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.transform.GetComponent<EnemyHP>().Damage(damage);
                        Debug.Log("Hit");
                        Debug.Log(damage);
                    }
                    if (hit.collider.tag == "EnemyHead")
                    {
                        hit.transform.GetComponent<EnemyHP>().Damage(damage * 2);
                        Debug.Log("HeadHit");
                        Debug.Log(damage * 2);
                    }
                }
                Destroy(gameObject);
            }
        }

        if(bulletType == "shotgun")
        {
            for (int i = 0; i < BulletNumbers.instance.shotgunBullets; i++)
            {
                var v3Offset = transform.up * Random.Range(0.0f, BulletNumbers.instance.shotgunSpread);
                v3Offset = Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), transform.forward) * v3Offset;
                var v3Hit = transform.forward + v3Offset;

                if(Physics.Raycast(transform.position, v3Hit, out hit, maxDistance, ~ignoreLayer))
                {
                    if (decalHitWall)
                    {
                        if(hit.transform.tag == "Map")
                        {
                            Instantiate(decalHitWall, hit.point + hit.normal * floatInfrontOfWall, Quaternion.LookRotation(hit.normal));
                            Destroy(gameObject);
                        }
                        if (hit.collider.tag == "Enemy")
                        {
                            hit.transform.GetComponent<EnemyHP>().Damage(damage);
                            Debug.Log("Hit");
                            Debug.Log(damage);
                        }
                        if (hit.collider.tag == "EnemyHead")
                        {
                            hit.transform.GetComponent<EnemyHP>().Damage(damage * 2);
                            Debug.Log("HeadHit");
                            Debug.Log(damage * 2);
                        }
                    }
                    Destroy(gameObject);
                }
            }
        }
		Destroy(gameObject, 0.1f);
	}

}
