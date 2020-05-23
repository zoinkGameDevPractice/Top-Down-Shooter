using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScaler : MonoBehaviour
{
    public void MakeBig()
    {
        transform.parent.gameObject.transform.localScale = new Vector3(1.4f, 1.4f);
    }
}
