using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Day8 : MonoBehaviour
{
    public  int WIDTH = 25;
    public  int HEIGHT = 6;

    public void DecodeA(TextAsset puzzleInput)
    {
        List<Layer> layers = BuildLayers(puzzleInput);
        int fewestZeros = int.MaxValue;
        foreach (var layer in layers)
        {
            fewestZeros = Mathf.Min(fewestZeros, layer.zeros);
        }

        Layer wantedLayer = layers.Find(x => x.zeros == fewestZeros);

        string y = "";
        for (int i = 0; i < wantedLayer.digits.Length; i++)
        {
            if (i % WIDTH == 0)
                y += "\n";

            y += wantedLayer.digits[i].ToString();
        }
        Debug.Log(y);

        int answer = wantedLayer.ones * wantedLayer.twos;
        Debug.Log(answer.ToString());
    }


    public List<Layer> BuildLayers(TextAsset puzzleInput)
    {
        Layer currentLayer = new Layer();

        int layerSize = WIDTH * HEIGHT;
        char[] characters = puzzleInput.text.ToCharArray();

        List<Layer> layers = new List<Layer>();
        
        currentLayer.digits = new int[layerSize];

        for (int i = 0; i < characters.Length; i++)
        {
            int layerIndex = i % layerSize;
            
            if(layerIndex == 0)
            {
                if (i != 0)
                {
                    layers.Add(currentLayer);
                   
                }

                currentLayer = new Layer();
                currentLayer.digits = new int[layerSize];
            }

            currentLayer.digits[layerIndex] = (int)(characters[i] - '0');
            switch (currentLayer.digits[layerIndex])
            {
                case 0:
                    currentLayer.zeros++;
                    break;
                case 1:
                    currentLayer.ones++;
                    break;
                case 2:
                    currentLayer.twos++;
                    break;
                default:
                    break;
            }

        }

        layers.Add(currentLayer);
        return layers;
    }

    
}

public class Layer
{
    public int[] digits;
    public int zeros;
    public int ones;
    public int twos;
}
