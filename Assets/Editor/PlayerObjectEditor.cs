using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(PlayerData))]
public class PlayerObjectEditor : PropertyDrawer
{
    PropertyContainer[] Container;


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 200f;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        
       /// position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        //DiskRadius = property.
        EditorGUI.BeginProperty(position, label, property);
        label.text = "Player Details";
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        AssignProperties(property, position);
        //  Rect speedrect = new Rect(position.x, position.y, 30, 40);
        //EditorGUI.PropertyField(speedrect, property.FindPropertyRelative("Speed"), GUIContent.none);
        RenderProperties(Container, position);
       
        EditorGUI.EndProperty();
       
    }

    void RenderProperties(PropertyContainer[] cont, Rect PassedRect)
    {
        float PositionY=20;
        for(int i=0 ; i< cont.Length; i++)
        {
            switch(cont[i].GUItype)
            {
                case PropertyGUI.Field:
                    EditorGUI.PropertyField(new Rect(20+cont[i].Xoffset, PassedRect.y + PositionY + cont[i].Yoffset,cont[i].Width,cont[i].Height),cont[i].Property);
                    break;
                case PropertyGUI.Slider:
                    EditorGUI.Slider(new Rect(20+cont[i].Xoffset, PassedRect.y+PositionY+cont[i].Yoffset, cont[i].Width, cont[i].Height),cont[i].Property,(int)cont[i].MaxValue, (int)cont[i].MinValue);
                    break;
                case PropertyGUI.SliderFloat:
                    EditorGUI.Slider(new Rect(20 + cont[i].Xoffset, PassedRect.y + PositionY + cont[i].Yoffset, cont[i].Width, cont[i].Height), cont[i].Property, cont[i].MaxValue, (int)cont[i].MinValue);
                    break;
            }
            PositionY += cont[i].Height + cont[i].Yoffset;
            
        }
    }
    
    void AssignProperties(SerializedProperty prop, Rect PassedRect)
    {
        Container = new PropertyContainer[5];
        Container[0] = new PropertyContainer() { Width = PassedRect.width, Height = 20, Property = prop.FindPropertyRelative("Level"), GUItype = PropertyGUI.Field };
        Container[1] = new PropertyContainer() { Width =PassedRect.width, Height = 34, Property = prop.FindPropertyRelative("Speed"), GUItype = PropertyGUI.Field };
        Container[2] = new PropertyContainer() { Width = 320, Height = 34, Property = prop.FindPropertyRelative("HoleRadius")  , GUItype = PropertyGUI.Slider,MaxValue=1, MinValue=10 };
        Container[3] = new PropertyContainer() { Width = 320, Height = 34, Property = prop.FindPropertyRelative("DiskRadius"), GUItype = PropertyGUI.Slider, MaxValue = 1, MinValue = 10 };
        Container[4] = new PropertyContainer() { Width = 300, Height = 50, Property = prop.FindPropertyRelative("HoleMaterial"), GUItype= PropertyGUI.Field,Yoffset = 20 };

    }
}

//class that stores properties and its element size to dynamically be added to the property UI

class PropertyContainer
{
    public float Width,Height;
    public SerializedProperty Property;
    public PropertyGUI GUItype;
    //position Offsets
    public float Xoffset =0; 
    public float Yoffset =0;
    //fields that are only used when the GUItype is set to Slider or SliderFloat
    public float MaxValue=0;
    public float MinValue=0;

}

public enum PropertyGUI
{
    Field, Slider, SliderFloat
}





