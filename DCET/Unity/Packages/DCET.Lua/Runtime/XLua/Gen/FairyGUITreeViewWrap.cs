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
    public class FairyGUITreeViewWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.TreeView);
			Utils.BeginObjectRegister(type, L, translator, 0, 22, 8, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSelectedNode", _m_GetSelectedNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSelection", _m_GetSelection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSelection", _m_AddSelection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveSelection", _m_RemoveSelection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearSelection", _m_ClearSelection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNodeIndex", _m_GetNodeIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateNode", _m_UpdateNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateNodes", _m_UpdateNodes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExpandAll", _m_ExpandAll);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CollapseAll", _m_CollapseAll);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlist", _g_get_list);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getroot", _g_get_root);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonClickNode", _g_get_onClickNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getonRightClickNode", _g_get_onRightClickNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getindent", _g_get_indent);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettreeNodeCreateCell", _g_get_treeNodeCreateCell);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettreeNodeRender", _g_get_treeNodeRender);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettreeNodeWillExpand", _g_get_treeNodeWillExpand);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setindent", _s_set_indent);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settreeNodeCreateCell", _s_set_treeNodeCreateCell);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settreeNodeRender", _s_set_treeNodeRender);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settreeNodeWillExpand", _s_set_treeNodeWillExpand);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "list", _g_get_list);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "root", _g_get_root);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onClickNode", _g_get_onClickNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onRightClickNode", _g_get_onRightClickNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "indent", _g_get_indent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "treeNodeCreateCell", _g_get_treeNodeCreateCell);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "treeNodeRender", _g_get_treeNodeRender);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "treeNodeWillExpand", _g_get_treeNodeWillExpand);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "indent", _s_set_indent);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "treeNodeCreateCell", _s_set_treeNodeCreateCell);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "treeNodeRender", _s_set_treeNodeRender);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "treeNodeWillExpand", _s_set_treeNodeWillExpand);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<FairyGUI.GList>(L, 2))
				{
					FairyGUI.GList _list = (FairyGUI.GList)translator.GetObject(L, 2, typeof(FairyGUI.GList));
					
					FairyGUI.TreeView gen_ret = new FairyGUI.TreeView(_list);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.TreeView constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSelectedNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        FairyGUI.TreeNode gen_ret = gen_to_be_invoked.GetSelectedNode(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSelection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        System.Collections.Generic.List<FairyGUI.TreeNode> gen_ret = gen_to_be_invoked.GetSelection(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSelection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<FairyGUI.TreeNode>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    FairyGUI.TreeNode _node = (FairyGUI.TreeNode)translator.GetObject(L, 2, typeof(FairyGUI.TreeNode));
                    bool _scrollItToView = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.AddSelection( 
                        _node, 
                        _scrollItToView );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<FairyGUI.TreeNode>(L, 2)) 
                {
                    FairyGUI.TreeNode _node = (FairyGUI.TreeNode)translator.GetObject(L, 2, typeof(FairyGUI.TreeNode));
                    
                    gen_to_be_invoked.AddSelection( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.TreeView.AddSelection!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSelection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.TreeNode _node = (FairyGUI.TreeNode)translator.GetObject(L, 2, typeof(FairyGUI.TreeNode));
                    
                    gen_to_be_invoked.RemoveSelection( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearSelection(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearSelection(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNodeIndex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.TreeNode _node = (FairyGUI.TreeNode)translator.GetObject(L, 2, typeof(FairyGUI.TreeNode));
                    
                        int gen_ret = gen_to_be_invoked.GetNodeIndex( 
                        _node );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.TreeNode _node = (FairyGUI.TreeNode)translator.GetObject(L, 2, typeof(FairyGUI.TreeNode));
                    
                    gen_to_be_invoked.UpdateNode( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateNodes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<FairyGUI.TreeNode> _nodes = (System.Collections.Generic.List<FairyGUI.TreeNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<FairyGUI.TreeNode>));
                    
                    gen_to_be_invoked.UpdateNodes( 
                        _nodes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExpandAll(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.TreeNode _folderNode = (FairyGUI.TreeNode)translator.GetObject(L, 2, typeof(FairyGUI.TreeNode));
                    
                    gen_to_be_invoked.ExpandAll( 
                        _folderNode );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CollapseAll(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.TreeNode _folderNode = (FairyGUI.TreeNode)translator.GetObject(L, 2, typeof(FairyGUI.TreeNode));
                    
                    gen_to_be_invoked.CollapseAll( 
                        _folderNode );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_list(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.list);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_root(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.root);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onClickNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onClickNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onRightClickNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onRightClickNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_indent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.indent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_treeNodeCreateCell(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.treeNodeCreateCell);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_treeNodeRender(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.treeNodeRender);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_treeNodeWillExpand(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.treeNodeWillExpand);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_indent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.indent = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_treeNodeCreateCell(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.treeNodeCreateCell = translator.GetDelegate<FairyGUI.TreeView.TreeNodeCreateCellDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_treeNodeRender(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.treeNodeRender = translator.GetDelegate<FairyGUI.TreeView.TreeNodeRenderDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_treeNodeWillExpand(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.TreeView gen_to_be_invoked = (FairyGUI.TreeView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.treeNodeWillExpand = translator.GetDelegate<FairyGUI.TreeView.TreeNodeWillExpandDelegate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
