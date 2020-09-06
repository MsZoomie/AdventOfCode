using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1 : MonoBehaviour
{
    //----------------------------------------
    // Puzzle 1a
    //----------------------------------------

    /// <summary>
    /// Calculates the total fuel by individually calculating 
    /// the required fuel of each module and adding 
    /// the results together.
    /// </summary>
    /// <param name="inputFile">Text file with input.</param>
    public void CalcTotalFuel(TextAsset inputFile)
    {
        string[] modules = inputFile.text.Split('\n');

        int totalFuel = 0;

        for (int i = 0; i < modules.Length; i++)
        {
            totalFuel += CalculateFuel(int.Parse(modules[i]));
        }

        Debug.Log("total fuel: " + totalFuel.ToString());
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
