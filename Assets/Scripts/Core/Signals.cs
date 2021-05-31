using UFOT.Human;

namespace UFOT.Signals
{
    /// <summary>
    /// Fires when UFOData updated
    /// </summary>
    public class UfoDataUpdatedSignal
    {
    }
    
    /// <summary>
    /// Fires when Human pushed to Pool
    /// </summary>
    public class HumanDestroyedSignal
    {
        public HumanController human;
    }

    /// <summary>
    /// Fires when UFO enter base
    /// </summary>
    public class BaseEnterSignal
    {
    }
    
    /// <summary>
    /// Fires when UFO exit base
    /// </summary>
    public class BaseExitSignal
    {
    }
}