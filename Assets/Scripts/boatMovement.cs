using UnityEngine;

public class boatMovement : MonoBehaviour
{
    public GameObject boaty;
    public Rigidbody boat;
    public boatAshore ba;
    public Vector3 lastAction;
    [SerializeField] GameObject backBoat;
    [SerializeField] GameObject backLeft;
    [SerializeField] GameObject backRight;
    [SerializeField] GameObject frontBoat;
    [SerializeField] GameObject frontLeft;
    [SerializeField] GameObject frontRight;


    public bool boatAshore() 
    {
        bool backy = (ba.boatOnLand(backBoat.transform.position, 0.05f, new Vector3(0.0f, 0.0f, 1.0f))) ;
        bool backleft = (ba.boatOnLand(backLeft.transform.position, 0.05f, new Vector3(0.0f, 0.0f, 1.0f))) ;
        bool backright = (ba.boatOnLand(backRight.transform.position, 0.05f, new Vector3(0.0f, 0.0f, 1.0f))) ;
        bool fronty = (ba.boatOnLand(frontBoat.transform.position, 0.05f, new Vector3(0.0f, 0.0f, 1.0f))) ;
        bool frontleft = (ba.boatOnLand(frontLeft.transform.position, 0.05f, new Vector3(0.0f, 0.0f, 1.0f))) ;
        bool frontright = (ba.boatOnLand(frontRight.transform.position, 0.05f, new Vector3(0.0f, 0.0f, 1.0f))) ;
        if (backy || backleft || backright || fronty || frontleft || frontright)
        {
            Debug.Log("Found land");
            return true;

        }
        return false;
    }

    public Vector3 getFrontBoat()
    {
        return frontBoat.transform.position;
    }
    public void moveRight()
    {
        Vector3 offSet = rotationToOffset(-1.0f, "sideways");
        boat.AddForceAtPosition(offSet, backBoat.transform.position);
        lastAction = offSet;
    }

    public void moveLeft()
    {
        Vector3 offSet = rotationToOffset(1.0f, "sideways");
        boat.AddForceAtPosition(offSet, backBoat.transform.position);
        lastAction = offSet;
    }

    public void moveForward()
    {
        Vector3 offSet = rotationToOffset(1.0f, "straight");
        boat.AddForceAtPosition(offSet, backBoat.transform.position);
        lastAction = offSet;
    }

    public void moveDown()
    {
        Vector3 offSet = rotationToOffset(-1.0f, "straight");
        boat.AddForceAtPosition(offSet, backBoat.transform.position);
        lastAction = offSet;
    }

    public void moveDirectlyLeft()
    {
        Vector3 offSet = rotationToOffset(-1.0f, "sideways") * 6.0f;
        boat.AddForceAtPosition(offSet, boat.worldCenterOfMass);
        lastAction = offSet;
    }

    public void moveDirectlyRight()
    {
        Vector3 offSet = rotationToOffset(1.0f, "sideways")*6.0f;
        boat.AddForceAtPosition(offSet, boat.worldCenterOfMass);
        lastAction = offSet;
    }

    public void step(Vector3 output) {
        boat.AddForceAtPosition(output, backBoat.transform.position);
        lastAction = output;
    }

    public Vector3 rotationToOffset(float multiplier, string straight) 
    {
        float angle = Mathf.Deg2Rad*backBoat.transform.eulerAngles.z;
        if (straight == "straight")
        {
            float x = (float)(Mathf.Cos(angle) * 10.0f) * multiplier;
            float y = (float)(Mathf.Sin(angle) * 10.0f) * multiplier;

            return new Vector3(-y, x, 0);
        }

        else 
        {
            float x = (float)(Mathf.Cos(angle) * 0.50f) * multiplier;
            float y = (float)(Mathf.Sin(angle) * 0.50f) * multiplier;

            return new Vector3(x, y, 0);
        }
    }
}
