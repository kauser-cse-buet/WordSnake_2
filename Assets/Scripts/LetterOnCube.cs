using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LetterOnCube : MonoBehaviour {
    public Transform textMesh;
    public char letter;

	// Use this for initialization
	void Start () {
        textMesh = gameObject.transform.GetChild(0);
        letter = GetRandomLetter();
        textMesh.GetComponent<TextMesh>().text = letter.ToString();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public char GetRandomLetter()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        System.Random rnd = new System.Random();
        int num = rnd.Next(0, chars.Length - 1);

        return chars[num];
    }
}
