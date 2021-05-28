using UFOT.Human;

namespace UFOT.Signals
{
    public class UfoDataUpdatedSignal
    {
    }
    
    public class HumanDestroyedSignal
    {
        public HumanActor human;
    }

    public class RegisterHumanSpawnSignal
    {
        public HumanSpawn humanSpawn;
    }
}