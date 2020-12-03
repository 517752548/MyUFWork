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
    public class PFAstarMathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.AstarMath);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "MapTo", _m_MapTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FormatBytesBinary", _m_FormatBytesBinary_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.AstarMath does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MapTo_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    float _startMin = (float)LuaAPI.lua_tonumber(L, 1);
                    float _startMax = (float)LuaAPI.lua_tonumber(L, 2);
                    float _targetMin = (float)LuaAPI.lua_tonumber(L, 3);
                    float _targetMax = (float)LuaAPI.lua_tonumber(L, 4);
                    float _value = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        float gen_ret = PF.AstarMath.MapTo( 
                        _startMin, 
                        _startMax, 
                        _targetMin, 
                        _targetMax, 
                        _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FormatBytesBinary_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    int _bytes = LuaAPI.xlua_tointeger(L, 1);
                    
                        string gen_ret = PF.AstarMath.FormatBytesBinary( 
                        _bytes );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
