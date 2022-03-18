using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour {

    [SerializeField] private GameObject areaGO;
    [SerializeField] private GameObject anchorGO;


    private PlacedObjectTypeSO placedObjectTypeSO;
    private Vector2Int origin;
    private PlacedObjectTypeSO.Dir dir;
    
    public static PlacedObject Create(Vector3 worldPosition, Vector2Int origin, PlacedObjectTypeSO.Dir dir, PlacedObjectTypeSO placedObjectTypeSO) {
        Transform placedObjectTransform = Instantiate(placedObjectTypeSO.prefab, worldPosition, Quaternion.Euler(0, placedObjectTypeSO.GetRotationAngle(dir), 0));
        PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();
        placedObject.Setup(placedObjectTypeSO, origin, dir);
        return placedObject;
    }


    private void Setup(PlacedObjectTypeSO placedObjectTypeSO, Vector2Int origin, PlacedObjectTypeSO.Dir dir) {
        this.placedObjectTypeSO = placedObjectTypeSO;
        this.origin = origin;
        this.dir = dir;
        HideAreaAndPivot();
    }

    public List<Vector2Int> GetGridPositionList() {
        return placedObjectTypeSO.GetGridPositionList(origin, dir);
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }

    private void HideAreaAndPivot() {
        areaGO.SetActive(false);
        anchorGO.SetActive(false);
    }

    public GameObject getAreaGO() {
        return areaGO;
    }
}
