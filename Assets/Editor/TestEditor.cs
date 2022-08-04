using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

//[CustomEditor(typeof(PlayerClass))]
public class TestEditor:Editor
{
    SerializedProperty Speed;
    //SerializedProperty 
    
    private void OnEnable()
    {
        Speed = serializedObject.FindProperty("Speed");
    }

    public override void OnInspectorGUI()
    {

        Object tgt = target;

 


    }

}

