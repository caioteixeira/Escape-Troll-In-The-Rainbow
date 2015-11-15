using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    void LateUpdate()
    {
        if (!(GetComponent<Renderer>().isVisible) && Time.timeSinceLevelLoad > 2.0f)
        {
            ScenarioController.Instance.InstantiateTile();
            Destroy(gameObject);
        }
    }
}
