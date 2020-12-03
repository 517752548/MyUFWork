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
    public class PathfindingIPathModifierWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.IPathModifier);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 1, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PreProcess", _m_PreProcess);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getOrder", _g_get_Order);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Order", _g_get_Order);
            
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "Pathfinding.IPathModifier does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.IPathModifier gen_to_be_invoked = (Pathfinding.IPathModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.Apply( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PreProcess(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.IPathModifier gen_to_be_invoked = (Pathfinding.IPathModifier)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.PreProcess( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Order(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.IPathModifier gen_to_be_invoked = (Pathfinding.IPathModifier)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Order);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
