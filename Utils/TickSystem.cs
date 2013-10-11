using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DarkCat.Unicorn.Utils
{
	public interface ITickable
	{
		void Tick( float delta );
		
		void FixedTick( float delta );
		
	}
	
	public class TickBehaviour:MonoBehaviour
	{
		public List<ITickable> TickTargetList;
		
		void Awake()
		{
			TickTargetList = new List<ITickable>();
		}
		
		void Update ()
		{
			float delta = Time.deltaTime;
			/*
			foreach( ITickable target in TickTargetList )
			{
				target.Tick( delta );
			}
			*/
			for ( int i = TickTargetList.Count - 1 ; i >= 0 ; i-- )
			{
				TickTargetList[i].Tick(delta);
			}
		}
		
		void FixedUpdate()
		{
			float delta = Time.fixedDeltaTime;
			for ( int i = TickTargetList.Count - 1 ; i >= 0 ; i-- )
			{
				TickTargetList[i].FixedTick(delta);
			}
			/*
			foreach( ITickable target in TickTargetList )
			{
				target.FixedTick( delta );
			}
			*/
		}
	}
	
	public class TickSystem
	{	
		private static List<TickSystem> TickSystemList;
		
		public TickSystem()
		{
			Init();
		}
		
		public TickSystem( string name = "ticker" )
		{
			Init( name );
		}
		
		private void Init( string name = "ticker" )
		{
			if( TickSystemList == null ) TickSystemList = new List<TickSystem>();
			
			foreach( TickSystem t in TickSystemList ) 
			{
				if( t.Name == name ) {
					Debug.LogError( String.Format( "TickSystem ({0}) Already Exist!!" , name ) );
					return;
				}
			}
			
			this.Name = name;
			tickGO = new GameObject( name );
			ticker = tickGO.AddComponent<TickBehaviour>();
			TickSystemList.Add( this );
		}
		
		private string Name;
		
		private TickBehaviour ticker;
		
		private GameObject tickGO;	
		
		public void AddTickTarget( ITickable target )
		{
			List<ITickable> list = ticker.TickTargetList;
			if( !CheckTickTargetExist( target ) )
			{
				list.Add( target );
			}
		}
		
		public void RemoveTickTarget( ITickable target )
		{
			List<ITickable> list = ticker.TickTargetList;
			if( CheckTickTargetExist( target ) )
			{
				list.Remove( target );
			}
		}
		
		public void RemoveAllTickTarget( ITickable target )
		{
			List<ITickable> list = ticker.TickTargetList;
			list.RemoveRange(0,list.Count);
		}
		
		public bool CheckTickTargetExist( ITickable target )
		{
			List<ITickable> list = ticker.TickTargetList;
			return list.Contains( target );
		}
	}
}
