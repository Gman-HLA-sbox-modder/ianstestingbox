using Sandbox;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[Spawnable]
[Library("npc_waltuh", Title = "waltuh")]
public partial class Waltuh : NPC
{
	public override float Speed => 300;
	public override float SpawnHealth => 50;
	public override string ModelPath => "models/waltuh/waltuh.vmdl";
	public override bool HaveDress => false;
	private Sound WaltSnd;

	Player Target;

	public override void Spawn()
	{
		base.Spawn();
		WaltSnd = base.PlaySound("waltuh_full");
	}

	public override void TakeDamage( DamageInfo info )
	{
		
	}

	private void FindTarget()
	{
		var rply = All.OfType<Player>().ToArray();

		Target = rply[Rand.Int(0, rply.Count() - 1)];
	}

	public override void OnTick()
	{
		if (Target == null || Target.LifeState == LifeState.Dead)
			FindTarget();
		else
		{
			Steer = new NavSteer();
			Steer.Target = Target.Position;
			Steer.DontAvoidance = e => true;
		}
	}

	public override void DoMeleeStrike()
	{
		if (Target == null || Target.LifeState == LifeState.Dead) return;
		if (Target.Position.Distance(Position) < 100)
		{
			MeleeStrike(113, 1.5f);
		}
	}

	public override void OnKilled()
	{
		base.OnKilled();
		WaltSnd.Stop();
		PlaySound( "walt_clear" );
	}
}
