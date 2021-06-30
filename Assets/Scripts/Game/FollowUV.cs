using UnityEngine;
using System.Collections;

public class FollowUV : MonoBehaviour
{

    public float parralax = 2f;
    public float matOffset = 0f;

    void Update()
    {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = (transform.position.x / transform.localScale.x / parralax)  + matOffset;
        offset.y = (transform.position.y / transform.localScale.y / parralax) + matOffset;

        mat.mainTextureOffset = offset;

    }

}
