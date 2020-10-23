using System;
using System.Collections.Generic;
using System.Collections;

public delegate void RMetaEventHandler (RMetaEvent e);

	public class EventCore
	{
        /**事件的监听列表*/
		private static Dictionary<String, ArrayList> handlersData = new Dictionary<string,ArrayList> ();

		/*
         *
         *添加事件
         *
         *
         */

		public static void addRMetaEventListener (String type, RMetaEventHandler handler)
		{
			if (handler == null) {
				throw new Exception ("Type:" + type + ", handler不能为空!!!");
			}

			if (handlersData.ContainsKey (type) == false) {
				handlersData [type] = new ArrayList ();
			}
			ArrayList list = handlersData [type];
			if (list.Contains(handler) == false) {
				list.Add (handler);
			}
		}

		/*
         * 
         * 移除事件
         * 
         * 
         */
		public static void removeRMetaEventListener (String type, RMetaEventHandler handler)
		{
			if (handlersData.ContainsKey (type)) {
				ArrayList list = handlersData [type];
				list.Remove (handler);
				handler = null;
				if (list.Count == 0) {
					handlersData.Remove (type);
				}
			}
		}

		public static void dispatchRMetaEvent (RMetaEvent e)
		{
			if (handlersData.ContainsKey (e.type)) {
				ArrayList list = handlersData [e.type];
				for (int i = 0; i < list.Count; i++) {
					RMetaEventHandler temp = list [i] as RMetaEventHandler;
					temp (e);
				}
			}
		}

		/*
         * 
         * 派发事件
         * 
         * 
         */
		public static void dispathRMetaEventByParms (String type, object data)
		{
			dispatchRMetaEvent (new RMetaEvent (type, data));
		}
		
		public static void Clear()
		{
			handlersData.Clear();
		}
	}