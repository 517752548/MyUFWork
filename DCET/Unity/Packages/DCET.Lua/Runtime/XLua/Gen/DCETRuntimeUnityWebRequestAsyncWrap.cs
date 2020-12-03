#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class DCETRuntimeUnityWebRequestAsyncWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DCETRuntime.UnityWebRequestAsync);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 6, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DownloadAsync", _m_DownloadAsync);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getProgress", _g_get_Progress);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getByteDownloaded", _g_get_ByteDownloaded);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getRequest", _g_get_Request);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getisCancel", _g_get_isCancel);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettcs", _g_get_tcs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettimeout", _g_get_timeout);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setRequest", _s_set_Request);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setisCancel", _s_set_isCancel);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settcs", _s_set_tcs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settimeout", _s_set_timeout);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Progress", _g_get_Progress);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ByteDownloaded", _g_get_ByteDownloaded);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Request", _g_get_Request);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isCancel", _g_get_isCancel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tcs", _g_get_tcs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "timeout", _g_get_timeout);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Request", _s_set_Request);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isCancel", _s_set_isCancel);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tcs", _s_set_tcs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "timeout", _s_set_timeout);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 1, 1);
			
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getcertificateHandler", _g_get_certificateHandler);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setcertificateHandler", _s_set_certificateHandler);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "certificateHandler", _g_get_certificateHandler);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "certificateHandler", _s_set_certificateHandler);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DCETRuntime.UnityWebRequestAsync gen_ret = new DCETRuntime.UnityWebRequestAsync();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DCETRuntime.UnityWebRequestAsync constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DownloadAsync(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _url = LuaAPI.lua_tostring(L, 2);
                    
                        System.Threading.Tasks.Task<string> gen_ret = gen_to_be_invoked.DownloadAsync( 
                        _url );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Progress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Progress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ByteDownloaded(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushuint64(L, gen_to_be_invoked.ByteDownloaded);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_certificateHandler(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, DCETRuntime.UnityWebRequestAsync.certificateHandler);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Request(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Request);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isCancel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isCancel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tcs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tcs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_timeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.timeout);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_certificateHandler(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    DCETRuntime.UnityWebRequestAsync.certificateHandler = (DCETRuntime.AcceptAllCertificate)translator.GetObject(L, 1, typeof(DCETRuntime.AcceptAllCertificate));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Request(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Request = (UnityEngine.Networking.UnityWebRequest)translator.GetObject(L, 2, typeof(UnityEngine.Networking.UnityWebRequest));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isCancel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isCancel = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tcs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tcs = (System.Threading.Tasks.TaskCompletionSource<string>)translator.GetObject(L, 2, typeof(System.Threading.Tasks.TaskCompletionSource<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_timeout(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DCETRuntime.UnityWebRequestAsync gen_to_be_invoked = (DCETRuntime.UnityWebRequestAsync)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.timeout = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
