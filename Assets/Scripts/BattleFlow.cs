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

    //GameObject SelectorIcon;
    [SerializeField]
    private Text WinnerTest;

    private GUI testGUI;
    void Awake()
    {
        testGUI = GUI.instance;
        WinnerTest.gameObject.SetActive(false);
    }
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

        if (units[0].tag == "Ally")
            testGUI.AllowAttack();
        else
        {
            units[0].onAttack();
        }
    }

    public void UnitAct()
    {
        units[0].onAttack();

        TurnOrder();
    }

    public void SelectUnit(Combat.Unit a)   // Test For Button Selection
    {
        Debug.Log(units[0].name + " Hit " + units[0].Target.gameObject.name + " for " + units[0].Attack + " of Damage.");

        units[0].Target = a;
        units[0].onAttack();

        testGUI.ResetButtons();
        TurnOrder();
    }

    void TurnOrder()
    {
        if (checkParty(PartyA) && checkParty(PartyB))
        {



            foreach (Combat.Unit u in units)
            {
                if (u.Alive == false)
                {
                    units.Remove(u);
                    TurnOrder();
                }
            }

            //Debug.Log("TurnOver Hit");
            Combat.Unit t = units[0];
            units.Remove(units[0]);
            units.Add(t);


            /// Danger Ahead
            /// Code in progress
            /// Do not smell, touch, ingest, or even think about the following Code...

            if (units[0].gameObject.tag != "Ally")
            {
                bool b = true;
                while (b)
                {
                    int i = Random.Range(0, 2);
                    if (PartyA[i].Alive == true)
                    {
                        units[0].Target = PartyA[i];
                        b = false;
                    }
                }
                units[0].onAttack();
                TurnOrder();
            }

            else
            {
                //Debug.Log("Players Turn");
                testGUI.AllowAttack();
            }
        }

        else
        {
            if (checkParty(PartyA))
                WinnerTest.text = "Battle is Won";
            
            if (checkParty(PartyB))
                WinnerTest.text = "Battle is Lost";


            WinnerTest.gameObject.SetActive(true);
        }
    }

    bool checkParty(List<Combat.Unit> party)   // Return False is Party is Dead  && Return True if at least one is alive
    {
        int i = 0;
        int memberCount = party.Count;

        foreach(Combat.Unit n in party)
            if(n.Alive == false)
                i++;

        if (i == memberCount)
            return false;

        return true;
    }
}
