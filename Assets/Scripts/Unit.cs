using UnityEngine;
using System.Collections;

struct Effect
{
    UnitStat effectedStat;
    int duration;
    float modifer;
}

enum UnitStat
{
    HEALTH,
    ATTACK,
    DEFENCE,
    SPEED
}

public class Unit : MonoBehaviour
{
    public float MaxHealth  = 10;
    public float Health;
    public float Attack     = 5;
    public float Defence    = 2;
    public float Speed      = 1;
    public bool Alive       = true;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onHit()
    {

    }

    void onAttack()
    {

    }

    void onDeath()
    {

    }




}
