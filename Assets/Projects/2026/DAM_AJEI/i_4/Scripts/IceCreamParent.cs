using System;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamParent : MonoBehaviour
{
    public Transform spawnPoint;

    private IceCreamParent currentIceCreamBallChild;
    [NonSerialized] public float currnetScale = 1f;
    public const float ScaleMultipler = 0.75f;
    [NonSerialized] public bool needExit = false;
    public string iceName = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IceCreamCube iceCreamCube) && !needExit && currentIceCreamBallChild == null)
        {
            currentIceCreamBallChild = Instantiate(iceCreamCube.iceCreamBallPrefab, spawnPoint);
            currentIceCreamBallChild.transform.localPosition = new Vector3(0, (currnetScale * 0.1f) * 0.5f, 0);
            currentIceCreamBallChild.needExit = true;
            currentIceCreamBallChild.transform.localScale = Vector3.one * currnetScale;
            //currentIceCreamBallChild.SetScale(Vector3.one * currnetScale);
            currentIceCreamBallChild.currnetScale = currnetScale * ScaleMultipler;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        needExit = false;
    }

    public void RemoveIceCream()
    {
        Destroy(currentIceCreamBallChild);
        currentIceCreamBallChild = null;
    }

    public List<IceCreamParent> GetChilds()
    {
        if(currentIceCreamBallChild != null)
        {
            List<IceCreamParent> childs = currentIceCreamBallChild.GetChilds();
            childs.Add(this);
            return childs;
        }
        {
            return new() { this };
        }
    }

    public bool CheckIceCreem(List<IceCreamParent> listToCheck)
    {
        List<IceCreamParent> childs = GetChilds();
        childs.Reverse();

        int checkSize = listToCheck.Count;

        if(childs.Count != checkSize)
        {
            return false;
        }

        for (int i = 0; i < checkSize; i++)
        {
            if (childs[i].iceName != listToCheck[i].iceName)
            {
                return false;
            }
        }

        return true;
    }
}
