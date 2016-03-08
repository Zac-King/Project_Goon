using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class UnitTest : MonoBehaviour
{
    //emulaqte a turn manager 
    [SerializeField]
    List<Combat.Unit> units;
    void Start()
    {
        units.AddRange(FindObjectsOfType<Combat.Unit>());
        SortBySpeed();
    }
 
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (units[0] != null)
            {
                units[0].GoToState(Combat.UnitState.START);
                Combat.Unit t = units[0];
                units.Remove(units[0]);
                units.Add(t);
            }
        }
	}

    void SortBySpeed()
    {
        units = units.OrderByDescending(x => x.spd).ToList<Combat.Unit>();
    }
}
