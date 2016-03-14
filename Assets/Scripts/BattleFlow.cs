using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BattleFlow : MonoBehaviour
{
    //emulate a turn manager
    [SerializeField]
    List<Combat.Unit> units  = new List<Combat.Unit>();
    [SerializeField]
    List<Combat.Unit> PartyA = new List<Combat.Unit>();
    [SerializeField]
    List<Combat.Unit> PartyB = new List<Combat.Unit>();

    Combat.Unit CurrentUnit;

    GameObject SelectorIcon;


    void Start()
    {
        units.AddRange(FindObjectsOfType<Combat.Unit>());
        foreach (Combat.Unit t in  units)
        {
            if (t.gameObject.tag == "Ally")
                PartyA.Add(t);
            else
                PartyB.Add(t);
        }

        units = units.OrderByDescending(x => x.spd).ToList<Combat.Unit>();
    }

    public void UnitAct()
    {
        units[0].onAttack();

        TurnOrder();
    }

    public void SelectUnit()
    {
        
    }

    void TurnOrder()
    {
        Combat.Unit t = units[0];
        units.Remove(units[0]);
        units.Add(t);

        foreach (Combat.Unit u in units)
        {
            if(u.Alive == false)
            {
                units.Remove(u);
            }
        }
    }
}
