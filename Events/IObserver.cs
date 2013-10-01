using UnityEngine;
using System.Collections;

namespace GameCell.Unicorn.Events
{
	public interface IObserver 
	{
		void OnNotification( Notification notify );
	}
}

