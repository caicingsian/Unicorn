using UnityEngine;
using System.Collections;

namespace DarkCat.Unicorn.Events
{
	public interface IObserver 
	{
		void OnNotification( Notification notify );
	}
}

