package com.imop.lj.gameserver.dirtywords;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.CoreConnectionPNames;

import com.imop.lj.common.constants.Loggers;
public class WordFilterNetDownload {
	//CSV 编码
	private String netEncod = "GBK";
	//本地编码
	private String nativeEncod = "UTF-8";
	//连接超时设置
	public final int DEFAULT_CONNECTION_TIMEOUT = 60 * 1000;
	//读取超时设置
	public final int DEFAULT_SO_TIMEOUT = 60 * 1000;
	/**
	 * @param args
	 */
	public static void main(String[] args) {	
//		WordFilterNetDownload tt = new WordFilterNetDownload();
//		String url = "http://down.51rs.cn/games-common/dirtywords/part.csv";
//		String outFile = "C://Documents and Settings//Administrator//My Documents//ccpart.txt";
//		String url = "http://down.51rs.cn/games-common/dirtywords/full.csv";
//		String outFile = "C://Documents and Settings//Administrator//My Documents//ccfull.txt";
//		String filemd5 = "";
//		tt.download(url, outFile, filemd5);
	}
	
	public String[] download(String url) {  
		List<String> netWordsList = new ArrayList<String>();
        HttpClient httpClient = new DefaultHttpClient();  
        HttpGet httpGet = new HttpGet(url);
		HttpEntity entity = null;
		BufferedReader in = null; 
		
        try {  
			//设置超时信息
        	httpClient.getParams().setParameter(CoreConnectionPNames.CONNECTION_TIMEOUT,DEFAULT_CONNECTION_TIMEOUT);
        	httpClient.getParams().setParameter(CoreConnectionPNames.SO_TIMEOUT,DEFAULT_SO_TIMEOUT);
        	
        	long time1 = System.currentTimeMillis();
        	Loggers.dirtyWordsLogger.info("WordFilterNetDownload.download() time1="+time1);
        	
            HttpResponse httpResponse = httpClient.execute(httpGet);  
            
            // 状态不对，则直接返回null
         	int status = httpResponse.getStatusLine().getStatusCode();
         	if (status != 200) {
         		return null;
         	}
            
        	long time2 = System.currentTimeMillis();
        	Loggers.dirtyWordsLogger.info("WordFilterNetDownload.download() time2="+time2);
            
            entity = httpResponse.getEntity();
         	in = new BufferedReader(new InputStreamReader(entity.getContent(), netEncod));
         	String ln;
         	while((ln = in.readLine()) != null){
         		String newLn = new String(ln.getBytes(netEncod), netEncod);
         		String newLnUtf = getUTF8StringFromGBKString(newLn);
         		netWordsList.add(newLnUtf);
         	}
         	
        	long time3 = System.currentTimeMillis();
        	Loggers.dirtyWordsLogger.info("WordFilterNetDownload.download() time3="+time3);
        	
        	Loggers.dirtyWordsLogger.info("WordFilterNetDownload.download() time1="+time1+" time2="+time2+" time3="+time3);
        } catch (ClientProtocolException e) {  
        	Loggers.dirtyWordsLogger.info("WordFilterNetDownload.download() ClientProtocolExceptione="+e.toString());  
        } catch (IOException e) {  
        	Loggers.dirtyWordsLogger.info("WordFilterNetDownload.download() IOException="+e.toString());  
        } finally {  
            httpClient.getConnectionManager().shutdown();  
            if(in!=null){
                try {
					in.close();
				} catch (IOException e) {
					Loggers.dirtyWordsLogger.info("WordFilterNetDownload.download() in close IOException="+e.toString());  
				}
            }
        }  
        return netWordsList.toArray(new String[netWordsList.size()]);  
    }  
	
	public String getUTF8StringFromGBKString(String gbkStr) {   
        try {   
            return new String(getUTF8BytesFromGBKString(gbkStr), nativeEncod);   
        } catch (UnsupportedEncodingException e) {   
        	Loggers.dirtyWordsLogger.info("WordFilterNetDownload.getUTF8StringFromGBKString() UnsupportedEncodingException="+e.toString());  
            throw new InternalError();   
        }   
    }  
	
	public byte[] getUTF8BytesFromGBKString(String gbkStr) {   
	    int n = gbkStr.length();   
	    byte[] utfBytes = new byte[3 * n];   
	    int k = 0;   
	    for (int i = 0; i < n; i++) {   
	        int m = gbkStr.charAt(i);   
	        if (m < 128 && m >= 0) {   
	            utfBytes[k++] = (byte) m;   
	            continue;   
	        }   
	        utfBytes[k++] = (byte) (0xe0 | (m >> 12));   
	        utfBytes[k++] = (byte) (0x80 | ((m >> 6) & 0x3f));   
	        utfBytes[k++] = (byte) (0x80 | (m & 0x3f));   
	    }   
	    if (k < utfBytes.length) {   
	        byte[] tmp = new byte[k];   
	        System.arraycopy(utfBytes, 0, tmp, 0, k);   
	        return tmp;   
	    }   
	    return utfBytes;   
	}  
}
