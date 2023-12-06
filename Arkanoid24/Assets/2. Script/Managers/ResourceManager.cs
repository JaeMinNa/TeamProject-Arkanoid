using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    private List<StageBlueprint> stages = new();
    private Dictionary<string, GameObject> prefabs = new();

    private List<VersusLevelBlueprint> versusStages = new();
    public void Initialize()
    {
        // �������� SO ����
        StageBlueprint[] stages = Resources.LoadAll<StageBlueprint>("Blueprint/Stage");
        foreach (StageBlueprint stage in stages) this.stages.Add(stage);

        //���� �������� SO����
        VersusLevelBlueprint[] versusStages = Resources.LoadAll<VersusLevelBlueprint>("Blueprint/VersusStage");
        foreach (VersusLevelBlueprint vStage in versusStages) this.versusStages.Add(vStage);

        // ������Ʈ ������
        GameObject[] objs = Resources.LoadAll<GameObject>("Prefabs/Model");
        foreach (GameObject obj in objs) prefabs[obj.name] = obj;

        GameObject laser = Resources.Load<GameObject>("Prefabs/Laser/Laser");
        prefabs[laser.name] = laser;
    }

    /// <summary>
    /// ���ҽ� ���� ���� ������ ����
    /// </summary>
    /// <param name="prefabName">�ش� ������ �̸�</param>
    /// <returns>�ش� ������ ����</returns>
    public GameObject Instantiate(string prefabName, Vector2 startPos)
    {
        if (!prefabs.TryGetValue(prefabName, out GameObject prefab)) return null;
        return GameObject.Instantiate(prefab, startPos, Quaternion.identity);
    }

    public GameObject Instantiate(string prefabName)
    {
        if (!prefabs.TryGetValue(prefabName, out GameObject prefab)) return null;
        return GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    public StageBlueprint[] GetStages()
    {
        return stages.ToArray();
    }

    public VersusLevelBlueprint[] GetVersusStages()
    {
        return versusStages.ToArray();
    }
}

