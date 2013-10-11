using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DarkCat.Unicorn.Events
{
	public class NotificationManager
	{
		private Dictionary<string,IList> _dic;
		
		private static NotificationManager _instance;
		
		public static NotificationManager instance {
			get{
				if( _instance == null ) _instance = new NotificationManager();
				return _instance;
			}
		}
		
		public NotificationManager()
		{
			//Debug.Log("NotificationManager Builded");
			init();
		}
		
		public void init()
		{
			_dic = new Dictionary<string,IList>();
		}
		
		public void SendNotification ( string type )
		{
			SendNotification( type , null );
		}
		
		public void SendNotification ( string type , object data )
		{
			if( _dic.ContainsKey(type) )
			{
				IList list = _dic[type];
				int len = list.Count;
				for( int i = 0 ; i < len ; i++ ){
					((IObserver)list[i]).OnNotification( new Notification( type , data ) );
				}
			}
		}
		
		public void AddListener( IObserver observer , List<string> list )
		{
			int len = list.Count;
			for( int i = 0 ; i < len ; i++ ){
				AddListener( observer , list[i]);
			}
		}
		
		public void AddListener( IObserver observer , string type )
		{
			if( !_dic.ContainsKey(type) ) _dic[type] = new List<IObserver>();
			IList list = _dic[type];
			if( !list.Contains(observer) ){
				list.Add( observer );
			}
		}
	
		public void RemoveListener ( IObserver observer, string type )
		{
			if( _dic.ContainsKey(type) ){
				IList list = _dic[type];
				list.Remove( observer );
			}
		}
		
		public void RemoveAllListener ( IObserver observer )
		{
			foreach( string type in _dic.Keys )
			{
				RemoveListener( observer , type );
			}
		}
	}
}