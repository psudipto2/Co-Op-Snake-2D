using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;
    private void Awake()
    {
        i = this;
    }
    public Sprite Head_up;
    public Sprite Head_down;
    public Sprite Head_left;
    public Sprite Head_right;
    public Sprite Apple;
}
