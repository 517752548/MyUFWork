package com.opi.gibp.tools.performance.utils;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;

public class HttpUtil {
	private static String URL_ENCODE = "UTF-8";
	private static final String CHARSET = "character=";
	
	public static String getUrl(String requestUrl, int timeout) throws IOException{
		BufferedReader reader = null;
		HttpURLConnection urlConnection = null;
		try {
			InputStream urlStream;
			URL url = new URL(requestUrl);
			urlConnection = (HttpURLConnection)url.openConnection();
			urlConnection.setConnectTimeout(timeout * 1000);
			urlConnection.setReadTimeout(timeout * 1000);
			urlConnection.connect();
			urlStream = urlConnection.getInputStream();
			reader = new BufferedReader(new InputStreamReader(urlStream, URL_ENCODE));
			char[] _buff = new char[128];
			StringBuilder temp = new StringBuilder();
			int _len = -1;
			while((_len = reader.read(_buff))!=-1){
				temp.append(_buff, 0, _len);
			}
			return temp.toString();
		} catch (IOException e) {
			e.printStackTrace();
			throw e;
		} finally{
			try {
				if(reader != null){
					reader.close();
				}
				urlConnection.disconnect();
			} catch (Exception e2) {
				e2.printStackTrace();
			}
		}
	}
	
	public static String postUrl(String reqUrl, Map<String,String> parameters,int timeout){
        HttpURLConnection url_con = null;
        String responseContent = null;
        try{
            StringBuffer params = new StringBuffer();
            for (Iterator<Entry<String, String>> iter = parameters.entrySet().iterator(); iter.hasNext();){
                @SuppressWarnings("rawtypes")
				Entry element = (Entry) iter.next();
                params.append(element.getKey().toString());
                params.append("=");
                params.append(URLEncoder.encode(element.getValue().toString(),URL_ENCODE));
                params.append("&");
            }

            if (params.length() > 0)
            {
                params = params.deleteCharAt(params.length() - 1);
            }

            URL url = new URL(reqUrl);
            url_con = (HttpURLConnection) url.openConnection();
            url_con.setRequestMethod("POST");
             url_con.setConnectTimeout(timeout*1000);//（单位：毫秒）jdk
            // 1.5换成这个,连接超时
             url_con.setReadTimeout(timeout*1000);//（单位：毫秒）jdk 1.5换成这个,读操作超时
            url_con.setDoOutput(true);
            byte[] b = params.toString().getBytes();
            url_con.getOutputStream().write(b, 0, b.length);
            url_con.getOutputStream().flush();
            url_con.getOutputStream().close();

            InputStream in = url_con.getInputStream();
            BufferedReader rd = new BufferedReader(new InputStreamReader(in, URL_ENCODE));
            String tempLine = rd.readLine();
            StringBuffer tempStr = new StringBuffer();
            String crlf=System.getProperty("line.separator");
            while (tempLine != null){
                tempStr.append(tempLine);
                tempStr.append(crlf);
                tempLine = rd.readLine();
            }
            responseContent = tempStr.toString();
            rd.close();
            in.close();
        }catch (IOException e){
            e.printStackTrace();
        }finally{
            if (url_con != null){
                url_con.disconnect();
            }
        }
        return responseContent;
    }
	
	static String parseEncoding(HttpURLConnection urlConnection){
		String _encoding = urlConnection.getContentEncoding();
		if(_encoding != null){
			return _encoding;
		}
		String _contentType = urlConnection.getContentType();
		if(_contentType != null){
			int _index = _contentType.toLowerCase().indexOf(CHARSET);
			if(_index > 0){
				_encoding = _contentType.substring(_index + CHARSET.length());
			}
		}
		
		if(_encoding != null){
			return _encoding;
		}else{
			return URL_ENCODE;
		}
	}
}
