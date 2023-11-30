using Scripts.SkillTree.Logic;
using Scripts.StaticData.EnumLinks;
using System;
using UnityEngine;
using Zenject;

public class SkillTreeAndPlayerStatsTestInstaller : MonoInstaller
{
    public ListEnumLinksFromStatToAttribute staticDataEnumLinks;
    public DefaultSkillTreeData defaultSkillTreeData;

    public GameObject PlayerPrefab;

    public override void InstallBindings()
    {
        BindStaticData();

        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Container.InstantiatePrefab(PlayerPrefab);
    }

    private void BindStaticData()
    {
        Container.Bind<ListEnumLinksFromStatToAttribute>().FromInstance(staticDataEnumLinks).AsSingle();
        Container.Bind<DefaultSkillTreeData>().FromInstance(defaultSkillTreeData).AsSingle();
    }
}