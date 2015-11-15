using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    void LateUpdate()
    {
        if (!(GetComponent<Renderer>().isVisible) && Time.timeSinceLevelLoad >= 3.0f)
        {
            ScenarioController.Instance.InstantiateTile();
            Destroy(gameObject);
        }
    }
}
