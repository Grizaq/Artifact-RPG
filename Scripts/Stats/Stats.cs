using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField] private int baseValue; //base value for attack and defence, to be midified

    private List<int> modifiers = new List<int>();

    public int GetValue() //simple calculus for end stat
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }
    public void AddModifier(int modifier) //checking what value has to be added to the character stats
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }
    public void RemoveModifier(int modifier) //checking what value has to be added to the character stats
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

}
