using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SnakeMovement : MonoBehaviour {

    public List<Transform> bodyParts = new List<Transform>();

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            currentRotation += rotationSensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            currentRotation -= rotationSensitivity * Time.deltaTime;
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
                                             new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10), ref cameraVelocity, smoothTime);

    }

    void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        
    }

    void Rotation() {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotation));
    }

    public Transform bodyObject;
    void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Orb") {
            Transform child = other.transform.GetChild(0);
            string text = child.GetComponent<TextMesh>().text;


            Destroy(other.gameObject);

            if (bodyParts.Count == 0)
            {
                Vector3 currentPos = transform.position;
                Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
                bodyParts.Add(newBodyPart);
            }
            else {
                Vector3 currentPos = bodyParts[bodyParts.Count - 1].position;
                Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
                bodyParts.Add(newBodyPart);
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

