using Sandbox;

[Spawnable]
[Library( "npc_dummy_wontdie", Title = "Damage Checker" )]
public partial class DummyWontDie : NPC
{
	[Net]
	private float lastDamage { get; set; }

	[Event.Frame]
	public void OnFrame()
	{
		DebugOverlay.Text( $"Last Damage: {lastDamage}", EyePosition );
	}

	public override void TakeDamage( DamageInfo info )
	{
		base.TakeDamage( info );

		var damage = info.Damage;

		if ( GetHitboxGroup( info.HitboxIndex ) == 1 )
		{
			damage *= 2.0f;
		}

		lastDamage = damage;

		Log.Info( $"Dummy Take Damage: {damage}" );
	}

	public override void Spawn()
	{
		base.Spawn();
		
		SetModel( "models/scientist/scientist.vmdl" );
		SetBodyGroup( 1, Rand.Int( 0, 3 ) );
	}
}
