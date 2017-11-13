using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Transform player;
    public Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int score = player.GetComponent<SnakeMovement>().score;
        scoreText.text = score.ToString();
	}
}
