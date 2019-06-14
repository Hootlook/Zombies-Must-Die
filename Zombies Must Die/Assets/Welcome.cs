/************************************
 *  Class made by Alexandre DOUKHAN 
 ************************************/

using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class Welcome : EditorWindow
{
    GUIStyle style = new GUIStyle();

    static Welcome()
    {
        //Init();
    }

    static void Init()
    {
        Welcome window = ScriptableObject.CreateInstance<Welcome>();
        window.position = new Rect(Screen.width, Screen.height/2, 500, 200);
        window.ShowPopup();
    }

    void OnGUI()
    {
        style.wordWrap = true;
        style.margin = new RectOffset(9,9,9,9);
        EditorGUILayout.LabelField("Bienvenu dans le projet Zombies Must Die", EditorStyles.boldLabel);
        EditorGUILayout.TextArea("Pour lancer le jeu correctement, il est essentiel de charger la scene MainMenu avant de lancer le jeu, il est possible de changer de scene de jeu dans les 'Build Settings' en glissant la scene desirée juste apres la scene MainMenu", style);
        if (GUILayout.Button("Ok")) this.Close();
    }
} 