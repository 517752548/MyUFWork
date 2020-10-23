package com.imop.lj.tools.db;

import java.util.Properties;


public class ContentEngine {
	private Properties mainParameters = new Properties();

	public void storeArgsToProperties(String[] args) {
		if (args == null || args.length == 0) {
			return;
		}

		int startIndex = 0;
		while (startIndex < args.length) {
			String currentString = args[startIndex];
			if (currentString.charAt(0) == '-' && currentString.length() > 1) {
				// find a key as -keyname
				if (startIndex < args.length - 1) {
					// there is a value string following
					String keyValue = args[startIndex + 1];
					if (keyValue != null && keyValue.length() > 0) {
						String keyName = currentString.substring(1);
						mainParameters.put(keyName, keyValue);
					}
					startIndex += 2;
				} else {
					// to the end
					break;
				}
			} else {
				startIndex++;
			}
		}
	}

	public String getParameter(String name) {
		String retVal = mainParameters.getProperty(name);
		return (retVal == null) ? "" : retVal;
	}

}