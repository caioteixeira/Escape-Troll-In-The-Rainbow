using UnityEngine;
using System.Collections;

public class ScenarioController : MonoBehaviour {
    /*Defines a singleton*/
    private static ScenarioController instance;
    public static ScenarioController Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType(typeof(ScenarioController)) as ScenarioController;
            return instance;
        }
    }


    public GameObject[] prefabs;
    public GameObject actualTile;
    private int tileIndex = 0;

	void Start () {
        InstantiateTile();
        InstantiateTile();
	}

    public void InstantiateTile()
    {
        Debug.Log(tileIndex);
        if (tileIndex < 0 || tileIndex >= prefabs.Length)
        {
            return;
        }

        GameObject newTile = Instantiate(prefabs[tileIndex]);
        
        float nX = actualTile.transform.localPosition.x + 20.0f; //Really bad! Just for tests
        Vector3 pos = new Vector3(nX, 0.0f, 0.0f);
        newTile.transform.localPosition = pos;

        
        //Update the index
        tileIndex = tileIndex + 1>= prefabs.Length ? 0 : tileIndex + 1;
        actualTile = newTile;
    }
}
