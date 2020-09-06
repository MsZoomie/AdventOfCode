using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1 : MonoBehaviour
{
    public TextAsset input;

    public void CalculateExample()
    {
        Debug.Log(CalculateFuel(12).ToString());
        Debug.Log(CalculateFuel(14).ToString());
        Debug.Log(CalculateFuel(1969).ToString());
        Debug.Log(CalculateFuel(100756).ToString());
    }

    public void CalcTotalFuel()
    {
        string[] modules = input.text.Split('\n');

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
