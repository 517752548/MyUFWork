using System;
using UnityEngine;
using System.Text;

	static public class StringFormat
	{
		static public string Fromat (string szFormat, params object[] args)
		{
			try {
				if (string.IsNullOrEmpty (szFormat)) {
					ClientLog.LogWarning ("String format :szFormat is null or empty");
					return "";
				}
				return string.Format (szFormat, args);
			} catch (Exception ex) {
				ClientLog.LogError ("String Format is exception ,error code:" + ex.ToString ());
			}
			return "";
		}

		static public string Format (IFormatProvider provider, string szFormat, params object[] args)
		{
			try {
				if (string.IsNullOrEmpty (szFormat)) {
					ClientLog.LogWarning ("String format:szFormat is null or empty!");
					return "";

				}
				return string.Format (provider, szFormat, args);
			} catch (Exception ex) {
				ClientLog.LogError ("String Format is exception ,error code:" + ex.ToString ());
			}
			return "";
		}

		static public string StringToBase64 (string str)
		{
			try {
				return Convert.ToBase64String (Encoding.UTF8.GetBytes (str));
			} catch (Exception ex) {
				ClientLog.LogError ("StringToBase64,error code:" + ex.ToString ());
			}

			return "";
		}

		static public string Base64ToString (string str)
		{
			try {
				return Encoding.UTF8.GetString (Convert.FromBase64String (str));
			} catch (Exception ex) {
				ClientLog.LogError ("Base64ToString,error code:" + ex.ToString ());
			}
			return "";
		}
	}