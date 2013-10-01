using UnityEngine;
using System.Collections;

public static class ExTransform {
	
	public static GameObject Search(this Transform target, string name)
    {
        if (target.name == name) return target.gameObject;
 
        for (int i = 0; i < target.childCount; ++i)
        {
            var result = Search(target.GetChild(i), name);
 
            if (result != null) return result.gameObject;
        }
 
        return null;
    }
	
}
