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
    public class PFFloodPathTracerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.FloodPathTracer);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Trace", _m_Trace);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Construct", _m_Construct_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.FloodPathTracer gen_ret = new PF.FloodPathTracer();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.FloodPathTracer constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Construct_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<PF.FloodPath>(L, 2)&& translator.Assignable<PF.OnPathDelegate>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    PF.FloodPath _flood = (PF.FloodPath)translator.GetObject(L, 2, typeof(PF.FloodPath));
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 3);
                    
                        PF.FloodPathTracer gen_ret = PF.FloodPathTracer.Construct( 
                        _start, 
                        _flood, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<PF.FloodPath>(L, 2)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    PF.FloodPath _flood = (PF.FloodPath)translator.GetObject(L, 2, typeof(PF.FloodPath));
                    
                        PF.FloodPathTracer gen_ret = PF.FloodPathTracer.Construct( 
                        _start, 
                        _flood );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.FloodPathTracer.Construct!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Trace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.FloodPathTracer gen_to_be_invoked = (PF.FloodPathTracer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _from = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.Trace( 
                        _from );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
