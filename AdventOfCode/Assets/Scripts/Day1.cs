using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1 : MonoBehaviour
{
    

    public void CalculateExample()
    {
        Debug.Log(CalculateFuel(12).ToString());
        Debug.Log(CalculateFuel(14).ToString());
        Debug.Log(CalculateFuel(1969).ToString());
        Debug.Log(CalculateFuel(100756).ToString());
    }


    /// <summary>
    /// Calculates the required fuel for a module.
    /// </summary>
    /// <param name="mass"> Mass of the module.</param>
    /// <returns>Required fuel.</returns>
    int CalculateFuel(int mass)
    {
        int fuel = Mathf.FloorToInt(mass / 3);
        fuel -= 2;
        return fuel;
    }
}
