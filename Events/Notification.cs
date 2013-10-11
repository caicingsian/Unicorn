using System;

namespace DarkCat.Unicorn.Events
{
	public class Notification
	{	
		private string _type;
		
		private object _body;
		
		public string type{
			get{
				return _type;
			}
		}
		
		public object body{
			get{
				return _body;
			}
		}
		
		public Notification ( string type , object body )
		{
			this._type = type;
			this._body = body;
		}
	}
}

