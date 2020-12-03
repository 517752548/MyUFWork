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
    public class PathfindingAdvancedSmoothMaxTurnWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AdvancedSmooth.MaxTurn);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnTangentUpdate", _m_OnTangentUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Prepare", _m_Prepare);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TangentToTangent", _m_TangentToTangent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PointToTangent", _m_PointToTangent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TangentToPoint", _m_TangentToPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPath", _m_GetPath);
						
            
			
						
			
			
			
			
			
			
			
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
					
					Pathfinding.AdvancedSmooth.MaxTurn gen_ret = new Pathfinding.AdvancedSmooth.MaxTurn();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AdvancedSmooth.MaxTurn constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTangentUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.MaxTurn gen_to_be_invoked = (Pathfinding.AdvancedSmooth.MaxTurn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnTangentUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Prepare(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.MaxTurn gen_to_be_invoked = (Pathfinding.AdvancedSmooth.MaxTurn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.Vector3[] _vectorPath = (UnityEngine.Vector3[])translator.GetObject(L, 3, typeof(UnityEngine.Vector3[]));
                    
                    gen_to_be_invoked.Prepare( 
                        _i, 
                        _vectorPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TangentToTangent(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.MaxTurn gen_to_be_invoked = (Pathfinding.AdvancedSmooth.MaxTurn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn> _turnList = (System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>));
                    
                    gen_to_be_invoked.TangentToTangent( 
                        _turnList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PointToTangent(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.MaxTurn gen_to_be_invoked = (Pathfinding.AdvancedSmooth.MaxTurn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn> _turnList = (System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>));
                    
                    gen_to_be_invoked.PointToTangent( 
                        _turnList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TangentToPoint(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.MaxTurn gen_to_be_invoked = (Pathfinding.AdvancedSmooth.MaxTurn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn> _turnList = (System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.AdvancedSmooth.Turn>));
                    
                    gen_to_be_invoked.TangentToPoint( 
                        _turnList );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.MaxTurn gen_to_be_invoked = (Pathfinding.AdvancedSmooth.MaxTurn)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.AdvancedSmooth.Turn _turn;translator.Get(L, 2, out _turn);
                    System.Collections.Generic.List<UnityEngine.Vector3> _output = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                    gen_to_be_invoked.GetPath( 
                        _turn, 
                        _output );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
