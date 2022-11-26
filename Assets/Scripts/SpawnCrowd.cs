using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrowd : MonoBehaviour
{
    public List<GameObject> npcList;
    public List<Transform> positionsList;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in positionsList)
        {
            GameObject npc = Instantiate(npcList[Random.Range(0, 7)], t.position, t.rotation);
            npc.GetComponent<SpriteRenderer>().sortingOrder = t.GetComponent<SeatLayerAssign>().layerOrder;
            npc.transform.localScale = new Vector3(t.GetComponent<SeatLayerAssign>().scale, 1f, 1f);
        }
    }
}
