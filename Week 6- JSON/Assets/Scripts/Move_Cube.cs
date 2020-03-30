using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Move_Cube : MonoBehaviour
{
    float mousePos; //Mouse position in the scene
    Rigidbody rb; //Rigidbody
    Collider col; //Collider
    string filePath; //file's save path

    void Start()
    {
        filePath = Application.dataPath + "/" + name + ".json";

        rb = GetComponent<Rigidbody>(); //get the rigidbody
        col = GetComponent<Collider>(); //get the collider

        if (File.Exists(filePath)) //if save file exists
        {
            string jsonStr = File.ReadAllText(filePath); //load it as a string

            Vector3 savePos = JsonUtility.FromJson<Vector3>(jsonStr); //turn the JSON into an object

            rb.MovePosition(savePos); //move the saved position
        }
    }

    void OnMouseDrag()
    {
        mousePos = Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //get the Z position of the object

        rb.isKinematic = true; //make kinematics true
        rb.MovePosition(GetMouseAsWorldPoint()); //move object

        col.enabled = false; //turn off collider
    }

    private void OnMouseUp() //un-clicking mouse / release mouse click
    {
        col.enabled = true; //turn on collisions
    }

    Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition; //co-ordinates of mouse on screen

        mousePoint.z = mousePos; //get Z coordinates of the gameobject on screen

        return Camera.main.ScreenToWorldPoint(mousePoint);  //Convert it to world points
    }

    private void OnApplicationQuit()
    {
        string pos = JsonUtility.ToJson(transform.position, true);
        File.WriteAllText(filePath, pos); //save new position to JSON file
    }
}
