using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelObject : MonoBehaviour
{
    public List<Vector3> desList;
    public int curDesIndex = -1;
    public Vector3 curDestination;
    public float speed;
    public float startTime;
 

    void Start()
    {
       
        startTime = Time.time;
        
    }

    void Update()
    {
        if (desList.Count > 1 && curDesIndex < 0)
        {
            curDesIndex = 0;
            curDestination = desList[0];
            
        }


        if ( Vector3.Distance(transform.position,desList[curDesIndex]) < 1f && curDesIndex < desList.Count)
        {
            curDesIndex++;
            curDestination = desList[curDesIndex];
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, curDestination, Time.deltaTime * speed);

            //transform.position = Vector3.Lerp(transform.position, curDestination, Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Rotate(Vector3.up * -90, 0.8f));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Rotate(Vector3.up * 90, 0.8f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.tag == "TurnRightPoint")
        {
            StartCoroutine(Rotate(Vector3.up * 90, 0.8f));
        }

        if (other.tag == "TurnLeftPoint")
        {
            
            StartCoroutine(Rotate(Vector3.up * -90, 0.8f));
        }

        if (other.tag == "TurnTo0")
        {
            StartCoroutine(Rotate(Vector3.up * -90, 0.8f));
        }
    }

    IEnumerator Rotate(Vector3 angle, float time)
    {
        Quaternion curAngle = transform.rotation;

        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + angle);

        for (float i = 0; i <= 1; i += Time.deltaTime / time)
        {
            transform.rotation = Quaternion.Slerp(curAngle, toAngle, i);
            yield return null;
        }

        transform.rotation = toAngle;

    }




}
