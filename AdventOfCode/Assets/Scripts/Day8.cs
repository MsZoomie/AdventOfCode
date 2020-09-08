using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Day8 : MonoBehaviour
{
    public  int WIDTH = 25;
    public  int HEIGHT = 6;

    public UnityEngine.UI.Image pixel;

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


    public void DecodeB(TextAsset puzzleInput)
    {
        List<Layer> layers = BuildLayers(puzzleInput);
        int[] finalImage = new int[WIDTH * HEIGHT];

        for (int i = 0; i < WIDTH * HEIGHT; i++)
        {
            for (int j = 0; j < layers.Count; j++)
            {
                int pixelDigit = layers[j].digits[i];

                if (pixelDigit != 2 || j == layers.Count-1)
                {
                    finalImage[i] = pixelDigit;
                    break;
                }
            }
        }

        /*
        string temp = "";
        for (int i = 0; i < finalImage.Length; i++)
        {
            if (i % WIDTH == 0)
                temp += "\n";

            temp += finalImage[i].ToString();
        }
        Debug.Log(temp);*/

        DrawImage(finalImage);
    }


    private void DrawImage(int[] image)
    {
        float pixelWidth = 20;
        Vector2 pos = new Vector2(-(WIDTH / 2f) * pixelWidth, (HEIGHT / 2f) * pixelWidth);
        float firstX = pos.x;

        Debug.Log("first pos: " + pos.x + "," + pos.y);

        for (int i = 0; i < WIDTH*HEIGHT; i++)
        {
            UnityEngine.UI.Image newPixel = Instantiate(pixel, pixel.transform.parent);
            newPixel.transform.localPosition = pos;
            newPixel.gameObject.SetActive(true);

            switch (image[i])
            {
                case 0:
                    newPixel.color = Color.black;
                    break;
                case 1:
                    newPixel.color = Color.white;
                    break;
                default:
                    break;
            }


            pos.x += pixelWidth;
            if (i % WIDTH == WIDTH-1 && i != 0)
            {
                pos.x = firstX;
                pos.y -= pixelWidth;
            }
            
        }
    }


    private List<Layer> BuildLayers(TextAsset puzzleInput)
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
