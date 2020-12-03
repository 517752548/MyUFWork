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
    public class PathfindingRecastBBTreeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RecastBBTree);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "QueryInBounds", _m_QueryInBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Remove", _m_Remove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Insert", _m_Insert);
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.RecastBBTree gen_ret = new Pathfinding.RecastBBTree();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RecastBBTree constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_QueryInBounds(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastBBTree gen_to_be_invoked = (Pathfinding.RecastBBTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Rect _bounds;translator.Get(L, 2, out _bounds);
                    System.Collections.Generic.List<Pathfinding.RecastMeshObj> _buffer = (System.Collections.Generic.List<Pathfinding.RecastMeshObj>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<Pathfinding.RecastMeshObj>));
                    
                    gen_to_be_invoked.QueryInBounds( 
                        _bounds, 
                        _buffer );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastBBTree gen_to_be_invoked = (Pathfinding.RecastBBTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.RecastMeshObj _mesh = (Pathfinding.RecastMeshObj)translator.GetObject(L, 2, typeof(Pathfinding.RecastMeshObj));
                    
                        bool gen_ret = gen_to_be_invoked.Remove( 
                        _mesh );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Insert(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RecastBBTree gen_to_be_invoked = (Pathfinding.RecastBBTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.RecastMeshObj _mesh = (Pathfinding.RecastMeshObj)translator.GetObject(L, 2, typeof(Pathfinding.RecastMeshObj));
                    
                    gen_to_be_invoked.Insert( 
                        _mesh );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
