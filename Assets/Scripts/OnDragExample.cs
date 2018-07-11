using UnityEngine;
using UnityEngine.EventSystems;

public class OnDragExample : EventTrigger {
    public GameObject prefabTower;
    GameObject prefabInstance;

    void Start() {
        prefabInstance = Instantiate(prefabTower);
        //Fetch the Event Trigger component from your GameObject
        EventTrigger trigger = GetComponent<EventTrigger>();
        //Create a new entry for the Event Trigger
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //Add a Drag type event to the Event Trigger
        entry.eventID = EventTriggerType.Drag;
        //call the OnDragDelegate function when the Event System detects dragging
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        //Add the trigger entry
        trigger.triggers.Add(entry);
    }

    public void OnDragDelegate(PointerEventData data) {
        //Create a ray going from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        //Move the GameObject when you drag it
        prefabInstance.transform.position = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
    }
    public override void OnDrop(PointerEventData data) {
        Debug.Log("OnDrop called.");
    }

    public override void OnEndDrag(PointerEventData data) {
        Debug.Log("OnEndDrag called.");
    }


    public override void OnBeginDrag(PointerEventData data) {
        Debug.Log("OnBeginDrag called.");
    }

    public override void OnCancel(BaseEventData data) {
        Debug.Log("OnCancel called.");
    }

    public override void OnDeselect(BaseEventData data) {
        Debug.Log("OnDeselect called.");
    }
}