using Content.Shared._Goobstation.Vehicles; // Frontier: migrate under _Goobstation
using Content.Server._NF.Radar; // Frontier
using Content.Shared.Buckle.Components; // Frontier
using Content.Shared._NF.Radar; // Frontier

namespace Content.Server._Goobstation.Vehicles; // Frontier: migrate under _Goobstation

public sealed class VehicleSystem : SharedVehicleSystem
{
    //// Frontier: logic for adding and removing RadarBlipComponent if strapped or not
    [Dependency] private readonly RadarBlipSystem _radar = default!;

    /// <summary>
    /// Configures the radar blip for a vehicle entity.
    /// </summary>
    protected override void OnStrapped(Entity<VehicleComponent> uid, ref StrappedEvent args)
    {
        base.OnStrapped(uid, ref args);
        _radar.SetupVehicleRadarBlip(uid);
    }

    protected override void OnUnstrapped(Entity<VehicleComponent> uid, ref UnstrappedEvent args)
    {
        RemComp<RadarBlipComponent>(uid);
        base.OnUnstrapped(uid, ref args);
    }

    protected override void HandleEmag(Entity<VehicleComponent> ent)
    {
        RemComp<RadarBlipComponent>(ent);
    }

    protected override void HandleUnemag(Entity<VehicleComponent> ent)
    {
        if (ent.Comp.Driver != null)
            _radar.SetupVehicleRadarBlip(ent);
    }
    // End Frontier
}
