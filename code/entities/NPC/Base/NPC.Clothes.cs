using Sandbox;

partial class NPC
{
	ModelEntity pants;
	ModelEntity jacket;
	ModelEntity shoes;
	ModelEntity hat;

	public void Dress()
	{
		
	}

	public void DeleteAllDress()
	{
		while ( Children.Count > 0 )
		{
			for ( var i = 0; i < Children.Count; i++ )
			{
				var child = Children[i];

				if ( !child.Tags.Has( "clothes" ) ) continue;
				if ( child is not ModelEntity ) continue;

				child.Delete();
			}
		}

		SetBodyGroup( "head", 0 );
		SetBodyGroup( "Chest", 0 );
		SetBodyGroup( "Legs", 0 );
		SetBodyGroup( "Hands", 0 );
		SetBodyGroup( "Feet", 0 );
	}

	public void AddClothing( string model )
	{
		new ModelEntity( model, this ).Tags.Add( "clothes" );
	}
}
