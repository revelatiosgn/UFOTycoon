using UnityEngine;
using Zenject;

using UFOT.Human;
using UFOT.Data;
using UFOT.Commands;
using UFOT.Signals;

namespace UFOT.Core
{
    /// <summary>
    /// Main Zenject bindings installer
    /// </summary>
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] UFOConfig ufoConfig;
        [SerializeField] HumanRoot humanRoot;

        public override void InstallBindings()
        {
            Container.BindInstance(ufoConfig).NonLazy();  
            Container.BindInstance(humanRoot).NonLazy();

            Container.Bind<UFOData>().AsSingle().NonLazy();
            Container.Bind<HumanPool>().AsSingle().NonLazy();
            
            Container.BindFactory<ShopProduct, PurchaseCommand, PurchaseCommand.Factory>();
            Container.BindFactory<HumanController, CaptureHumanCommand, CaptureHumanCommand.Factory>();
            Container.BindFactory<UnloadHumansCommand, UnloadHumansCommand.Factory>();
            Container.BindFactory<bool, PauseCommand, PauseCommand.Factory>();

            Container.BindFactory<GameObject, Transform, HumanController, HumanController.Factory>().FromFactory<HumanFactory>();
            
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<UfoDataUpdatedSignal>();
            Container.DeclareSignal<HumanDestroyedSignal>();
            Container.DeclareSignal<BaseEnterSignal>();
            Container.DeclareSignal<BaseExitSignal>();

            Application.targetFrameRate = 60;
        }
    }
}