using UnityEngine;
using System.Collections;

public class CombatUnit : MonoBehaviour
{
    [SerializeField]
    private int Health;
    [SerializeField]
    private int Attack;
    [SerializeField]
    private bool isDead = false;

    // Use this for initialization
    void Start ()
    {
        EventSystem.AddSubscriber(MessageType.COMBAT, "Hit",    new Callback<int>(onHit));
        EventSystem.AddSubscriber(MessageType.COMBAT, "Dead",   new Callback(onDead));


    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void onHit(int damage)
    {
        Health -= damage;
        if(Health < 0)
        {
            Health = 0;
            EventSystem.Notify(MessageType.COMBAT, "Dead");
        }
    }

    void onDead()
    {

    }

    void onAttack()
    {

    }
}
