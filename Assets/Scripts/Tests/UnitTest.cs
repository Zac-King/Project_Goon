using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class UnitTest : MonoBehaviour {

    public Combat.Unit unitToTest;
    //emulaqte a turn manager 
    [SerializeField]
    List<Combat.Unit> units;
    void Start()
    {
        units.AddRange(FindObjectsOfType<Combat.Unit>());
        units = units.OrderByDescending(x => x.spd).ToList<Combat.Unit>();
    }
 
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            unitToTest.GoToState(Combat.UnitState.START); 
	}
}
