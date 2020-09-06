using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Day8 : MonoBehaviour
{
    int width = 3;
    int height = 2;

    public void DecodeA(TextAsset puzzleInput)
    {
        char[] characters = puzzleInput.text.ToCharArray();
        List<char[]> imageLayers = new List<char[]>();

        for (int i = 0; i < characters.Length; i += width*height)
        {
            char[] layer = new char[width * height];

            if(characters.Length < i + (width * height))
            {

            }
        }

        
        
    }

}
