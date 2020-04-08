using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JSONLoader : MonoBehaviour
{
    string path;
    string jsonString;

    public GameObject[] myPrefab;

    void Awake()
    {
        path = Application.streamingAssetsPath + "/NPC.json";
        jsonString = File.ReadAllText(path);

        NPC[] npc = JsonHelper.FromJson<NPC>(jsonString);
        for (int i = 0; i < npc.Length; i++)
            CreateNPC(npc[i]);
    }

    void CreateNPC(NPC npc)
    {
        if (npc.type == "Worker")
        {
            NPC_Controller npcCont = myPrefab[0].GetComponent<NPC_Controller>();

            npcCont.target = new Transform[npc.Schedule.Length];

            for (int i = 0; i < npc.Schedule.Length; i++)
                npcCont.target[i] = GameObject.Find(npc.Schedule[i]).transform;

            npcCont.worker_id = npc.id;

            npcCont.gameObject.name = "Worker: " + npc.id;

            Instantiate(myPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            NPC_Controller npcCont = myPrefab[1].GetComponent<NPC_Controller>();

            npcCont.isBoss = true;

            npcCont.target = new Transform[npc.Schedule.Length];

            for (int i = 0; i < npc.Schedule.Length; i++)
                npcCont.target[i] = GameObject.Find(npc.Schedule[i]).transform;

            npcCont.worker_id = npc.id;

            Instantiate(myPrefab[1], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

[Serializable]
public class NPC
{
    public string type;
    public int desk;
    public int id;
    public string[] Schedule;
}
