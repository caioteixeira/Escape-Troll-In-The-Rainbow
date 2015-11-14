using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    void LateUpdate()
    {
        if (!(GetComponent<Renderer>().isVisible) && Time.realtimeSinceStartup > 1.0f)
        {
            ScenarioController.Instance.InstantiateTile();
            Destroy(gameObject);
        }
    }
}
