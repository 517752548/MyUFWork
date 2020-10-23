package cn.uc.g.sdk.cp.service;

import java.util.Map;

import org.apache.log4j.Logger;

import cn.uc.g.sdk.cp.config.Configuration;
import cn.uc.g.sdk.cp.constant.StateCode;
import cn.uc.g.sdk.cp.http.SDKHttpClient;
import cn.uc.g.sdk.cp.model.DomainInfo;
import cn.uc.g.sdk.cp.model.SDKException;
import cn.uc.g.sdk.cp.protocol.CpRequest;
import cn.uc.g.sdk.cp.protocol.CpRequestHelper;
import cn.uc.g.sdk.cp.protocol.CpResponse;
import cn.uc.g.sdk.cp.util.BeanToMapUtil;
import cn.uc.g.sdk.cp.util.JacksonUtil;


public abstract class AbstractSDKService {
    
    private final static boolean DEBUG = Configuration.getDebug();
    private static Logger log = Logger.getLogger(AbstractSDKService.class.getName());

    protected static SDKHttpClient client = new SDKHttpClient();

//    //如果希望自己设置HttpClient的各种参数，可以使用下面的构造方法
//    protected static SDKHttpClient client = new SDKHttpClient(int maxConPerHost, int conTimeOutMs, int soTimeOutMs);
    
    /**
     * 调用SDKServer接口并返回实体类
     * @param params
     * @param sidInfo 
     * @param entityClazz
     * @return
     * @throws SDKException
     */
    protected static <T> T getSDKServerResponse (Map<String, Object> params, String prefix, String serviceName, Class<T> entityclazz) throws SDKException{
        T entity = null;
        try {
            CpRequest requestObj = CpRequestHelper.assemblyParams(serviceName, params);
            String requestBody = JacksonUtil.encode(requestObj);
            String responseBody = "";
            
            //首次请求时，识别智能域名解析缓存中是否有值，若有则代表直接使用智能域名解析的ip
            DomainInfo domainCache = DomainServerService.getDomainByCache();
            DomainInfo domainInfo = null;//请求智能域名解析客户端的数据
            try {
                if(domainCache != null){
                    log("智能域名解析系统缓存存在，直接使用智能域名解析系统返回的IP"+assemblyUrl("http://" + domainCache.getIpAddress(), prefix , serviceName)+"访问服务端.");
                    responseBody = client.post(assemblyUrl("http://" + domainCache.getIpAddress(), prefix , serviceName), requestBody);
                }
                else{
                    responseBody = client.post(assemblyUrl(Configuration.getSDKServerBaseUrl(), prefix , serviceName), requestBody);
                }
            } catch (SDKException e) {
                if(e.getErrorCode() == -1){//网络无法连接场景
                    //首先判断上一次是使用智能域名解析还是使用缓存的ip
                    String ip = domainCache == null ? null :  domainCache.getIpAddress();
                    
                    //使用智能域名解析客户端
                    domainInfo = DomainServerService.getDomainByServer(ip);
                    if(domainInfo == null){
                        log("请求常规接口"+assemblyUrl(Configuration.getSDKServerBaseUrl(), prefix , serviceName)+"失败，请求智能域名解析也失败.");
                        throw e;
                    }
                    
                    //重新使用智能域名解析客户端返回的ip地址进行请求
                    responseBody = client.post(assemblyUrl("http://" + domainInfo.getIpAddress(), prefix , serviceName), requestBody);
                }
                else{
                    throw e;
                }
            }
            
            if("".equals(responseBody)){
                throw new SDKException("网络响应异常", -1);
            }
            
            CpResponse responseObj = null;
            try {
                responseObj = (CpResponse) JacksonUtil.decode(responseBody, CpResponse.class);
            } catch (Exception e) {
                //再一次异常的情况下，判断是否已使用过智能域名解析系统一次
                String ip = domainInfo == null ? (domainCache == null ? null :  domainCache.getIpAddress()) : domainInfo.getIpAddress();
                
                // 无法正确解析报文，使用智能域名解析客户端
                domainInfo = DomainServerService.getDomainByServer(ip);
                if(domainInfo == null){
                    log("请求常规接口"+assemblyUrl(Configuration.getSDKServerBaseUrl(), prefix , serviceName)+"失败，请求智能域名解析也失败.");
                    throw e;
                }
                
                //重新使用智能域名解析客户端返回的ip地址进行请求
                responseBody = client.post(assemblyUrl("http://" + domainInfo.getIpAddress(), prefix , serviceName), requestBody);
                try {
                    responseObj = (CpResponse) JacksonUtil.decode(responseBody, CpResponse.class);
                } catch (Exception jsondecodeerror) {
                    throw new SDKException("解析报文异常", jsondecodeerror, -1);
                }
            }
            
            if(responseObj == null){
                throw new SDKException("请求接口无响应", -1);
            }
            
            if(responseObj.getState().getCode() != StateCode.SUCCESS){
                //接口返回失败，以异常的形式抛出
                throw new SDKException(responseObj.getState().getMsg(), responseObj.getState().getCode());
            }
            
            //返回的结果集安全解析
            if(responseObj.getData() instanceof Map){
                entity = BeanToMapUtil.convertMap(entityclazz, (Map<String, Object>)responseObj.getData());
            }
            else{
                entity = (T) responseObj.getData();//直接赋值
            }
        } catch (Exception e) {
            if(e instanceof SDKException){
                SDKException sdkException = (SDKException) e;
                throw sdkException;
            }
            throw new SDKException("调用接口出错", e, -1);
        }
        return entity;
    }
    
    /**
     * 组装POST请求url
     * @param sdkServerBaseUrl
     * @param prefix
     * @param serviceName
     * @return
     */
    protected static String assemblyUrl(String sdkServerBaseUrl, String prefix, String serviceName) {
        String postUrl = filtSplictWord(sdkServerBaseUrl, Boolean.FALSE) + "/" + filtSplictWord(prefix, Boolean.TRUE) + filtSplictWord(serviceName, Boolean.TRUE);
        return postUrl;
    }
    
    /**
     * url和method统一去掉“/” OR “\”
     * @param str
     * @param isStartsWith
     * @return
     */
    private static String filtSplictWord(String str, boolean isStartsWith){
        if(str==null ||"".equals(str)){
            return str;
        }
        if(isStartsWith){
            if(str.startsWith("\\") || str.startsWith("/")){
                return str.substring(1, str.length());
            }
        }else{
            if(str.endsWith("\\") || str.endsWith("/")){
                return str.substring(0, str.length()-1);
            }
        }
        return str;
    }

    /**
     * log调试
     * 
     */
    protected static void log(String message) {
        if (DEBUG) {
            log.debug(message);
        }
    }

}
