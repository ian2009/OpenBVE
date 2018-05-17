﻿namespace OpenBve.Formats.MsTs
{
	/// <summary>The tokens from the Kuju compressed binary format</summary>
	public enum KujuTokenID : uint
	{
		/*
		* utils\FFEDIT\coreids.tok
        * NOTE: This only includes object based tokens, not the extended list
        * 
		*/
		error = 0,
		comment = 1,
		point,
		vector,
		quat,
		normals,
		normal_idxs,
		points,
		uv_point,
		uv_points,
		colour,
		colours,
		packed_colour,
		image,
		images,
		texture,
		textures,
		light_material,
		light_materials,
		linear_key,
		tcb_key,
		linear_pos,
		tcb_pos,
		slerp_rot,
		tcb_rot,
		controllers,
		anim_node,
		anim_nodes,
		animation,
		animations,
		anim,
		lod_controls,
		lod_control,
		distance_levels_header,
		distance_level_header,
		dlevel_selection,
		distance_levels,
		distance_level,
		sub_objects,
		sub_object,
		sub_object_header,
		geometry_info,
		geometry_nodes,
		geometry_node,
		geometry_node_map,
		cullable_prims,
		vtx_state,
		vtx_states,
		vertex,
		vertex_uvs,
		vertices,
		vertex_set,
		vertex_sets,
		primitives,
		prim_state,
		prim_states,
		prim_state_idx,
		indexed_point_list,
		point_list,
		indexed_line_list,
		indexed_trilist,
		tex_idxs,
		tri,
		vertex_idxs,
		flags,
		matrix,
		matrices,
		hierarchy,
		volumes,
		vol_sphere,
		shape_header,
		shape,
		shader_names,
		shader_name,
		texture_filter_names,
		texture_filter_name,
		sort_vectors,
		uvop_arg_sets,
		uvop_arg_set,
		light_model_cfgs,
		light_model_cfg,
		uv_ops,
		uvop_copy,
		uv_op_share,
		uv_op_copy,
		uv_op_uniformscale,
		uv_op_user_uninformscale,
		uv_op_nonuniformscale,
		uv_op_user_nonuninformscale,
		uv_op_transform,
		uv_op_user_transform,
		uv_op_reflectxy,
		uv_op_reflectmap,
		uv_op_reflectmapfull,
		uv_op_spheremap,
		uv_op_spheremapfull,
		uv_op_specularmap,
		uv_op_embossbump,
		user_uv_args,
		io_dev,
		io_map,
		sguid,
		dlev_cfg_table,
		dlev_cfg,
		subobject_shaders,
		subobject_light_cfgs,
		shape_named_data,
		shape_named_data_header,
		shape_named_geometry,
		shape_geom_ref,
		material_palette,
		blend_config,
		blend_config_header,
		filtermode_cfgs,
		filter_mode_cfg,
		blend_mode_cfgs,
		blend_mode_cfg,
		texture_stage_progs,
		texture_stage_prog,
		blend_mode_cfg_refs,
		shader_cfgs,
		shader_cfg,
		texture_slots,
		texture_slot,
		named_filter_modes,
		named_filter_mode,
		filtermode_cfg_refs,
		filtermode_cfg_ref,
		named_shaders,
		named_shader,
		shader_cfg_refs,
		shader_cfg_ref,
		/*
	    * utils\FFEDIT\loadstrings.hdr
        * NOTE: Offset +75 from the actual binary values
		* We don't need most of these, but keep the list intact in order to maintain
		* compatibility with OpenRails
        * 
	    */
		Tr_Worldfile = 375,
		Tr_Watermark,
		Tr_DataFile,
		Tr_ConfigFile,
		Tr_GantryFile,
		Tr_SignalFile,
		Tr_PlayerFile,
		Tr_CabViewFile,
		Tr_RouteFile,
		Tr_Activity_File,
		Tr_Activity_Header,
		Tr_SyncCode,
		Tr_SMS,
		Tr_Worldsoundfile,
		TrainCfgs,
		TrainCfg,
		Graphic,
		Default,
		CameraConfigFile,
		Lights,
		FileName,
		FileNames,
		Position,
		Direction,
		MaxVisDistance,
		Quality,
		StaticDetailLevel,
		StoreMatrix,
		AnimShape,
		StaticFlags,
		CollideFlags,
		CollideFunction,
		Sound,
		UiD,
		TrackSections,
		TrackSection,
		TrackShapes,
		TrackShape,
		TunnelShape,
		RoadShape,
		CrossoverShape,
		ManualJunctionShape,
		SectionSize,
		SectionFlags,
		SectionIdx,
		SectionCurve,
		SectionSkew,
		XoverPts,
		XoverPt,
		JNodePosn,
		TrackNodes,
		TrackNode,
		TrPins,
		TrPin,
		TrVectorNode,
		TrJunctionNode,
		TrSignalNode,
		TrLevelCrossingNode,
		TrTrackCrossingNode,
		TrEndNode,
		TrSignalDirection,
		TrEndLinkFile,
		TrVectorSections,
		TrWorldPosition,
		TrSignal,
		TrSignalType,
		TrSignalDirs,
		TrSignalDir,
		TrSignalRDir,
		TrStateSig,
		SignalFlags,
		SignalGroups,
		SignalGroup,
		SignalGroupEntries,
		LightsTab,
		LightsTabEntry,
		LightTextures,
		LightTex,
		SignalLightTex,
		SignalTypes,
		SignalType,
		SignalFnType,
		SignalSubObjs,
		SignalSubObj,
		SignalShapes,
		SignalShape,
		SignalDirLights,
		SignalDirLight,
		SignalLights,
		SignalLight,
		SignalDrawStates,
		SignalDrawState,
		SignalAspects,
		SignalAspect,
		DrawLights,
		DrawLight,
		SemaphoreInfo,
		SemaphorePos,
		DirLights,
		DirShape,
		SignalDirDisplay,
		SignalNumClearAhead,
		SigSubType,
		SigSubSType,
		SigSubUnitSeq,
		SigFlashDuration,
		SigSubJnLinkIf,
		ScriptFiles,
		ScriptFile,
		SpeedMPH,
		SpeedKPH,
		SignalUnits,
		SignalUnit,
		Class,
		Align,
		Depth,
		TdFile,
		Root,
		Elevation,
		TunnelEntrance,
		PointList,
		Velocity,
		NumSpeedLimit,
		SpeedLimit,
		Speed,
		Population,
		Area,
		Deployment,
		ScaleRange,
		StartPosition,
		EndPosition,
		StartType,
		EndType,
		Wire,
		Steam,
		Diesel,
		Electric,
		SafetyValvePressureDifference,
		Regulator,
		Cutoff,
		Brake_Engine,
		Brake_Train,
		Brake_Hand,
		Brake_Dynamic,
		Blower,
		HeatingTap,
		DampersFront,
		DampersBack,
		Firedoor,
		Injector1Steam,
		Injector1Water,
		Injector2Steam,
		Injector2Water,
		Sanding,
		Whistle,
		Throttle,
		DirControl,
		AWS,
		Horn,
		Vigilance,
		EngineStart,
		EngineStop,
		OverloadReset,
		PantographToggle1,
		PantographToggle2,
		CylinderCocks,
		WaterScoop,
		Mirrors,
		Wipers,
		Headlights,
		Taillights,
		Shovel,
		SmallEjectorOrCompressor,
		Simple_Control,
		Combined_Control,
		EmergencyStopResetToggle,
		EmergencyStopToggle,
		BellToggle,
		Gear,
		HighLowAcceleration,
		EngineBrakingButton,
		BailOffButton,
		NumNotches,
		Notch,
		MaxInHiAcceleration,
		MaxInLowAcceleration,
		MaxSandingTime,
		DoesHornTriggerBell,
		Dummy,
		DieselEngineType,
		GearBoxNumberOfGears,
		GearBoxDirectDriveGear,
		GearBoxMaxSpeedForGears,
		GearBoxMaxTractiveForceForGears,
		GearBoxOverspeedPercentageForFailure,
		GearBoxBackLoadForce,
		GearBoxCoastingForce,
		GearBoxUpGearProportion,
		GearBoxDownGearProportion,
		GearBoxOperation,
		GearBoxEngineBraking,
		MaxWheelAcceleration,
		StartDirection,
		EndDirection,
		ViewDbSphere,
		Radius,
		NoDirLight,
		Shadow,
		VDbId,
		VDbIdCount,
		AverageObjectPositionY,
		TorsionModule,
		Centre,
		Angle,
		Type,
		None,
		Stiffness,
		Damping,
		rMin,
		rMax,
		MaxTilt,
		InertiaTensor,
		Box,
		Matrix3x3,
		Size,
		CentreOfGravity,
		Mass,
		Spring,
		Coupling,
		Hydraulic,
		Automatic,
		Chain,
		Bar,
		CouplingHasRigidConnection,
		CouplingUniqueType,
		Buffers,
		Bogie,
		Freight,
		Carriage,
		Draisine,
		Tender,
		WagonShape,
		WheelRadius,
		Wagons,
		MaxCurrent,
		MaxPower,
		MaxForce,
		MaxContinuousForce,
		r0,
		DerailRailHeight,
		DerailBufferForce,
		DerailRailForce,
		BoilerVolume,
		BoilerResponsiveness,
		BoilerEffectivity,
		CoalBurnage,
		MaxBoilerOutput,
		CylinderVolume,
		CylinderEffectivity,
		InjectorSizes,
		InjectorTypes,
		Injector1FeedRateMultiplierExhaust,
		Injector1FeedRateMultiplierLive,
		Injector2FeedRateMultiplierExhaust,
		Injector2FeedRateMultiplierLive,
		Injector1WaterValveVariance,
		Injector2WaterValveVariance,
		ExhaustLimit,
		BlastExponent,
		MaxBoilerPressure,
		MaxFireMass,
		MaxWaterMass,
		SafetyValvesSteamUsage,
		CylinderStroke,
		CylinderDiameter,
		NumCylinders,
		NumDampers,
		PrimingEffect,
		PrimingFactor,
		ShovelCoalMass,
		SmokeCombustion,
		NumWheels,
		Relaxation,
		MaxVelocity,
		MaxSteamHeatingPressure,
		IdealFireMass,
		BasicSteamUsage,
		BasicCoalUsage,
		MaxTenderCoalMass,
		MaxTenderWaterMass,
		MaxOilPressure,
		MaxTemperature,
		InjectorLimits1,
		InjectorLimits2,
		CylinderCocksPowerEfficiency,
		BoilerLength,
		BoilerRadius,
		DraftingEffect,
		PantographRaiseTime,
		Break,
		Superheater,
		BrakeVacuum,
		CriticalBlowbackLevel,
		Adheasion,
		ExtraParameters,
		Friction,
		MaxDieselLevel,
		DieselUsedPerHourAtMaxPower,
		DieselUsedPerHourAtIdle,
		SteamSmokeUnitsPerPoundOfFuel,
		SteamMaxSmokeUnitsReleaseRate,
		SteamGaugeGlassHeight,
		SteamMaxWaterHeightMultiple,
		SteamMinPrimingLevel,
		SteamPrimingPowerLossProportion,
		SteamPrimingWaterUsageIncreaseProportion,
		SteamPrimingInjectorsFailAtLevel,
		SteamPrimingReductionWithCylinderCocksOpen,
		DieselEngineMaxRPM,
		DieselEngineIdleRPM,
		DieselEngineStallRPM,
		DieselEngineSpeedOfMaxTractiveEffort,
		DieselEngineMaxRPMChangeRate,
		DoesBrakeCutPower,
		BrakeCutsPowerAtBrakeCylinderPressure,
		DieselSmokeEffectMaxMagnitude,
		DieselSmokeEffectInitialMagnitude,
		DieselSmokeEffectInitialSmokeRate,
		DieselSmokeEffectMaxSmokeRate,
		BrakeEquipmentType,
		BrakeSystemType,
		MaxBrakeForce,
		MaxHandbrakeForce,
		NumberOfHandbrakeLeverSteps,
		QuickReleaseTriggerRate,
		QuickReleaseMagnification,
		QuickApplicationTriggerRate,
		QuickApplicationMagnification,
		EmergencyBrakeResMaxPressure,
		EmergencyBrakeTriggerRate,
		TrainPipeLeakRate,
		AuxilaryLeakRate,
		TripleValveRatio,
		MaxReleaseRate,
		MaxApplicationRate,
		MaxAuxilaryChargingRate,
		EmergencyResCapacity,
		EmergencyResChargingRate,
		RetainingValveSlowReleaseRate,
		BrakeCylinderPressureForMaxBrakeBrakeForce,
		EmergencyResVolumeMultiplier,
		BrakeDistributorFullServicePressure,
		BrakeDistributorEmergencyApplicationPressure,
		BrakeDistributorMaxAuxilaryResPressure,
		BrakeDistributorEmergencyResPressure,
		BrakeDistributorReleaseRate,
		BrakeDistributorApplicationRate,
		BrakeDistributorEmergencyApplicationRate,
		BrakeDistributorTrainPipeAuxResPressureDifferenceForApplication,
		BrakeDistributorTrainPipeControlRatio,
		BrakeDistributorNormalFullReleasePressure,
		MaxBrakeCylinderPressure,
		BrakeAirPressureGainInResForOnePoundFromPipe,
		BrakeAuxilaryResPressure,
		BrakeEmergencyResPressure,
		AirBrakeMaxMainResPipePressure,
		AirBrakesAirCompressorPowerRating,
		AirBrakesMainMinResAirPressure,
		AirBrakesMainMaxAirPressure,
		AirBrakesMainResVolume,
		AirBrakesAirCompressorWattage,
		AirBrakesCompressorRestartPressure,
		AirBrakesSteamUsageRate,
		AirBrakesAirUsedPerPoundsOfBrakePipePressure,
		AirBrakesHasLowPressureTest,
		AirBrakesIsCompressorElectricOrMechanical,
		VacuumBrakesExhauster1PowerRating,
		VacuumBrakesExhauster2PowerRating,
		VacuumBrakesExhausterIdlingPowerRating,
		VacuumBrakesIsExhausterElectricOrMechanical,
		VacuumBrakesExhauster1Wattage,
		VacuumBrakesExhauster2Wattage,
		VacuumBrakeBoilerPressureForZeroVacuum,
		VacuumBrakesSmallEjectorPowerRating,
		VacuumBrakesMinBoilerPressureMaxVacuum,
		VacuumBrakesSmallEjectorUsageRate,
		VacuumBrakesLargeEjectorUsageRate,
		VacuumBrakesHasVacuumPump,
		VacuumBrakesVacuumPumpPower,
		VacuumBrakesVacuumPumpResistance,
		DynamicBrakesMinUsableSpeed,
		DynamicBrakesMaximumEffectiveSpeed,
		DynamicBrakesMaximumForce,
		DynamicBrakesResistorCurrentLimit,
		DynamicBrakesCutInSpeed,
		DynamicBrakesMaxAirBrakePressure,
		DynamicBrakesFadingSpeed,
		DynamicBrakesDelayTimeBeforeEngaging,
		DynamicBrakesMaximumSpeedForFadeOut,
		DynamicBrakesEffectAtMaximumFadeOut,
		DynamicBrakesHigherSpeedCurveExponent,
		DynamicBrakesLowerSpeedCurveExponent,
		DynamicBrakesNumberOfControllerNotches,
		DynamicBrakeHasAutoBailOff,
		TrainBrakesControllerDirectControlExponent,
		TrainBrakesControllerFullQuickReleaseStart,
		TrainBrakesControllerGraduatedQuickReleaseStart,
		TrainBrakesControllerReleaseStart,
		TrainBrakesControllerReleaseLappedStart,
		TrainBrakesControllerHoldLappedStart,
		TrainBrakesControllerHoldStart,
		TrainBrakesControllerEPApplyStart,
		TrainBrakesControllerEPHoldStart,
		TrainBrakesControllerRunningStart,
		TrainBrakesControllerSelfLapStart,
		TrainBrakesControllerGraduatedSelfLapStart,
		TrainBrakesControllerGraduatedSelfLapLimitedStart,
		TrainBrakesControllerGraduatedSelfLapLimitedHoldingStart,
		EngineBrakesControllerGraduatedSelfLapLimitedHoldingStart,
		TrainBrakesControllerGraduatedSelfLapLimitedKeepPsiStart,
		TrainBrakesControllerNeutralhandleOffStart,
		TrainBrakesControllerMinimalReductionStart,
		TrainBrakesControllerApplyStart,
		TrainBrakesControllerFullServiceStart,
		TrainBrakesControllerSuppressionStart,
		TrainBrakesControllerContinuousServiceStart,
		TrainBrakesControllerEmergencyStart,
		TrainBrakesControllerMaxApplicationRate,
		TrainBrakesControllerMaxQuickReleaseRate,
		TrainBrakesControllerMaxReleaseRate,
		TrainBrakesControllerEmergencyApplicationRate,
		TrainBrakesControllerMinSystemPressure,
		TrainBrakesControllerMaxSystemPressure,
		TrainBrakesControllerEmergencyBrakeTimePenalty,
		TrainBrakesControllerMinPressureReduction,
		TrainBrakesControllerFullServicePressureDrop,
		TrainBrakesControllerMaxPressureDropInNormalApplication,
		TrainBrakesControllerMinContinuousService,
		TrainBrakesControllerMaxContinuousService,
		EngineBrakesControllerDirectControlExponent,
		EngineBrakesControllerFullQuickReleaseStart,
		EngineBrakesControllerGraduatedQuickReleaseStart,
		EngineBrakesControllerReleaseStart,
		EngineBrakesControllerReleaseLappedStart,
		EngineBrakesControllerHoldLappedStart,
		EngineBrakesControllerHoldStart,
		EngineBrakesControllerEPApplyStart,
		EngineBrakesControllerEPHoldStart,
		EngineBrakesControllerRunningStart,
		EngineBrakesControllerSelfLapStart,
		EngineBrakesControllerGraduatedSelfLapStart,
		EngineBrakesControllerGraduatedSelfLapLimitedStart,
		EngineBrakesControllerGraduatedSelfLapLimitedKeepPsiStart,
		EngineBrakesControllerNeutralHandleOffStart,
		EngineBrakesControllerMinimalReductionStart,
		EngineBrakesControllerApplyStart,
		EngineBrakesControllerFullServiceStart,
		EngineBrakesControllerSuppressionStart,
		EngineBrakesControllerContinuousServiceStart,
		EngineBrakesControllerEmergencyStart,
		EngineBrakesControllerMaxApplicationRate,
		EngineBrakesControllerMaxQuickReleaseRate,
		EngineBrakesControllerMaxReleaseRate,
		EngineBrakesControllerEmergencyApplicationRate,
		EngineBrakesControllerMinSystemPressure,
		EngineBrakesControllerMaxSystemPressure,
		EngineBrakesControllerEmergencyBrakeTimePenalty,
		EngineBrakesControllerMinPressureReduction,
		EngineBrakesControllerFullServicePressureDrop,
		EngineBrakesControllerMaxPressureDropInNormalApplication,
		EngineBrakesControllerHasProportionalBrake,
		EngineBrakesProportionalBrakeLag,
		EngineBrakesProportionalBrakeOutputReleasedPressure,
		EngineBrakesProportionalBrakeOutputAppliedPressure,
		EngineBrakesProportionalBrakeInputReleasedPressure,
		EngineBrakesProportionalBrakeInputAppliedPressure,
		BrakesEngineBrakeType,
		BrakesTrainBrakeType,
		EngineBrakesControllerMinContinuousService,
		EngineBrakesControllerMaxContinuousService,
		EngineControllers,
		BrakesEngineControllers,
		RegulatorValveType,
		RegulatorSecondValveStartPosition,
		RegulatorPilotValveExponent,
		RegulatorSecondValveExponent,
		RegulatorPilotValveFullOpenning,
		RegulatorMainValveInitialOpenning,
		SteamBlowerEffectExponent,
		SteamBlowerEfficiencyExponent,
		SteamBlowerMaxSteamUsageRate,
		SteamBlowerMaxProportionOfBlastEffect,
		SteamWaterScoopMinPickupSpeed,
		SteamWaterScoopMaxPickupSpeed,
		SteamWaterScoopResistance,
		SteamWaterScoopMaxPickupRate,
		SteamFiremanConditionLossRateConstant,
		SteamFiremanConditionGainRateConstant,
		SteamFiremanEnergyLossRateConstant,
		SteamFiremanEnergyGainRateConstant,
		SteamFiremanMaxConstantFiringRate,
		SteamFiremanMaxPossibleFiringRate,
		SteamFiremanEnergyUsedPerPoundOfCoal,
		SteamFiremanIsMechanicalStoker,
		SteamOilBurnerMinBurnRate,
		SteamOilBurnerMaxBurnRate,
		SteamOilBurnerControlExponent,
		SteamOilBurnerSteamFromOnePoundOfOilBurnt,
		SteamOilBurnerMaxRateOfTempChange,
		SteamOilBurnerEfficiencyExponent,
		SteamOilBurnerMinBurnerTemperature,
		SteamOilBurnerMaxBurnerTemperature,
		SteamOilBurnerTemperatureChnageExponent,
		SteamOilBurnerSteamGenerationExponent,
		SteamOilBurnerSmokeForOnePoundOfOil,
		SteamOilBurnerSteamFuelType,
		SteamCylinderCocksOperation,
		CutoffMaxReverse,
		CutoffMaxForward,
		SteamSmallestCutoff,
		NumberOfDamperSteps,
		IsTenderRequired,
		Handbrake,
		AntiSlip,
		Inside,
		PassengerCabinFile,
		PassengerCabinHeadPos,
		Thumbnail,
		HeadOut,
		Mirror,
		Wiper,
		Door,
		Pantograph,
		Wheelset,
		IntakePoint,
		FreightGrain,
		FreightCoal,
		FreightGravel,
		FreightSand,
		FuelWater,
		FuelCoal,
		FuelDiesel,
		SpecialMail,
		FreightAnim,
		EngineOperatingProcedures,
		TrItemRefs,
		TrItemRef,
		TrItemId,
		TrItemSData,
		TrItemPData,
		TrItemRData,
		TrItemSRData,
		TrItemTable,
		EmptyItem,
		SignalItem,
		PickupItem,
		PlatformItem,
		HazzardItem,
		CarSpawnerItem,
		SidingItem,
		LevelCrItem,
		SpeedPostItem,
		SoundRegionItem,
		CrossoverItem,
		TrainWagons,
		WagonType,
		CoupledWith,
		WagonData,
		EngineData,
		FirstWagon,
		QDirection,
		EngineVariables,
		TrainData,
		Inverse,
		Flip,
		NotCoupledToActiveTrain,
		NextWagonUID,
		Durability,
		Effects,
		FrontView,
		LeftView,
		RightView,
		HornFX,
		BellFX,
		AlerterFX,
		SteamSpecialEffects,
		CylindersFX,
		DrainpipeFX,
		StackFX,
		SafetyValvesFX,
		WhistleFX,
		DieselSpecialEffects,
		Exhaust1,
		Exhaust2,
		Marker,
		Coords,
		mapmm,
		TrItemSignal,
		TrItemDest,
		TrDestName,
		TrDestNameId,
		NumSections,
		MainRoute,
		NumPaths,
		ClearanceDist,
		Camera,
		CamType,
		CamTypeBrick,
		CamTypeFrontTracking,
		CamTypeRearTracking,
		CamTypePassenger,
		CamTypeCab,
		CamTypeSpotter,
		CamTypeDerail,
		CamTypeHeadOut,
		CamTypeCoupling,
		CamTypeYard,
		CamControlNo,
		CamControlRotate,
		CamControlFull,
		CamControlStrafe,
		CamControlIsometric,
		CamControlViewSwitch,
		CamControlTethered,
		CamControlDerail,
		CamControlCoupling,
		CamControlYard,
		WagonNum,
		RotationLimit,
		Fov,
		ZClip,
		CameraOffset,
		ObjectOffset,
		Subpath,
		FileIndex,
		TrGUI_Editbox_Vars,
		TrGUI_Editbox_Focus_Lock,
		TrGUI_Editbox_Alphanumeric,
		TrGUI_Listbox_Node,
		TrGUI_List_Slots,
		TrGUI_Listbox_SlotHt,
		TrGUI_Listbox_Max,
		TrGUI_Listbox_Min_Slots,
		TrGUI_Listbox_Slider,
		TrGUI_Scroll_Delay,
		TrGUI_Region_Name,
		TrGUI_Region_Surf,
		TrGUI_Region_Disabled,
		TrGUI_Region_Dis_Surf,
		TrGUI_Region_Area,
		TrGUI_Region_Cursor,
		TrGUI_Region_Parent,
		TrGUI_Region_Layer,
		TrGUI_Region_Drag_Target,
		TrGUI_Region_Font,
		TrGUI_Region_DisFont,
		TrGUI_Region_Shadow_Font,
		TrGUI_Region_TextArea,
		TrGUI_Region_Text_Owned,
		TrGUI_Slider_Vertical,
		TrGUI_Slider_Centre,
		TrGUI_Slider_Min_Max,
		TrGUI_Slider_Quantized,
		TrGUI_Slider_Back,
		TrGUI_Slider_Area,
		TrGUI_Tooltip_Text,
		TrGUI_Drag_Bitmap,
		TrGUI_Text_Pos,
		TrGUI_Mouse_LDn,
		TrGUI_Mouse_RDn,
		TrGUI_Mouse_LDblClick,
		TrGUI_Mouse_RDblClick,
		TrGUI_Mouse_LUp,
		TrGUI_Mouse_RUp,
		TrGUI_Mouse_LHeld,
		TrGUI_Mouse_RHeld,
		TrGUI_Mouse_Focus,
		TrGUI_Hotspot,
		TrGUI_Cursor_Surfs,
		TrGUI_Widget,
		TrGUI_Icon_Set,
		TrGUI_Next_Screen,
		TrGUI_Parent_Screen,
		TrGUI_Loading_Screen,
		TrGUI_Textbox_Slider,
		TrGUI_IOM_Filename,
		TrGUI_Debrief_Screen,
		TrGUI_Up_Button,
		TrGUI_Dn_Button,
		TrGUI_Num_Lines,
		TrGUI_Onoff_Dn_Surf,
		TrGUI_Onoff_Radio,
		TrGUI_Onoff_Popup_Centre,
		TrGUI_Timeout,
		TrGUI_Popup_Non_Modal,
		TrGUI_Button_Down_Surf,
		TrGUI_Button_Down_Font,
		TrGUI_Button_Group,
		TrGUI_Group_Max_On,
		TrGUI_State3_Hi_Font,
		TrGUI_State3_Hi_Surf,
		TrGUI_ComboButton_Popup,
		TrGUI_ComboButton_Listbox,
		TrGUI_ComboButton_Display_Region,
		TrGUI_ComboButton_Open_Up,
		TrGUI_ComboButton_Use_Bitmaps,
		TrGUI_ComboButton_No_Text,
		TrGUI_ComboButton_Listbox_Sound,
		TrGUI_Overlay_Type,
		TrGUI_Anim_Frame_Area,
		TrGUI_Anim_Num_Frames,
		TrGUI_Anim_Delay,
		TrGUI_Anim_Reverse,
		TrGUI_Anim_Loop,
		TPoleConfigData,
		TPoleConfig,
		Config,
		Separation,
		ESD_Bounding_Box,
		ESD_Tunnel,
		ESD_Complex_Box,
		ESD_Complex,
		ESD_Sphere,
		ESD_Alternative_Texture,
		ESD_Shape_Count,
		ESD_Detail_Level,
		ESD_No_Visual_Obstruction,
		ESD_Snapable,
		ESD_Software_Dlev,
		ESD_SubObj,
		ESD_Headlight,
		PlatformName,
		PlatformData,
		PlatformTrItemData,
		PlatformMinWaitingTime,
		PlatformNumPassengersWaiting,
		SpeedRange,
		PickupType,
		PickupAnimData,
		PickupCapacity,
		PickupTrItemData,
		CarFrequency,
		CarAvSpeed,
		CarSpawnerTrItemData,
		SidingName,
		SidingData,
		SidingTrItemData,
		LevelCrParameters,
		LevelCrData,
		LevelCrTiming,
		LevelCrTrItemData,
		SpeedpostFlags,
		SpeedpostNumber,
		SpeedpostTrItemData,
		Speedpost_Set_Count,
		Speedpost_Set,
		Speed_Sign_Shape,
		Speed_Warning_Sign_Shape,
		Speed_Resume_Sign_Shape,
		Speed_Digit_Tex,
		Milepost_Shape,
		Milepost_Digit_Tex,
		Restricted_Shape,
		End_Restricted_Shape,
		Speed_Text_Size,
		Milepost_Text_Size,
		CrossoverTrItemData,
		TrackType,
		Style,
		GantrySets,
		GantrySet,
		GantryTable,
		GantryTableEntry,
		Distance,
		GantryInfo,
		GantryShape,
		GantrySize,
		Width,
		Height,
		TreeTexture,
		TreeSize,
		Birds,
		Idle_Key,
		Idle_Key2,
		Surprise_Key_Left,
		Surprise_Key_Right,
		Success_Scarper_Key,
		Fail_Scarper_Key,
		SoundregionTrackType,
		SoundregionRoty,
		Players,
		Player,
		CabView,
		CabViewType,
		CabViewFile,
		CabViewWindow,
		CabViewWindowFile,
		CabViewControls,
		Gauge,
		Dial,
		Digital,
		DigitalClock,
		AnalogueClock,
		MultiStateDisplay,
		CabSignalDisplay,
		TwoState,
		TriState,
		CombinedControl,
		Lever,
		Firebox,
		ZeroPos,
		PositiveColour,
		NegativeColour,
		DecreaseColour,
		ControlColour,
		Orientation,
		Units,
		Pivot,
		ScalePos,
		Accuracy,
		AccuracySwitch,
		LeadingZeros,
		Justification,
		States,
		State,
		SwitchVal,
		MouseControl,
		NumFrames,
		NumPositions,
		NumValues,
		DirIncrease,
		RouteID,
		Name,
		Description,
		Electrified,
		Mountains,
		OverheadWireHeight,
		PassengerRuleSet,
		FreightRuleSet,
		SignalSet,
		TrackGauge,
		Era,
		Environment,
		SpringClear,
		SpringRain,
		SpringSnow,
		SummerClear,
		SummerRain,
		SummerSnow,
		AutumnClear,
		AutumnRain,
		AutumnSnow,
		WinterClear,
		WinterRain,
		WinterSnow,
		TerrainErrorScale,
		RouteStart,
		LoadingScreen,
		MilepostUnitsMiles,
		MilepostUnitsKilometers,
		MaxLineVoltage,
		DefaultSignalSMS,
		DefaultCrossingSMS,
		DefaultWaterTowerSMS,
		DefaultCoalTowerSMS,
		DefaultDieselTowerSMS,
		TempRestrictedSpeed,
		PathID,
		Mode,
		Briefing,
		Player_Train_Config,
		CoalLevel,
		WaterLevel,
		FuelLevel,
		StartingSpeed,
		EndingSpeed,
		Season,
		Weather,
		StartTime,
		Hazards,
		Animals,
		Workers,
		Debris,
		Voltage,
		Difficulty,
		Severity,
		StationProperties,
		Station,
		ID,
		Value,
		FailedSignals,
		FailedSignal,
		FreightPoints,
		FreightPoint,
		Action,
		MailPoints,
		MailPoint,
		ActivityObjects,
		ActivityObject,
		ActivityRestrictedSpeedZones,
		ActivityRestrictedSpeedZone,
		ActivityFailedSignals,
		ActivityFailedSignal,
		Tile,
		ObjectType,
		Events,
		Location,
		Trigger,
		Outcomes,
		PickupIdAndAmount,
		TextToDisplayOnCompletionIfTriggered,
		TextToDisplayOnCompletionIfNotTriggered,
		TextToDisplayDescriptionOfTask,
		BreakSpeedRecord,
		CoupleToTrainset,
		LeaveWagons,
		PickedUpPassengers,
		PickedUpCargo,
		ReachedSpeed,
		Time,
		AITrains,
		Traffic_Definition,
		Service_Definition,
		Train_Config,
		Reversable_Event,
		ActivitySuccessText,
		ActivityFailText,
		TriggerOnStop,
		CompleteActivity,
		IncActLevel,
		DecActLevel,
		ActivateEvent,
		RestoreActLevel,
		DisplayMessage,
		PlaySound,
		ActivitySuccess,
		ActivityFail,
		StartIgnoringSpeedLimits,
		StopIgnoringSpeedLimits,
		Activation_Level,
		EventCategoryLocation,
		EventCategoryTime,
		EventCategoryAction,
		EventTypeLocation,
		EventTypeTime,
		NextServiceUID,
		NextActivityObjectUID,
		EventTypeAllStops,
		EventTypePickUpPassengers,
		EventTypePickUp,
		EventTypeReachSpeed,
		EventTypePickUpWagons,
		EventTypeDropOffWagonsAtLocation,
		EventTypeAssembleTrain,
		EventTypeAssembleTrainAtLocation,
		Wagon_List,
		TimeTable,
		StartInWorld,
		EndInWorld,
		StationStop,
		PlatformStartID,
		PlatformEndID,
		ArrivalTime,
		MinWaitingTime,
		DepartTime,
		DistanceDownPath,
		Efficiency,
		SkipCount,
		TrackPDPs,
		TrackPDP,
		TrackPaths,
		TrackPath,
		TrPathName,
		TrPathStart,
		TrPathEnd,
		TrPathNodeSid,
		TrPathPDPRef,
		TrPathNodes,
		TrPathNode,
		TrPathFlags,
		ScalabiltyGroup,
		Streams,
		Stream,
		Triggers,
		Discrete_Trigger,
		Variable_Trigger,
		Initial_Trigger,
		Dist_Travelled_Trigger,
		Random_Trigger,
		Delay_Min_Max,
		Volume_Min_Max,
		Dist_Min_Max,
		Speed_Inc_Past,
		Speed_Dec_Past,
		Distance_Inc_Past,
		Distance_Dec_Past,
		Variable1_Inc_Past,
		Variable1_Dec_Past,
		Variable2_Inc_Past,
		Variable2_Dec_Past,
		Variable3_Inc_Past,
		Variable3_Dec_Past,
		PlayOneShot,
		FileList,
		File,
		SelectionMethod,
		RandomSelection,
		SequentialSelection,
		StartLoop,
		StartLoopRelease,
		ReleaseLoopRelease,
		ReleaseLoopReleaseWithJump,
		EnableTrigger,
		DisableTrigger,
		Volume,
		Stereo,
		LoadAllWaves,
		Priority,
		SetStreamVolume,
		Ignore3d,
		VolumeCurve,
		FrequencyCurve,
		SpeedControlled,
		DistanceControlled,
		Variable1Controlled,
		Variable2Controlled,
		Variable3Controlled,
		CurvePoints,
		Granularity,
		Activation,
		Deactivation,
		PassengerCam,
		CabCam,
		ExternalCam,
		SoundTimer,
		AudioStream,
		SoundSystem,
		TrainMinMaxDistance,
		AmbientMinMaxDistance,
		Rolloff,
		MonitoringDeviceMonitorTimeLimit,
		MonitoringDeviceAlarmTimeLimit,
		MonitoringDevicePenaltyTimeLimit,
		MonitoringDeviceCriticalLevel,
		MonitoringDeviceResetLevel,
		MonitoringDeviceAppliesFullBrake,
		MonitoringDeviceAppliesEmergencyBrake,
		MonitoringDeviceAppliesCutsPower,
		MonitoringDeviceAppliesShutsDownEngine,
		MonitoringDeviceAlarmTimeBeforeOverSpeed,
		MonitoringDeviceResetOnZeroSpeed,
		MonitoringDeviceResetOnZeroThrottle,
		MonitoringDeviceResetOnDirectionNeutral,
		MonitoringDeviceResetOnEngineAtIdle,
		MonitoringDeviceResetOnBrakeOff,
		MonitoringDeviceResetOnBrakeFullyOn,
		MonitoringDeviceResetOnDynamicBrakeOff,
		MonitoringDeviceResetOnDynamicBrakeOn,
		MonitoringDeviceResetOnResetButton,
		MonitoringDeviceDoesSuppressionReset,
		MonitoringDeviceTriggerOnOverspeed,
		MonitoringDeviceTriggerOnHighCurrent,
		MonitoringDeviceTriggerOnLowMainResPressire,
		MonitoringDeviceTriggerOnOverRPM,
		MonitoringDeviceTriggerOnTrackOverspeed,
		MonitoringDeviceTriggerOnTrackOverspeedMargin,
		AWSMonitor,
		VigilanceMonitor,
		EmergencyStopMonitor,
		OverspeedMonitor,
		LCRegion,
		DEMRegion,
		Region,
		FileSampleSize,
		FileSamples,
		FileSampleBytes,
		BigEndian,
		SampleFiles,
		SampleFile,
		SFlags,
		Light,
		Conditions,
		Headlight,
		Unit,
		Penalty,
		Control,
		Service,
		TimeOfDay,
		ActiveCab,
		InactiveCab,
		FadeIn,
		FadeOut,
		Duration,
		LightColour,
		Azimuth,
		Transition,
		Cycle,
		Serial,
		SaveHeader,
		SaveTDBs,
		SaveTDB,
		SaveRDB,
		SaveTDBNodes,
		SaveTDBNode,
		SaveTrItems,
		SaveTrItem,
		SaveVNodeOwners,
		SaveObj,
		SaveStatic,
		SaveCollobj,
		SavePhysobj,
		SaveWagon,
		SaveEngine,
		SaveTrain,
		SaveController,
		SaveActivity,
		SaveEvents,
		SaveEvent,
		SaveServices,
		SaveService,
		SaveActObjs,
		SaveActObjWagonList,
		SaveActObjSpeedMon,
		SaveWagonUIDs,
		SaveDebrief,
		SaveTitle,
		SaveSuccessfulStrings,
		SaveSuccessfulString,
		SaveUnSuccessfulStrings,
		SaveUnSuccessfulString,
		SaveTimetableEntries,
		SaveTimetableEntry,
		SaveWorkOrderEntries,
		SaveWorkOrderEntry,
		SaveWorkOrderType,
		SaveWorkOrderTaskText,
		SaveWorkOrderWagonIds,
		SaveWorkOrderLocationText,
		SaveWorkOrderNotesText,
		SaveWorkOrderCompleted,
		SaveSStops,
		SaveSStop,
		SaveTrFollower,
		SaveAIWagons,
		SaveAIWagon,
		SaveSPUnavail,
		SaveSP,
		Version_Route,
		Version_TrainDB,
		Version_Consist,
		Version_Path,
		Version_Traffic,
		Version_Service,
		Player_Traffic_Definition,
		Player_Service_Definition,
		Tr_Activity,
		CrashProbability,
		TrackDB,
		PassengerCapacity,
		RunUpTimeToMaxForce,
		VolumeTweak,
		GravityScale,
		DerailScale,
		TimetableTollerance,

		DEMPath,
	}
}