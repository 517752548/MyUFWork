using System;

	[AttributeUsage (AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	public class RBindAttribute:Attribute
	{
		public RBindAttribute ()
		{
		}

		private String _changedType = "changed";

		public string changedType {
			get {
				return _changedType;
			}
			set {
				_changedType = value;
			}
		}

		public String _handler = null;
		
		public String handler {
			
			get {
				return _handler;
			}set {
				_handler = value;
			}
		}
	}

