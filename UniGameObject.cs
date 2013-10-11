using UnityEngine;
using System;
using DarkCat.Unicorn.Events;

namespace DarkCat.Unicorn
{
	public abstract  class UniGameObject : MonoBehaviour , IObserver
	{
		protected NotificationManager Notifier;
		
		public virtual void Init()
		{
			//Debug.Log("UniGameObject Init");
			Notifier = NotificationManager.instance;
		}
		
		public virtual void OnNotification( Notification notify )
		{
			
		}	
	}
}

