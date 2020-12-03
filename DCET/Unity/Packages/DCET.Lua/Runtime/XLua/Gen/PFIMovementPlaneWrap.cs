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
    public class PFIMovementPlaneWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.IMovementPlane);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToPlane", _m_ToPlane);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToWorld", _m_ToWorld);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.IMovementPlane does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToPlane(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IMovementPlane gen_to_be_invoked = (PF.IMovementPlane)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    
                        UnityEngine.Vector2 gen_ret = gen_to_be_invoked.ToPlane( 
                        _p );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    float _elevation;
                    
                        UnityEngine.Vector2 gen_ret = gen_to_be_invoked.ToPlane( 
                        _p, 
                        out _elevation );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _elevation);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.IMovementPlane.ToPlane!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToWorld(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IMovementPlane gen_to_be_invoked = (PF.IMovementPlane)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _p;translator.Get(L, 2, out _p);
                    float _elevation = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.ToWorld( 
                        _p, 
                        _elevation );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector2>(L, 2)) 
                {
                    UnityEngine.Vector2 _p;translator.Get(L, 2, out _p);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.ToWorld( 
                        _p );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.IMovementPlane.ToWorld!");
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
