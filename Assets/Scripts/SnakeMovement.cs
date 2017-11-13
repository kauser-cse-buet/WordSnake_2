﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeMovement : MonoBehaviour {

    public List<Transform> bodyParts = new List<Transform>();
    public string currentWord = string.Empty;
    public TextAsset asset;
    public string[] wordList { get; private set; }
    public List<string> wordArrayList;
    public int score = 0;
    public GameManager gameManager;


    // Use this for initialization
    void Start () {
        char headLetter = LetterOnCube.GetRandomLetter();
        transform.GetChild(0).GetComponent<TextMesh>().text = headLetter.ToString();
        currentWord += headLetter;
        
        print("Number of words in dictionary: " + asset.text.Length);
        wordList = asset.text.Split(new[] { System.Environment.NewLine },
                         System.StringSplitOptions.None);

        wordArrayList = new List<string>(wordList);
        //score = 0;
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            currentRotation += rotationSensitivity * Time.deltaTime;
			//Debug.Log ("A: current rotation");
			//Debug.Log (currentRotation);
        }

        if (Input.GetKey(KeyCode.D)) {
            currentRotation -= rotationSensitivity * Time.deltaTime;
			//Debug.Log ("D: current rotation");
			//Debug.Log (currentRotation);
        }
	}

    public float speed = 3.5f;
    public float rotationSensitivity = 50.0f;
    private float currentRotation;

    void FixedUpdate() {
        MoveForward();
        Rotation();
        CamerFollow();
        SpawnOrbManager();
    }

	[Range(0.0f, 1.0f)]
	public float smoothTime = 0.5f;
    private void CamerFollow()
    {
        Transform camera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform;
		Vector3 cameraVelocity = Vector3.zero;
		camera.position = Vector3.SmoothDamp(camera.position, 
                                             new Vector3(gameObject.transform.position.x, 
														 gameObject.transform.position.y, 
														 -10), 
											 ref cameraVelocity, 
											 smoothTime);

    }

    void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
		transform.position.Set (transform.position.x, 
			transform.position.y,
			-0.5f);
		//Debug.Log ("move forward");
		//Debug.Log (transform.position);
        
    }

    void Rotation() {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
		//Debug.Log ("rotation");
		//Debug.Log (transform.position);
    }

    public Transform bodyObject;
    void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Orb") {
			Debug.Log ("collision orb");
            Transform child = other.transform.GetChild(0);
            string text = child.GetComponent<TextMesh>().text;

            currentWord += text;

            var wordStartWithCurrentWordQueryResult = from word in wordArrayList
                          where word.StartsWith(currentWord)
                          select word;

            List<string> wordStartWithCurrentWordList = wordStartWithCurrentWordQueryResult.ToList();

            if (wordArrayList.Contains(currentWord.ToUpper()))
            {
                print("Correct word: " + currentWord);
                score += currentWord.Length;
            }
            else {
                print("!!! Wrong word: " + currentWord);

                if (wordStartWithCurrentWordList.Count == 0) {
                    FindObjectOfType<GameManager>().EndGame();
                }
            }

            Destroy(other.gameObject);

            if (bodyParts.Count == 0)
            {
				//Debug.Log ("body parts count == 0");
                Vector3 currentPos = transform.position;
                Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;

                newBodyPart.GetChild(0).GetComponent<TextMesh>().text = text;

                bodyParts.Add(newBodyPart);
				//Debug.Log (currentPos);
				//Debug.Log (newBodyPart.position);
            }
            else {
				//Debug.Log ("body parts count != 0");
                Vector3 currentPos = bodyParts[bodyParts.Count - 1].position;
                Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
                newBodyPart.GetChild(0).GetComponent<TextMesh>().text = text;
                bodyParts.Add(newBodyPart);
				//Debug.Log (currentPos);
				//Debug.Log (newBodyPart.position);
            }
        }
    }


    public float spawnOrbEveryXSeconds = 1;

    public GameObject orbPrefab;

    void SpawnOrbManager() {
        StartCoroutine("CallEveryFewSeconds", spawnOrbEveryXSeconds);
    }

    IEnumerator CallEveryFewSeconds(float x) {
        yield return new WaitForSeconds(x);
        StopCoroutine("CallEveryFewSeconds");
        Vector3 randomNewOrbPosition = new Vector3(
                Random.Range(
                    Random.Range(transform.position.x - 10, transform.position.x -5),
                    Random.Range(transform.position.x + 5, transform.position.x + 10)
                ),
                Random.Range(
                    Random.Range(transform.position.y - 10, transform.position.y - 5),
                    Random.Range(transform.position.y + 5, transform.position.y + 10)
                ), 
                0
            );
        GameObject newOrb = Instantiate(orbPrefab, randomNewOrbPosition, Quaternion.identity) as GameObject;
        GameObject orbParent = GameObject.Find("Orbs");
        newOrb.transform.parent = orbParent.transform;
    }
}

