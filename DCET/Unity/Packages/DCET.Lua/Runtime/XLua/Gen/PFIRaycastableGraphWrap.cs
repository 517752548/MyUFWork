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
    public class PFIRaycastableGraphWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.IRaycastableGraph);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Linecast", _m_Linecast);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.IRaycastableGraph does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Linecast(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IRaycastableGraph gen_to_be_invoked = (PF.IRaycastableGraph)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _start, 
                        _end );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _start, 
                        _end, 
                        _hint );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    PF.GraphHitInfo _hit;
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _start, 
                        _end, 
                        _hint, 
                        out _hit );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 6&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)&& translator.Assignable<System.Collections.Generic.List<PF.GraphNode>>(L, 6)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    PF.GraphHitInfo _hit;
                    System.Collections.Generic.List<PF.GraphNode> _trace = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<PF.GraphNode>));
                    
                        bool gen_ret = gen_to_be_invoked.Linecast( 
                        _start, 
                        _end, 
                        _hint, 
                        out _hit, 
                        _trace );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _hit);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.IRaycastableGraph.Linecast!");
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
