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
    public class PathfindingAdvancedSmoothTurnWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AdvancedSmooth.Turn);
			Utils.BeginObjectRegister(type, L, translator, 1, 10, 4, 3);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__lt", __LTMeta);
            
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPath", _m_GetPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CompareTo", _m_CompareTo);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getscore", _g_get_score);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlength", _g_get_length);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getid", _g_get_id);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getconstructor", _g_get_constructor);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlength", _s_set_length);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setid", _s_set_id);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setconstructor", _s_set_constructor);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "score", _g_get_score);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "length", _g_get_length);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "id", _g_get_id);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "constructor", _g_get_constructor);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "length", _s_set_length);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "id", _s_set_id);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "constructor", _s_set_constructor);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "op_LessThan",__LTMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_GreaterThan", _m_op_GreaterThan);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int __clone__(RealStatePtr L)
		{
			try
			{
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
				translator.Push(L, gen_to_be_invoked);
				return 1;
			}
			catch (System.Exception e)
			{
				return LuaAPI.luaL_error(L, "c# exception in StructClone:" + e);
			}
		}
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<Pathfinding.AdvancedSmooth.TurnConstructor>(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					float _length = (float)LuaAPI.lua_tonumber(L, 2);
					Pathfinding.AdvancedSmooth.TurnConstructor _constructor = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.GetObject(L, 3, typeof(Pathfinding.AdvancedSmooth.TurnConstructor));
					int _id = LuaAPI.xlua_tointeger(L, 4);
					
					Pathfinding.AdvancedSmooth.Turn gen_ret = new Pathfinding.AdvancedSmooth.Turn(_length, _constructor, _id);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && translator.Assignable<Pathfinding.AdvancedSmooth.TurnConstructor>(L, 3))
				{
					float _length = (float)LuaAPI.lua_tonumber(L, 2);
					Pathfinding.AdvancedSmooth.TurnConstructor _constructor = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.GetObject(L, 3, typeof(Pathfinding.AdvancedSmooth.TurnConstructor));
					
					Pathfinding.AdvancedSmooth.Turn gen_ret = new Pathfinding.AdvancedSmooth.Turn(_length, _constructor);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(Pathfinding.AdvancedSmooth.Turn));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AdvancedSmooth.Turn constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __LTMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Pathfinding.AdvancedSmooth.Turn>(L, 1) && translator.Assignable<Pathfinding.AdvancedSmooth.Turn>(L, 2))
				{
					Pathfinding.AdvancedSmooth.Turn leftside;translator.Get(L, 1, out leftside);
					Pathfinding.AdvancedSmooth.Turn rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside < rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of < operator, need Pathfinding.AdvancedSmooth.Turn!");
            
        }
        

		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_op_GreaterThan(RealStatePtr L)
        {					
			
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<Pathfinding.AdvancedSmooth.Turn>(L, 1) && translator.Assignable<Pathfinding.AdvancedSmooth.Turn>(L, 2))
				{
					Pathfinding.AdvancedSmooth.Turn leftside;translator.Get(L, 1, out leftside);
					Pathfinding.AdvancedSmooth.Turn rightside;translator.Get(L, 2, out rightside);

					LuaAPI.lua_pushboolean(L, leftside > rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of > operator, need Pathfinding.AdvancedSmooth.Turn!");
            
        }
        
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    System.Collections.Generic.List<UnityEngine.Vector3> _output = (System.Collections.Generic.List<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>));
                    
                    gen_to_be_invoked.GetPath( 
                        _output );
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompareTo(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    Pathfinding.AdvancedSmooth.Turn _t;translator.Get(L, 2, out _t);
                    
                        int gen_ret = gen_to_be_invoked.CompareTo( 
                        _t );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_score(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.score);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_length(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.length);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_constructor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.constructor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_length(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.length = (float)LuaAPI.lua_tonumber(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.id = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_constructor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AdvancedSmooth.Turn gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.constructor = (Pathfinding.AdvancedSmooth.TurnConstructor)translator.GetObject(L, 2, typeof(Pathfinding.AdvancedSmooth.TurnConstructor));
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
