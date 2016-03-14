using UnityEngine;
using System.Collections;

public class Ability 
{
    private string Name;
    bool SelfTargeted;
    Combat.UnitStat TargetedStat;

	public Ability(string name, bool self, Combat.UnitStat stat)
    {
        Name         = name;
        SelfTargeted = self;
        TargetedStat = stat;
    }


}
