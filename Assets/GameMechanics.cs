using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanics : MonoBehaviour {

    public GameObject obstacle;

	void Start () {
        InvokeRepeating("SetObstacle", 2, 2.5f);
	}

    void SetObstacle() {
        Instantiate(obstacle);
    }
}
