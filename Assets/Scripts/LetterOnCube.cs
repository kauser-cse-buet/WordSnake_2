using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LetterOnCube : MonoBehaviour {
    public Transform textMesh;
    public char letter;

    static List<KeyValuePair<char, double>> elements = new List<KeyValuePair<char, double>>();
  

    // Use this for initialization
    void Start () {
        textMesh = gameObject.transform.GetChild(0);
        letter = GetRandomLetter();
        textMesh.GetComponent<TextMesh>().text = letter.ToString();
        
    }

    private static void GenerateLetterList() {
        elements.Add(new KeyValuePair<char, double>('A', 8.17 / 100));
        elements.Add(new KeyValuePair<char, double>('B', 1.49 / 100));
        elements.Add(new KeyValuePair<char, double>('C', 2.78 / 100));
        elements.Add(new KeyValuePair<char, double>('D', 4.25 / 100));
        elements.Add(new KeyValuePair<char, double>('E', 12.70 / 100));
        elements.Add(new KeyValuePair<char, double>('F', 2.23 / 100));
        elements.Add(new KeyValuePair<char, double>('G', 2.02 / 100));
        elements.Add(new KeyValuePair<char, double>('H', 6.09 / 100));
        elements.Add(new KeyValuePair<char, double>('I', 6.97 / 100));
        elements.Add(new KeyValuePair<char, double>('J', 0.15 / 100));
        elements.Add(new KeyValuePair<char, double>('K', 0.77 / 100));
        elements.Add(new KeyValuePair<char, double>('L', 4.03 / 100));
        elements.Add(new KeyValuePair<char, double>('M', 2.41 / 100));
        elements.Add(new KeyValuePair<char, double>('N', 6.75 / 100));
        elements.Add(new KeyValuePair<char, double>('O', 7.51 / 100));
        elements.Add(new KeyValuePair<char, double>('P', 1.93 / 100));
        elements.Add(new KeyValuePair<char, double>('Q', 0.10 / 100));
        elements.Add(new KeyValuePair<char, double>('R', 5.99 / 100));
        elements.Add(new KeyValuePair<char, double>('S', 6.33 / 100));
        elements.Add(new KeyValuePair<char, double>('T', 9.06 / 100));
        elements.Add(new KeyValuePair<char, double>('U', 2.76 / 100));
        elements.Add(new KeyValuePair<char, double>('V', 0.98 / 100));
        elements.Add(new KeyValuePair<char, double>('W', 2.36 / 100));
        elements.Add(new KeyValuePair<char, double>('X', 0.15 / 100));
        elements.Add(new KeyValuePair<char, double>('Y', 1.97 / 100));
        elements.Add(new KeyValuePair<char, double>('Z', 0.07 / 100));
    }

    public static char GetRandomLetter()
    {
        if (elements.Count == 0) {
            GenerateLetterList();
        }

        System.Random r = new System.Random();
        double diceRoll = r.NextDouble();

        double cumulative = 0.0;
        for (int i = 0; i < elements.Count; i++)
        {
            cumulative += elements[i].Value;
            if (diceRoll < cumulative)
            {
                char selectedElement = elements[i].Key;
                return selectedElement;
            }
        }

        return elements[0].Key;
    }
}
