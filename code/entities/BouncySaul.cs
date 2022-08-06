using Sandbox;
using System;

[Spawnable]
[Library( "ent_bouncysaul", Title = "Bouncy Saul" )]
public partial class BouncySaulEntity : Prop, IUse
{
	public float MaxSpeed { get; set; } = 1000.0f;
	public float SpeedMul { get; set; } = 1.2f;

	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/saul.vmdl" );
		SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
		Scale = Rand.Float( 0.5f, 2.0f );
	}

	protected override void OnPhysicsCollision( CollisionEventData eventData )
	{
		var speed = eventData.PreVelocity.Length;
		var direction = Vector3.Reflect( eventData.PreVelocity.Normal, eventData.Normal.Normal ).Normal;
		Velocity = direction * MathF.Min( speed * SpeedMul, MaxSpeed );
	}

	public bool IsUsable( Entity user )
	{
		return true;
	}

	public bool OnUse( Entity user )
	{
		if ( user is Player player )
		{
			player.Health += 10;

			Delete();
		}

		return false;
	}
}
