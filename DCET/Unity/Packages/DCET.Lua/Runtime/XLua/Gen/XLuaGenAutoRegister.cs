#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
        
        
        static void wrapInit0(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(object), SystemObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Object), UnityEngineObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector2), UnityEngineVector2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector3), UnityEngineVector3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Vector4), UnityEngineVector4Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Quaternion), UnityEngineQuaternionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Color), UnityEngineColorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray), UnityEngineRayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Bounds), UnityEngineBoundsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Ray2D), UnityEngineRay2DWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Time), UnityEngineTimeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.GameObject), UnityEngineGameObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Component), UnityEngineComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Behaviour), UnityEngineBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Transform), UnityEngineTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Resources), UnityEngineResourcesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.TextAsset), UnityEngineTextAssetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Keyframe), UnityEngineKeyframeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationCurve), UnityEngineAnimationCurveWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimationClip), UnityEngineAnimationClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.MonoBehaviour), UnityEngineMonoBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.ParticleSystem), UnityEngineParticleSystemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SkinnedMeshRenderer), UnityEngineSkinnedMeshRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Renderer), UnityEngineRendererWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Light), UnityEngineLightWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Mathf), UnityEngineMathfWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<int>), SystemCollectionsGenericList_1_SystemInt32_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Debug), UnityEngineDebugWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RaycastHit), UnityEngineRaycastHitWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Input), UnityEngineInputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Physics), UnityEnginePhysicsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Camera), UnityEngineCameraWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.Animator), UnityEngineAnimatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<string>), SystemCollectionsGenericList_1_SystemString_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.SceneManagement.SceneManager), UnityEngineSceneManagementSceneManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Type), SystemTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.RuntimeAnimatorController), UnityEngineRuntimeAnimatorControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AnimatorControllerParameter), UnityEngineAnimatorControllerParameterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.Socket), SystemNetSocketsSocketWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.IPEndPoint), SystemNetIPEndPointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.EndPoint), SystemNetEndPointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.IPAddress), SystemNetIPAddressWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.AddressFamily), SystemNetSocketsAddressFamilyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.SocketType), SystemNetSocketsSocketTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.ProtocolType), SystemNetSocketsProtocolTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Net.Sockets.SocketAsyncEventArgs), SystemNetSocketsSocketAsyncEventArgsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.SerializableAttribute), SystemSerializableAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.Path), SystemIOPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AssetBundleManifest), UnityEngineAssetBundleManifestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<BehaviorDesigner.Runtime.Tasks.HotfixAction>), SystemCollectionsGenericList_1_BehaviorDesignerRuntimeTasksHotfixAction_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<BehaviorDesigner.Runtime.Tasks.HotfixComposite>), SystemCollectionsGenericList_1_BehaviorDesignerRuntimeTasksHotfixComposite_Wrap.__Register);
        
        }
        
        static void wrapInit1(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<BehaviorDesigner.Runtime.Tasks.HotfixConditional>), SystemCollectionsGenericList_1_BehaviorDesignerRuntimeTasksHotfixConditional_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Collections.Generic.List<BehaviorDesigner.Runtime.Tasks.HotfixDecorator>), SystemCollectionsGenericList_1_BehaviorDesignerRuntimeTasksHotfixDecorator_Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.IOException), SystemIOIOExceptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoMemberAttribute), ProtoBufProtoMemberAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoContractAttribute), ProtoBufProtoContractAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Text.Encoding), SystemTextEncodingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.Stream), SystemIOStreamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.IO.MemoryStream), SystemIOMemoryStreamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreAttribute), MongoDBBsonSerializationAttributesBsonIgnoreAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElementsAttribute), MongoDBBsonSerializationAttributesBsonIgnoreExtraElementsAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreIfDefaultAttribute), MongoDBBsonSerializationAttributesBsonIgnoreIfDefaultAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonDefaultValueAttribute), MongoDBBsonSerializationAttributesBsonDefaultValueAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonElementAttribute), MongoDBBsonSerializationAttributesBsonElementAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIdAttribute), MongoDBBsonSerializationAttributesBsonIdAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(MongoDB.Bson.Serialization.Attributes.BsonIgnoreIfNullAttribute), MongoDBBsonSerializationAttributesBsonIgnoreIfNullAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoConverterAttribute), ProtoBufProtoConverterAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoEnumAttribute), ProtoBufProtoEnumAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoIgnoreAttribute), ProtoBufProtoIgnoreAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoIncludeAttribute), ProtoBufProtoIncludeAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoPartialIgnoreAttribute), ProtoBufProtoPartialIgnoreAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(ProtoBuf.ProtoPartialMemberAttribute), ProtoBufProtoPartialMemberAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(UnityEngine.AsyncOperation), UnityEngineAsyncOperationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(System.Convert), SystemConvertWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.BundleDownloader), DCETRuntimeBundleDownloaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.GlobalConfigComponent), DCETRuntimeGlobalConfigComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.GlobalProto), DCETRuntimeGlobalProtoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.FileVersionInfo), DCETRuntimeFileVersionInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.VersionConfig), DCETRuntimeVersionConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.Kcp), DCETRuntimeKcpWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.BehaviorTree), BehaviorDesignerRuntimeBehaviorTreeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.BehaviorTreeController), BehaviorDesignerRuntimeBehaviorTreeControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.ExternalBehaviorTree), BehaviorDesignerRuntimeExternalBehaviorTreeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.HotfixAction), BehaviorDesignerRuntimeTasksHotfixActionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.EntryTask), BehaviorDesignerRuntimeTasksEntryTaskWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.HotfixComposite), BehaviorDesignerRuntimeTasksHotfixCompositeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.Parallel), BehaviorDesignerRuntimeTasksParallelWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.ParallelComplete), BehaviorDesignerRuntimeTasksParallelCompleteWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.ParallelSelector), BehaviorDesignerRuntimeTasksParallelSelectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.PrioritySelector), BehaviorDesignerRuntimeTasksPrioritySelectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.RandomSelector), BehaviorDesignerRuntimeTasksRandomSelectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.RandomSequence), BehaviorDesignerRuntimeTasksRandomSequenceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.Selector), BehaviorDesignerRuntimeTasksSelectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.SelectorEvaluator), BehaviorDesignerRuntimeTasksSelectorEvaluatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.Sequence), BehaviorDesignerRuntimeTasksSequenceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.UtilitySelector), BehaviorDesignerRuntimeTasksUtilitySelectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.HotfixConditional), BehaviorDesignerRuntimeTasksHotfixConditionalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator), BehaviorDesignerRuntimeTasksConditionalEvaluatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.HotfixDecorator), BehaviorDesignerRuntimeTasksHotfixDecoratorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.Interrupt), BehaviorDesignerRuntimeTasksInterruptWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.Inverter), BehaviorDesignerRuntimeTasksInverterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.Repeater), BehaviorDesignerRuntimeTasksRepeaterWrap.__Register);
        
        }
        
        static void wrapInit2(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.ReturnFailure), BehaviorDesignerRuntimeTasksReturnFailureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.ReturnSuccess), BehaviorDesignerRuntimeTasksReturnSuccessWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.TaskGuard), BehaviorDesignerRuntimeTasksTaskGuardWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.UntilFailure), BehaviorDesignerRuntimeTasksUntilFailureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(BehaviorDesigner.Runtime.Tasks.UntilSuccess), BehaviorDesignerRuntimeTasksUntilSuccessWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.FUIPackage), DCETRuntimeFUIPackageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(AstarPath), AstarPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.AStarConfig), PFAStarConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ListExtensions), PFListExtensionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Checksum), PFChecksumWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.AstarDeserializer), PFAstarDeserializerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.VectorMath), PFVectorMathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.AstarMath), PFAstarMathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Polygon), PFPolygonWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Memory), PFMemoryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.BBTree), PFBBTreeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.BinaryHeap), PFBinaryHeapWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.HeuristicOptimizationMode), PFHeuristicOptimizationModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.EuclideanEmbedding), PFEuclideanEmbeddingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Funnel), PFFunnelWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Connection), PFConnectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.GraphNode), PFGraphNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.MeshNode), PFMeshNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.IMovementPlane), PFIMovementPlaneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ITransform), PFITransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.GraphTransform), PFGraphTransformWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Guid), PFGuidWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.INavmesh), PFINavmeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Int3), PFInt3Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Int2), PFInt2Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.IntRect), PFIntRectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.NNConstraint), PFNNConstraintWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathNNConstraint), PFPathNNConstraintWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.NNInfoInternal), PFNNInfoInternalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.NNInfo), PFNNInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.IGraphInternals), PFIGraphInternalsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.NavGraph), PFNavGraphWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.GraphHitInfo), PFGraphHitInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.IRaycastableGraph), PFIRaycastableGraphWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ITransformedGraph), PFITransformedGraphWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.NavmeshBase), PFNavmeshBaseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.NavmeshTile), PFNavmeshTileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.IAstarPooledObject), PFIAstarPooledObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.GraphUpdateThreading), PFGraphUpdateThreadingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ThreadCount), PFThreadCountWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathState), PFPathStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathCompleteState), PFPathCompleteStateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.CloseToDestinationMode), PFCloseToDestinationModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Side), PFSideWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.InspectorGridMode), PFInspectorGridModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ITraversalProvider), PFITraversalProviderWrap.__Register);
        
        }
        
        static void wrapInit3(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(PF.DefaultITraversalProvider), PFDefaultITraversalProviderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Path), PFPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.GraphDebugMode), PFGraphDebugModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathLog), PFPathLogWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Heuristic), PFHeuristicWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathFindHelper), PFPathFindHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathNode), PFPathNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathHandler), PFPathHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathPool), PFPathPoolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathProcessor), PFPathProcessorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathReturnQueue), PFPathReturnQueueWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ABPath), PFABPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ConstantPath), PFConstantPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.EndingConditionDistance), PFEndingConditionDistanceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.FleePath), PFFleePathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.FloodPath), PFFloodPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.FloodPathConstraint), PFFloodPathConstraintWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.FloodPathTracer), PFFloodPathTracerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.MultiTargetPath), PFMultiTargetPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.RandomPath), PFRandomPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.XPath), PFXPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathEndingCondition), PFPathEndingConditionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.ABPathEndingCondition), PFABPathEndingConditionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.EndingConditionProximity), PFEndingConditionProximityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.RecastGraph), PFRecastGraphWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.GraphSerializationContext), PFGraphSerializationContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.AstarSerializer), PFAstarSerializerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.GraphMeta), PFGraphMetaWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.SerializeSettings), PFSerializeSettingsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.JsonMemberAttribute), PFJsonMemberAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.JsonOptInAttribute), PFJsonOptInAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.TinyJsonSerializer), PFTinyJsonSerializerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.TinyJsonDeserializer), PFTinyJsonDeserializerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.INavmeshHolder), PFINavmeshHolderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.TriangleMeshNode), PFTriangleMeshNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.WindowsStoreCompatibility), PFWindowsStoreCompatibilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AIDestinationSetter), PathfindingAIDestinationSetterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Patrol), PathfindingPatrolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AIBase), PathfindingAIBaseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AILerp), PathfindingAILerpWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AIPath), PathfindingAIPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.IAstarAI), PathfindingIAstarAIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Seeker), PathfindingSeekerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AstarData), PathfindingAstarDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphUpdateScene), PathfindingGraphUpdateSceneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphUpdateShape), PathfindingGraphUpdateShapeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AstarDebugger), PathfindingAstarDebuggerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphEditorBase), PathfindingGraphEditorBaseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphModifier), PathfindingGraphModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphUtilities), PathfindingGraphUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.NodeLink), PathfindingNodeLinkWrap.__Register);
        
        }
        
        static void wrapInit4(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(Pathfinding.AstarWorkItem), PathfindingAstarWorkItemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.IWorkItemContext), PathfindingIWorkItemContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AstarColor), PathfindingAstarColorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Progress), PathfindingProgressWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphUpdateObject), PathfindingGraphUpdateObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RecastTileUpdate), PathfindingRecastTileUpdateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RecastTileUpdateHandler), PathfindingRecastTileUpdateHandlerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.TargetMover), PathfindingTargetMoverWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.ObjImporter), PathfindingObjImporterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RecastBBTree), PathfindingRecastBBTreeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RecastBBTreeBox), PathfindingRecastBBTreeBoxWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RecastMeshObj), PathfindingRecastMeshObjWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.MathHelper), PathfindingMathHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AdvancedSmooth), PathfindingAdvancedSmoothWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AlternativePath), PathfindingAlternativePathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.FunnelModifier), PathfindingFunnelModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.IPathModifier), PathfindingIPathModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.PathModifier), PathfindingPathModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.MonoModifier), PathfindingMonoModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RadiusModifier), PathfindingRadiusModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RaycastModifier), PathfindingRaycastModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.SimpleSmoothModifier), PathfindingSimpleSmoothModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.StartEndModifier), PathfindingStartEndModifierWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RelevantGraphSurface), PathfindingRelevantGraphSurfaceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.EnumFlagAttribute), PathfindingEnumFlagAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.UniqueComponentAttribute), PathfindingUniqueComponentAttributeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.IVersionedMonoBehaviourInternal), PathfindingIVersionedMonoBehaviourInternalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.VersionedMonoBehaviour), PathfindingVersionedMonoBehaviourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.BlockManager), PathfindingBlockManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.SingleNodeBlocker), PathfindingSingleNodeBlockerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.UnityHelper), PathfindingUnityHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AstarProfiler), PathfindingAstarProfilerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphUpdateUtilities), PathfindingGraphUpdateUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.PathUtilities), PathfindingPathUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Profile), PathfindingProfileWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.UnityReferenceHelper), PathfindingUnityReferenceHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.VoxelArea), PathfindingVoxelsVoxelAreaWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.LinkedVoxelSpan), PathfindingVoxelsLinkedVoxelSpanWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.RasterizationMesh), PathfindingVoxelsRasterizationMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.VoxelContourSet), PathfindingVoxelsVoxelContourSetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.VoxelContour), PathfindingVoxelsVoxelContourWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.VoxelMesh), PathfindingVoxelsVoxelMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.VoxelCell), PathfindingVoxelsVoxelCellWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.CompactVoxelCell), PathfindingVoxelsCompactVoxelCellWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.CompactVoxelSpan), PathfindingVoxelsCompactVoxelSpanWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.VoxelSpan), PathfindingVoxelsVoxelSpanWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.Voxelize), PathfindingVoxelsVoxelizeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Voxels.Utility), PathfindingVoxelsUtilityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.ObstacleVertex), PathfindingRVOObstacleVertexWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.IAgent), PathfindingRVOIAgentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.MovementPlane), PathfindingRVOMovementPlaneWrap.__Register);
        
        }
        
        static void wrapInit5(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVOLayer), PathfindingRVORVOLayerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.Simulator), PathfindingRVOSimulatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.Line), PathfindingRVOLineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVOQuadtree), PathfindingRVORVOQuadtreeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVOController), PathfindingRVORVOControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVONavmesh), PathfindingRVORVONavmeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVOObstacle), PathfindingRVORVOObstacleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVOSimulator), PathfindingRVORVOSimulatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVOSquareObstacle), PathfindingRVORVOSquareObstacleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.Sampled.Agent), PathfindingRVOSampledAgentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Util.Draw), PathfindingUtilDrawWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Util.MovementUtilities), PathfindingUtilMovementUtilitiesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Util.PathInterpolator), PathfindingUtilPathInterpolatorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Util.GraphGizmoHelper), PathfindingUtilGraphGizmoHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Util.RetainedGizmos), PathfindingUtilRetainedGizmosWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Examples.TurnBasedAI), PathfindingExamplesTurnBasedAIWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Examples.MecanimBridge), PathfindingExamplesMecanimBridgeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Examples.MineBotAnimation), PathfindingExamplesMineBotAnimationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(AstarPath.AstarDistribution), AstarPathAstarDistributionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Funnel.FunnelPortals), PFFunnelFunnelPortalsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.Funnel.PathPart), PFFunnelPathPartWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.PathProcessor.GraphUpdateLock), PFPathProcessorGraphUpdateLockWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.MultiTargetPath.HeuristicMode), PFMultiTargetPathHeuristicModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(PF.RecastGraph.RelevantGraphSurfaceMode), PFRecastGraphRelevantGraphSurfaceModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Seeker.ModifierPass), PathfindingSeekerModifierPassWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.GraphModifier.EventType), PathfindingGraphModifierEventTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AdvancedSmooth.MaxTurn), PathfindingAdvancedSmoothMaxTurnWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AdvancedSmooth.ConstantTurn), PathfindingAdvancedSmoothConstantTurnWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AdvancedSmooth.TurnConstructor), PathfindingAdvancedSmoothTurnConstructorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AdvancedSmooth.Turn), PathfindingAdvancedSmoothTurnWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RaycastModifier.Quality), PathfindingRaycastModifierQualityWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.SimpleSmoothModifier.SmoothType), PathfindingSimpleSmoothModifierSmoothTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.StartEndModifier.Exactness), PathfindingStartEndModifierExactnessWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.BlockManager.BlockMode), PathfindingBlockManagerBlockModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.BlockManager.TraversalProvider), PathfindingBlockManagerTraversalProviderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.AstarProfiler.ProfilePoint), PathfindingAstarProfilerProfilePointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.RVO.RVOObstacle.ObstacleVertexWinding), PathfindingRVORVOObstacleObstacleVertexWindingWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Util.RetainedGizmos.Hasher), PathfindingUtilRetainedGizmosHasherWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Pathfinding.Util.RetainedGizmos.Builder), PathfindingUtilRetainedGizmosBuilderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.BlendMode), FairyGUIBlendModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.BlendModeUtils), FairyGUIBlendModeUtilsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.CaptureCamera), FairyGUICaptureCameraWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Container), FairyGUIContainerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.DisplayObject), FairyGUIDisplayObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.DisplayObjectInfo), FairyGUIDisplayObjectInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.DisplayOptions), FairyGUIDisplayOptionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GoWrapper), FairyGUIGoWrapperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ColliderHitTest), FairyGUIColliderHitTestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.HitTestContext), FairyGUIHitTestContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.HitTestMode), FairyGUIHitTestModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IHitTest), FairyGUIIHitTestWrap.__Register);
        
        }
        
        static void wrapInit6(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(FairyGUI.MeshColliderHitTest), FairyGUIMeshColliderHitTestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PixelHitTestData), FairyGUIPixelHitTestDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PixelHitTest), FairyGUIPixelHitTestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RectHitTest), FairyGUIRectHitTestWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Image), FairyGUIImageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.MaterialManager), FairyGUIMaterialManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.CompositeMesh), FairyGUICompositeMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.EllipseMesh), FairyGUIEllipseMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.FillMesh), FairyGUIFillMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.LineMesh), FairyGUILineMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IMeshFactory), FairyGUIIMeshFactoryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PolygonMesh), FairyGUIPolygonMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RectMesh), FairyGUIRectMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RegularPolygonMesh), FairyGUIRegularPolygonMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RoundedRectMesh), FairyGUIRoundedRectMeshWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.VertexBuffer), FairyGUIVertexBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.MovieClip), FairyGUIMovieClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.NAudioClip), FairyGUINAudioClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.NGraphics), FairyGUINGraphicsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.NMaterial), FairyGUINMaterialWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.DestroyMethod), FairyGUIDestroyMethodWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.NTexture), FairyGUINTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ShaderConfig), FairyGUIShaderConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Shape), FairyGUIShapeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Stage), FairyGUIStageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.StageCamera), FairyGUIStageCameraWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.StageEngine), FairyGUIStageEngineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Stats), FairyGUIStatsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.BaseFont), FairyGUIBaseFontWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GlyphInfo), FairyGUIGlyphInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.BitmapFont), FairyGUIBitmapFontWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.CopyPastePatch), FairyGUICopyPastePatchWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.DynamicFont), FairyGUIDynamicFontWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Emoji), FairyGUIEmojiWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.FontManager), FairyGUIFontManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IKeyboard), FairyGUIIKeyboardWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.InputTextField), FairyGUIInputTextFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RTLSupport), FairyGUIRTLSupportWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RichTextField), FairyGUIRichTextFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.SelectionShape), FairyGUISelectionShapeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TextField), FairyGUITextFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TextFormat), FairyGUITextFormatWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TouchScreenKeyboard), FairyGUITouchScreenKeyboardWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TypingEffect), FairyGUITypingEffectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UpdateContext), FairyGUIUpdateContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.EventContext), FairyGUIEventContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.EventDispatcher), FairyGUIEventDispatcherWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.EventListener), FairyGUIEventListenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IEventDispatcher), FairyGUIIEventDispatcherWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.InputEvent), FairyGUIInputEventWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.BlurFilter), FairyGUIBlurFilterWrap.__Register);
        
        }
        
        static void wrapInit7(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(FairyGUI.ColorFilter), FairyGUIColorFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IFilter), FairyGUIIFilterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.LongPressGesture), FairyGUILongPressGestureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PinchGesture), FairyGUIPinchGestureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RotationGesture), FairyGUIRotationGestureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.SwipeGesture), FairyGUISwipeGestureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.EaseType), FairyGUIEaseTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GPathPoint), FairyGUIGPathPointWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GPath), FairyGUIGPathWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GTween), FairyGUIGTweenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ITweenListener), FairyGUIITweenListenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GTweener), FairyGUIGTweenerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TweenPropType), FairyGUITweenPropTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TweenValue), FairyGUITweenValueWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ChangePageAction), FairyGUIChangePageActionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ControllerAction), FairyGUIControllerActionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PlayTransitionAction), FairyGUIPlayTransitionActionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.AsyncCreationHelper), FairyGUIAsyncCreationHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Controller), FairyGUIControllerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.DragDropManager), FairyGUIDragDropManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.EMRenderTarget), FairyGUIEMRenderTargetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.EMRenderSupport), FairyGUIEMRenderSupportWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PackageItemType), FairyGUIPackageItemTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ObjectType), FairyGUIObjectTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.AlignType), FairyGUIAlignTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.VertAlignType), FairyGUIVertAlignTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.OverflowType), FairyGUIOverflowTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.FillType), FairyGUIFillTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.AutoSizeType), FairyGUIAutoSizeTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ScrollType), FairyGUIScrollTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ScrollBarDisplayType), FairyGUIScrollBarDisplayTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RelationType), FairyGUIRelationTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ListLayoutType), FairyGUIListLayoutTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ListSelectionMode), FairyGUIListSelectionModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ProgressTitleType), FairyGUIProgressTitleTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ButtonMode), FairyGUIButtonModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TransitionActionType), FairyGUITransitionActionTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GroupLayoutType), FairyGUIGroupLayoutTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ChildrenRenderOrder), FairyGUIChildrenRenderOrderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PopupDirection), FairyGUIPopupDirectionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.FlipType), FairyGUIFlipTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.FillMethod), FairyGUIFillMethodWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.OriginHorizontal), FairyGUIOriginHorizontalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.OriginVertical), FairyGUIOriginVerticalWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Origin90), FairyGUIOrigin90Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Origin180), FairyGUIOrigin180Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Origin360), FairyGUIOrigin360Wrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GButton), FairyGUIGButtonWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GComboBox), FairyGUIGComboBoxWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GComponent), FairyGUIGComponentWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GGraph), FairyGUIGGraphWrap.__Register);
        
        }
        
        static void wrapInit8(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(FairyGUI.GGroup), FairyGUIGGroupWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GImage), FairyGUIGImageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GLabel), FairyGUIGLabelWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GList), FairyGUIGListWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GLoader), FairyGUIGLoaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GMovieClip), FairyGUIGMovieClipWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GObject), FairyGUIGObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GObjectPool), FairyGUIGObjectPoolWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GProgressBar), FairyGUIGProgressBarWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GRichTextField), FairyGUIGRichTextFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GRoot), FairyGUIGRootWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GScrollBar), FairyGUIGScrollBarWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GSlider), FairyGUIGSliderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GTextField), FairyGUIGTextFieldWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GTextInput), FairyGUIGTextInputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearAnimation), FairyGUIGearAnimationWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearBase), FairyGUIGearBaseWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearTweenConfig), FairyGUIGearTweenConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearColor), FairyGUIGearColorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearDisplay), FairyGUIGearDisplayWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearIcon), FairyGUIGearIconWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearLook), FairyGUIGearLookWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearSize), FairyGUIGearSizeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearText), FairyGUIGearTextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GearXY), FairyGUIGearXYWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IAnimationGear), FairyGUIIAnimationGearWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IColorGear), FairyGUIIColorGearWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ITextColorGear), FairyGUIITextColorGearWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.IUISource), FairyGUIIUISourceWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Margin), FairyGUIMarginWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PackageItem), FairyGUIPackageItemWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PageOption), FairyGUIPageOptionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.PopupMenu), FairyGUIPopupMenuWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Relations), FairyGUIRelationsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ScrollPane), FairyGUIScrollPaneWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Transition), FairyGUITransitionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TranslationHelper), FairyGUITranslationHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TreeNode), FairyGUITreeNodeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TreeView), FairyGUITreeViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIConfig), FairyGUIUIConfigWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIContentScaler), FairyGUIUIContentScalerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIObjectFactory), FairyGUIUIObjectFactoryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIPackage), FairyGUIUIPackageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIPainter), FairyGUIUIPainterWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.FitScreen), FairyGUIFitScreenWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIPanel), FairyGUIUIPanelWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Window), FairyGUIWindowWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Timers), FairyGUITimersWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.ByteBuffer), FairyGUIUtilsByteBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlButton), FairyGUIUtilsHtmlButtonWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlElementType), FairyGUIUtilsHtmlElementTypeWrap.__Register);
        
        }
        
        static void wrapInit9(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlElement), FairyGUIUtilsHtmlElementWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlImage), FairyGUIUtilsHtmlImageWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlInput), FairyGUIUtilsHtmlInputWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlLink), FairyGUIUtilsHtmlLinkWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlPageContext), FairyGUIUtilsHtmlPageContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlParseOptions), FairyGUIUtilsHtmlParseOptionsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlParser), FairyGUIUtilsHtmlParserWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.HtmlSelect), FairyGUIUtilsHtmlSelectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.IHtmlObject), FairyGUIUtilsIHtmlObjectWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.IHtmlPageContext), FairyGUIUtilsIHtmlPageContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.ToolSet), FairyGUIUtilsToolSetWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.UBBParser), FairyGUIUtilsUBBParserWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.XML), FairyGUIUtilsXMLWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.XMLTagType), FairyGUIUtilsXMLTagTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.XMLIterator), FairyGUIUtilsXMLIteratorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.XMLList), FairyGUIUtilsXMLListWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.XMLUtils), FairyGUIUtilsXMLUtilsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.ZipReader), FairyGUIUtilsZipReaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.BlendModeUtils.BlendFactor), FairyGUIBlendModeUtilsBlendFactorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.MovieClip.Frame), FairyGUIMovieClipFrameWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ShaderConfig.PropertyIDs), FairyGUIShaderConfigPropertyIDsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.BitmapFont.BMGlyph), FairyGUIBitmapFontBMGlyphWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.RTLSupport.DirectionType), FairyGUIRTLSupportDirectionTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TextField.LineInfo), FairyGUITextFieldLineInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TextField.CharPosition), FairyGUITextFieldCharPositionWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.TextFormat.SpecialStyle), FairyGUITextFormatSpecialStyleWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UpdateContext.ClipInfo), FairyGUIUpdateContextClipInfoWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.GPathPoint.CurveType), FairyGUIGPathPointCurveTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.ControllerAction.ActionType), FairyGUIControllerActionActionTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIConfig.ConfigKey), FairyGUIUIConfigConfigKeyWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIConfig.ConfigValue), FairyGUIUIConfigConfigValueWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIContentScaler.ScaleMode), FairyGUIUIContentScalerScaleModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.UIContentScaler.ScreenMatchMode), FairyGUIUIContentScalerScreenMatchModeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.XMLList.Enumerator), FairyGUIUtilsXMLListEnumeratorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(FairyGUI.Utils.ZipReader.ZipEntry), FairyGUIUtilsZipReaderZipEntryWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Microsoft.IO.RecyclableMemoryStreamManager), MicrosoftIORecyclableMemoryStreamManagerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Microsoft.IO.RecyclableMemoryStream), MicrosoftIORecyclableMemoryStreamWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.CircularBuffer), DCETRuntimeCircularBufferWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ComponentView), DCETRuntimeComponentViewWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.Define), DCETRuntimeDefineWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.GameLoop), DCETRuntimeGameLoopWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.IStaticMethod), DCETRuntimeIStaticMethodWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.MonoStaticMethod), DCETRuntimeMonoStaticMethodWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.OneThreadSynchronizationContext), DCETRuntimeOneThreadSynchronizationContextWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.AssetDatabaseHelper), DCETRuntimeAssetDatabaseHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.FileHelper), DCETRuntimeFileHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.GameObjectHelper), DCETRuntimeGameObjectHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.LocalTimeHelper), DCETRuntimeLocalTimeHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.MD5Helper), DCETRuntimeMD5HelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.MongoHelper), DCETRuntimeMongoHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.PathHelper), DCETRuntimePathHelperWrap.__Register);
        
        }
        
        static void wrapInit10(LuaEnv luaenv, ObjectTranslator translator)
        {
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ProcessHelper), DCETRuntimeProcessHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ResourcesHelper), DCETRuntimeResourcesHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.StreamHelper), DCETRuntimeStreamHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.StringHelper), DCETRuntimeStringHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ZipHelper), DCETRuntimeZipHelperWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.AssetBundleLoaderAsync), DCETRuntimeAssetBundleLoaderAsyncWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.AssetBundles), DCETRuntimeAssetBundlesWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.AssetLoaderAsync), DCETRuntimeAssetLoaderAsyncWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.CameraDepthTexture), DCETRuntimeCameraDepthTextureWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.GizmosDebug), DCETRuntimeGizmosDebugWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.Log), DCETRuntimeLogWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.MonoBehaviourBridge), DCETRuntimeMonoBehaviourBridgeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.PrefabLightmapData), DCETRuntimePrefabLightmapDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ReferenceCollectorData), DCETRuntimeReferenceCollectorDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ReferenceCollectorDataComparer), DCETRuntimeReferenceCollectorDataComparerWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ReferenceCollector), DCETRuntimeReferenceCollectorWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.ReferenceLoader), DCETRuntimeReferenceLoaderWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.AcceptAllCertificate), DCETRuntimeAcceptAllCertificateWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.UnityWebRequestAsync), DCETRuntimeUnityWebRequestAsyncWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events), MicrosoftIORecyclableMemoryStreamManagerEventsWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.PrefabLightmapData.MeshRendererLightmapData), DCETRuntimePrefabLightmapDataMeshRendererLightmapDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(DCETRuntime.PrefabLightmapData.TerrainLightmapData), DCETRuntimePrefabLightmapDataTerrainLightmapDataWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamBufferType), MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamBufferTypeWrap.__Register);
        
        
            translator.DelayWrapLoader(typeof(Microsoft.IO.RecyclableMemoryStreamManager.Events.MemoryStreamDiscardReason), MicrosoftIORecyclableMemoryStreamManagerEventsMemoryStreamDiscardReasonWrap.__Register);
        
        
        
        }
        
        static void Init(LuaEnv luaenv, ObjectTranslator translator)
        {
            
            wrapInit0(luaenv, translator);
            
            wrapInit1(luaenv, translator);
            
            wrapInit2(luaenv, translator);
            
            wrapInit3(luaenv, translator);
            
            wrapInit4(luaenv, translator);
            
            wrapInit5(luaenv, translator);
            
            wrapInit6(luaenv, translator);
            
            wrapInit7(luaenv, translator);
            
            wrapInit8(luaenv, translator);
            
            wrapInit9(luaenv, translator);
            
            wrapInit10(luaenv, translator);
            
            
            translator.AddInterfaceBridgeCreator(typeof(System.Collections.IEnumerator), SystemCollectionsIEnumeratorBridge.__Create);
            
        }
        
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter(Init);
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	internal partial class InternalGlobals
    {
	    
	    static InternalGlobals()
		{
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
			};
			
			genTryArrayGetPtr = StaticLuaCallbacks.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks.__tryArraySet;
		}
	}
}
