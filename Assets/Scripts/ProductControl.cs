using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductControl : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;

    [SerializeField] private float _duration;
    [SerializeField] private Transform[] items;
    private bool isConveyorPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        if(Application.isPlaying)
        {
            if(_duration>0) StartCoroutine(MoveProduct());
        }
    }

    private IEnumerator MoveProduct()
    {
        float progress = 0f;
        while(true)
        {
           if(!isConveyorPaused)
           {
            
            foreach(Transform item in items)
            {

                item.position = Vector3.MoveTowards(item.position, endPoint.position, progress);

                if(Vector3.Distance(item.position, endPoint.position)<0.1f)
                {
                    isConveyorPaused = true;
                    Debug.Log("Conveyor Paused");
                    
                    
                    yield return null;
                }
            }
           }
        }
    }

}
