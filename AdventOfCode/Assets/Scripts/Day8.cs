using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Day8 : MonoBehaviour
{
    public  int WIDTH = 25;
    public  int HEIGHT = 6;

    public UnityEngine.UI.Image pixel;
    public UnityEngine.UI.Text answerText;

    /// <summary>
    /// An array of the digits of a layer. The number of zeroes, 
    /// ones and twos are saved for the first decoding.
    /// </summary>
    public struct Layer
    {
        public int[] digits;
        public int zeroes;
        public int ones;
        public int twos;
    }

    /// <summary>
    /// Find the layer with fewest zeroes and multiply 
    /// the number of ones and twos in that layer.
    /// </summary>
    /// <param name="puzzleInput">Input for the puzzle.</param>
    public void DecodeA(TextAsset puzzleInput)
    {
        List<Layer> layers = BuildLayers(puzzleInput);

        int fewestZeros = int.MaxValue;
        foreach (var layer in layers)
        {
            fewestZeros = Mathf.Min(fewestZeros, layer.zeroes);
        }

        Layer wantedLayer = layers.Find(x => x.zeroes == fewestZeros);

        int answer = wantedLayer.ones * wantedLayer.twos;
        answerText.text = answer.ToString();
    }

    /// <summary>
    /// Combine the layers to the final image and draw it.
    /// </summary>
    /// <param name="puzzleInput">Input for the puzzle.</param>
    public void DecodeB(TextAsset puzzleInput)
    {
        List<Layer> layers = BuildLayers(puzzleInput);
        int[] finalImage = new int[WIDTH * HEIGHT];

        /* Iterate through all the pixels in the image. For each pixel, 
         * iterate through the layers until you find a pixel that is not transparent.*/
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

        DrawImage(finalImage);
    }


    private void DrawImage(int[] image)
    {
        float pixelWidth = 20;
        Vector2 pos = new Vector2(-(WIDTH / 2f) * pixelWidth, (HEIGHT / 2f) * pixelWidth);
        float firstX = pos.x;

        // Create pixels in the corresponding colors.
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

            // Decide next pixel position.
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
                    currentLayer.zeroes++;
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