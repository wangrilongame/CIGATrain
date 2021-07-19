using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{

    public BoxCollider2D m_BOX;
    public SpriteRenderer m_Sprite;
    // Start is called before the first frame update
    void Start()
    {
        m_BOX.size = m_Sprite.size;
    }


}
