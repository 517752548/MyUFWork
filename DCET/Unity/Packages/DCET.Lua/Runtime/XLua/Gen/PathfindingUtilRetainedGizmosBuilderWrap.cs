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
    public class PathfindingUtilRetainedGizmosBuilderWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Util.RetainedGizmos.Builder);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawMesh", _m_DrawMesh);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawWireCube", _m_DrawWireCube);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawLine", _m_DrawLine);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Submit", _m_Submit);
						
            
			
						
			
			
			
			
			
			
			
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
					
					Pathfinding.Util.RetainedGizmos.Builder gen_ret = new Pathfinding.Util.RetainedGizmos.Builder();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.RetainedGizmos.Builder constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawMesh(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos.Builder gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos.Builder)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Util.RetainedGizmos _gizmos = (Pathfinding.Util.RetainedGizmos)translator.GetObject(L, 2, typeof(Pathfinding.Util.RetainedGizmos));
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    System.Collections.Generic.List<int> _triangles = (System.Collections.Generic.List<int>)translator.GetObject(L, 4, typeof(System.Collections.Generic.List<int>));
                    UnityEngine.Color[] _colors = (UnityEngine.Color[])translator.GetObject(L, 5, typeof(UnityEngine.Color[]));
                    
                    gen_to_be_invoked.DrawMesh( 
                        _gizmos, 
                        _vertices, 
                        _triangles, 
                        _colors );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawWireCube(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos.Builder gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos.Builder)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphTransform _tr = (PF.GraphTransform)translator.GetObject(L, 2, typeof(PF.GraphTransform));
                    UnityEngine.Bounds _bounds;translator.Get(L, 3, out _bounds);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    
                    gen_to_be_invoked.DrawWireCube( 
                        _tr, 
                        _bounds, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawLine(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos.Builder gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos.Builder)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 2, out _start);
                    UnityEngine.Vector3 _end;translator.Get(L, 3, out _end);
                    UnityEngine.Color _color;translator.Get(L, 4, out _color);
                    
                    gen_to_be_invoked.DrawLine( 
                        _start, 
                        _end, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Submit(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.RetainedGizmos.Builder gen_to_be_invoked = (Pathfinding.Util.RetainedGizmos.Builder)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Util.RetainedGizmos _gizmos = (Pathfinding.Util.RetainedGizmos)translator.GetObject(L, 2, typeof(Pathfinding.Util.RetainedGizmos));
                    Pathfinding.Util.RetainedGizmos.Hasher _hasher;translator.Get(L, 3, out _hasher);
                    
                    gen_to_be_invoked.Submit( 
                        _gizmos, 
                        _hasher );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
