using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler {

    public GameObject prefab;
   

    public void OnDrop(PointerEventData eventData) {
        //translate the cubes position from the world to Screen Point
    //private Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);

    //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
    //Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        Debug.Log("Drop item");
        Instantiate(prefab);
        //Vector2 droppedPosition = Camera.main.ScreenToWorldPoint(eventData.position) + offset;
        prefab.transform.position += (Vector3)eventData.delta;
    }

}
