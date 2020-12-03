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
    public class FairyGUIUtilsXMLWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.Utils.XML);
			Utils.BeginObjectRegister(type, L, translator, 0, 14, 2, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasAttribute", _m_HasAttribute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttribute", _m_GetAttribute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttributeInt", _m_GetAttributeInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttributeFloat", _m_GetAttributeFloat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttributeBool", _m_GetAttributeBool);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttributeArray", _m_GetAttributeArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttributeColor", _m_GetAttributeColor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttributeVector", _m_GetAttributeVector);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAttribute", _m_SetAttribute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNode", _m_GetNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Elements", _m_Elements);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEnumerator", _m_GetEnumerator);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getname", _g_get_name);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettext", _g_get_text);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "name", _g_get_name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "text", _g_get_text);
            
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string _text = LuaAPI.lua_tostring(L, 2);
					
					FairyGUI.Utils.XML gen_ret = new FairyGUI.Utils.XML(_text);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasAttribute(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.HasAttribute( 
                        _attrName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttribute(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.GetAttribute( 
                        _attrName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    string _defValue = LuaAPI.lua_tostring(L, 3);
                    
                        string gen_ret = gen_to_be_invoked.GetAttribute( 
                        _attrName, 
                        _defValue );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML.GetAttribute!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttributeInt(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.GetAttributeInt( 
                        _attrName );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    int _defValue = LuaAPI.xlua_tointeger(L, 3);
                    
                        int gen_ret = gen_to_be_invoked.GetAttributeInt( 
                        _attrName, 
                        _defValue );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML.GetAttributeInt!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttributeFloat(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    
                        float gen_ret = gen_to_be_invoked.GetAttributeFloat( 
                        _attrName );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    float _defValue = (float)LuaAPI.lua_tonumber(L, 3);
                    
                        float gen_ret = gen_to_be_invoked.GetAttributeFloat( 
                        _attrName, 
                        _defValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML.GetAttributeFloat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttributeBool(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.GetAttributeBool( 
                        _attrName );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    bool _defValue = LuaAPI.lua_toboolean(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.GetAttributeBool( 
                        _attrName, 
                        _defValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML.GetAttributeBool!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttributeArray(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    
                        string[] gen_ret = gen_to_be_invoked.GetAttributeArray( 
                        _attrName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    char _seperator = (char)LuaAPI.xlua_tointeger(L, 3);
                    
                        string[] gen_ret = gen_to_be_invoked.GetAttributeArray( 
                        _attrName, 
                        _seperator );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML.GetAttributeArray!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttributeColor(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Color _defValue;translator.Get(L, 3, out _defValue);
                    
                        UnityEngine.Color gen_ret = gen_to_be_invoked.GetAttributeColor( 
                        _attrName, 
                        _defValue );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttributeVector(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.Vector2 gen_ret = gen_to_be_invoked.GetAttributeVector( 
                        _attrName );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAttribute(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _attrName = LuaAPI.lua_tostring(L, 2);
                    string _attrValue = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.SetAttribute( 
                        _attrName, 
                        _attrValue );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _selector = LuaAPI.lua_tostring(L, 2);
                    
                        FairyGUI.Utils.XML gen_ret = gen_to_be_invoked.GetNode( 
                        _selector );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Elements(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        FairyGUI.Utils.XMLList gen_ret = gen_to_be_invoked.Elements(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _selector = LuaAPI.lua_tostring(L, 2);
                    
                        FairyGUI.Utils.XMLList gen_ret = gen_to_be_invoked.Elements( 
                        _selector );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML.Elements!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEnumerator(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        FairyGUI.Utils.XMLList.Enumerator gen_ret = gen_to_be_invoked.GetEnumerator(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _selector = LuaAPI.lua_tostring(L, 2);
                    
                        FairyGUI.Utils.XMLList.Enumerator gen_ret = gen_to_be_invoked.GetEnumerator( 
                        _selector );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.Utils.XML.GetEnumerator!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.Utils.XML gen_to_be_invoked = (FairyGUI.Utils.XML)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.text);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
