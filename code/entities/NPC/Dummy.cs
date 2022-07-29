using Sandbox;

[Spawnable]
[Library( "npc_dummy", Title = "Damage Test" )]
public partial class Dummy : NPC
{
	public override float SpawnHealth => 100;

	private TimeSince TimeSinceLastIBAttempt;

	public override void Spawn() 
	{
		base.Spawn();

		SetModel("models/scientist/scientist.vmdl");

		TimeSinceLastIBAttempt = 0;
	}

	[Event.Frame]
	public void OnFrame()
	{
		DebugOverlay.Text( this.Health.ToString(), EyePosition );
	}

	// [Event.Tick]
	public override void Tick() 
	{
		base.Tick();

		// Log.Info(TimeSinceLastIBAttempt);

		var randInt = Rand.Int(1, 5);

		if (TimeSinceLastIBAttempt >= 5.0f)
		{
			if (randInt == 1) 
			{
				SetAnimParameter("b_idlebreaker", true);

				TimeSinceLastIBAttempt = 0;
			} else if (randInt != 1)
			{
				TimeSinceLastIBAttempt = 0;
			}
		}
	}

	public override void TakeDamage( DamageInfo info )
	{
		base.TakeDamage( info );

		var damage = info.Damage;

		if ( GetHitboxGroup( info.HitboxIndex ) == 1 )
		{
			damage *= 2.0f;
		}

		Log.Info( $"Dummy Take Damage: {damage}" );
	}
}
