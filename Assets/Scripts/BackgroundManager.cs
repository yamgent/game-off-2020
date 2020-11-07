using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    public GameObject player;
    public GameObject[] backgrounds;

    public int numRepeat = 3;
    public float sizeX = 12.8f;
    public float sizeY = 7.2f;

    private int rightRotate = 0;
    private int downRotate = 0;

    private float playerOffsetX = 0;
    private float playerOffsetY = 0;
    private Vector3 playerPosition;

    void Update() {
        Vector3 offset = playerPosition - player.transform.position;
        playerPosition = player.transform.position;

        playerOffsetX += offset.x;
        playerOffsetY += offset.y;
        
        if (playerOffsetX >= sizeX) {
            MoveLeft();
            playerOffsetX = 0;
        } else if (playerOffsetX <= -sizeX) {
            MoveRight();
            playerOffsetX = 0;
        }

        if (playerOffsetY >= sizeY) {
            MoveDown();
            playerOffsetY = 0;
        } else if (playerOffsetY <= -sizeY) {
            MoveUp();
            playerOffsetY = 0;
        }
    }

    private void MoveDown() {
        Vector3 moveAmount = new Vector3(0, sizeY * numRepeat, 0);
        int offset = downRotate * numRepeat;
        backgrounds[0 + offset].transform.position -= moveAmount;
        backgrounds[1 + offset].transform.position -= moveAmount;
        backgrounds[2 + offset].transform.position -= moveAmount;
        backgrounds[3 + offset].transform.position -= moveAmount;

        ++downRotate;
        if (downRotate >= numRepeat) downRotate -= numRepeat;
    }

    private void MoveUp() {
        int upRotate = getOppositeRotation(downRotate);

        Vector3 moveAmount = new Vector3(0, sizeY * numRepeat, 0);
        int offset = upRotate * numRepeat;
        backgrounds[12 - offset].transform.position += moveAmount;
        backgrounds[13 - offset].transform.position += moveAmount;
        backgrounds[14 - offset].transform.position += moveAmount;
        backgrounds[15 - offset].transform.position += moveAmount;


        --downRotate;
        if (downRotate < 0) downRotate += numRepeat;
    }

    private void MoveRight() {
        Vector3 moveAmount = new Vector3(sizeX * numRepeat, 0, 0);
        backgrounds[0 + rightRotate].transform.position += moveAmount;
        backgrounds[4 + rightRotate].transform.position += moveAmount;
        backgrounds[8 + rightRotate].transform.position += moveAmount;
        backgrounds[12 + rightRotate].transform.position += moveAmount;

        ++rightRotate;
        if (rightRotate >= numRepeat) rightRotate -= numRepeat;
    }

    private void MoveLeft() {
        int leftRotate = getOppositeRotation(rightRotate);

        Vector3 moveAmount = new Vector3(sizeX * numRepeat, 0, 0);
        backgrounds[3 - leftRotate].transform.position -= moveAmount;
        backgrounds[7 - leftRotate].transform.position -= moveAmount;
        backgrounds[11 - leftRotate].transform.position -= moveAmount;
        backgrounds[15 - leftRotate].transform.position -= moveAmount;

        --rightRotate;
        if (rightRotate < 0) rightRotate += numRepeat;
    }

    private int getOppositeRotation(int rotation) {
        if (rotation == 0) return 0;
        else return numRepeat - rotation;
    }
}
