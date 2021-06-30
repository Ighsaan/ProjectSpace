using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform player = null;
    public Vector3 offset;
    public float followeSpeed;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + offset, followeSpeed);    
        }
    }
}
