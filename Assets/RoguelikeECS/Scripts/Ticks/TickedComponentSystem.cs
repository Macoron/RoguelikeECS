using Unity.Entities;

public abstract class TickedComponentSystem : ComponentSystem, ITickable
{
    private bool newTick;

    protected abstract void OnTick();

    protected override void OnCreate()
    {
        base.OnCreate();
        TickedController.RegisterTickable(this);
    }

    protected override void OnUpdate()
    {
        // usualy - do nothing, we care only about ticks
        if (newTick)
        {
            OnTick();
            newTick = false;
        }
    }

    public void OnTickRecived()
    {
        newTick = true;
    }
}
