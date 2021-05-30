using UnityEngine;
using Zenject;

using UFOT.Human;
using UFOT.Data;
using UFOT.Commands;
using UFOT.Signals;

namespace UFOT.Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] UFOConfig ufoConfig;
        [SerializeField] HumansConfig humansConfig;
        [SerializeField] HumanSpawner humanSpawner;

        public override void InstallBindings()
        {
            Container.BindInstance(ufoConfig).NonLazy();  
            Container.BindInstance(humansConfig).NonLazy();

            Container.Bind<UFOData>().AsSingle().NonLazy();
            Container.Bind<HumanPool>().AsSingle().NonLazy();
            Container.Bind<HumanSpawner>().FromInstance(humanSpawner).AsSingle().NonLazy();
            
            Container.BindFactory<ShopProduct, PurchaseCommand, PurchaseCommand.Factory>();
            Container.BindFactory<HumanActor, CaptureHumanCommand, CaptureHumanCommand.Factory>();
            Container.BindFactory<UnloadHumansCommand, UnloadHumansCommand.Factory>();
            Container.BindFactory<bool, PauseCommand, PauseCommand.Factory>();

            Container.BindFactory<Transform, HumanActor, HumanActor.Factory>().FromFactory<HumanFactory>();
            
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<UfoDataUpdatedSignal>();
            Container.DeclareSignal<HumanDestroyedSignal>();
            Container.DeclareSignal<RegisterHumanSpawnSignal>();
            Container.DeclareSignal<BaseEnterSignal>();
            Container.DeclareSignal<BaseExitSignal>();

            Application.targetFrameRate = 60;
        }
    }
}