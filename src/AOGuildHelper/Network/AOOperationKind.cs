namespace AOGuildHelper.Network;

public enum AOOperationKind
{
	Unused = 0,
	Ping = 1,
	Join = 2,
	VersionedOperation = 3,
	CreateAccount = 4,
	Login = 5,
	CreateGuestAccount = 6,
	SendCrashLog = 7,
	SendTraceRoute = 8,
	SendVfxStats = 9,
	SendGamePingInfo = 10,
	CreateCharacter = 11,
	DeleteCharacter = 12,
	SelectCharacter = 13,
	AcceptPopups = 14,
	RedeemKeycode = 15,
	GetGameServerByCluster = 16,
	GetShopPurchaseUrl = 17,
	GetReferralSeasonDetails = 18,
	GetReferralLink = 19,
	GetShopTilesForCategory = 20,
	Move = 21,
	AttackStart = 22,
	CastStart = 23,
	CastCancel = 24,
	TerminateToggleSpell = 25,
	ChannelingCancel = 26,
	AttackBuildingStart = 27,
	InventoryDestroyItem = 28,
	InventoryMoveItem = 29,
	InventoryRecoverItem = 30,
	InventoryRecoverAllItems = 31,
	InventorySplitStack = 32,
	InventorySplitStackInto = 33,
	GetClusterData = 34,
	ChangeCluster = 35,
	ConsoleCommand = 36,
	ChatMessage = 37,
	ReportClientError = 38,
	RegisterToObject = 39,
	UnRegisterFromObject = 40,
	CraftBuildingChangeSettings = 41,
	CraftBuildingTakeMoney = 42,
	RepairBuildingChangeSettings = 43,
	RepairBuildingTakeMoney = 44,
	ActionBuildingChangeSettings = 45,
	HarvestStart = 46,
	HarvestCancel = 47,
	TakeSilver = 48,
	ActionOnBuildingStart = 49,
	ActionOnBuildingCancel = 50,
	InstallResourceStart = 51,
	InstallResourceCancel = 52,
	InstallSilver = 53,
	BuildingFillNutrition = 54,
	BuildingChangeRenovationState = 55,
	BuildingBuySkin = 56,
	BuildingClaim = 57,
	BuildingGiveup = 58,
	BuildingNutritionSilverStorageDeposit = 59,
	BuildingNutritionSilverStorageWithdraw = 60,
	BuildingNutritionSilverRewardSet = 61,
	ConstructionSiteCreate = 62,
	PlaceableObjectPlace = 63,
	PlaceableObjectPlaceCancel = 64,
	PlaceableObjectPickup = 65,
	FurnitureObjectUse = 66,
	FarmableHarvest = 67,
	FarmableFinishGrownItem = 68,
	FarmableDestroy = 69,
	FarmableGetProduct = 70,
	FarmableFill = 71,
	TearDownConstructionSite = 72,
	AuctionCreateOffer = 73,
	AuctionCreateRequest = 74,
	AuctionGetOffers = 75,
	AuctionGetRequests = 76,
	AuctionBuyOffer = 77,
	AuctionAbortAuction = 78,
	AuctionModifyAuction = 79,
	AuctionAbortOffer = 80,
	AuctionAbortRequest = 81,
	AuctionSellRequest = 82,
	AuctionGetFinishedAuctions = 83,
	AuctionGetFinishedAuctionsCount = 84,
	AuctionFetchAuction = 85,
	AuctionGetMyOpenOffers = 86,
	AuctionGetMyOpenRequests = 87,
	AuctionGetMyOpenAuctions = 88,
	AuctionGetItemAverageStats = 89,
	AuctionGetItemAverageValue = 90,
	ContainerOpen = 91,
	ContainerClose = 92,
	ContainerManageSubContainer = 93,
	Respawn = 94,
	Suicide = 95,
	JoinGuild = 96,
	LeaveGuild = 97,
	CreateGuild = 98,
	InviteToGuild = 99,
	DeclineGuildInvitation = 100,
	KickFromGuild = 101,
	InstantJoinGuild = 102,
	DuellingChallengePlayer = 103,
	DuellingAcceptChallenge = 104,
	DuellingDenyChallenge = 105,
	ChangeClusterTax = 106,
	ClaimTerritory = 107,
	GiveUpTerritory = 108,
	ChangeTerritoryAccessRights = 109,
	GetMonolithInfo = 110,
	GetClaimInfo = 111,
	GetAttackInfo = 112,
	GetTerritorySeasonPoints = 113,
	GetAttackSchedule = 114,
	GetMatches = 115,
	GetMatchDetails = 116,
	JoinMatch = 117,
	LeaveMatch = 118,
	ChangeChatSettings = 119,
	LogoutStart = 120,
	LogoutCancel = 121,
	ClaimOrbStart = 122,
	ClaimOrbCancel = 123,
	MatchLootChestOpeningStart = 124,
	MatchLootChestOpeningCancel = 125,
	DepositToGuildAccount = 126,
	WithdrawalFromAccount = 127,
	ChangeGuildPayUpkeepFlag = 128,
	ChangeGuildTax = 129,
	GetMyTerritories = 130,
	MorganaCommand = 131,
	GetServerInfo = 132,
	SubscribeToCluster = 133,
	AnswerMercenaryInvitation = 134,
	GetCharacterEquipment = 135,
	GetCharacterSteamAchievements = 136,
	GetCharacterStats = 137,
	GetKillHistoryDetails = 138,
	LearnMasteryLevel = 139,
	ReSpecAchievement = 140,
	ChangeAvatar = 141,
	GetRankings = 142,
	GetRank = 143,
	GetGvgSeasonRankings = 144,
	GetGvgSeasonRank = 145,
	GetGvgSeasonHistoryRankings = 146,
	GetGvgSeasonGuildMemberHistory = 147,
	KickFromGvGMatch = 148,
	GetCrystalLeagueDailySeasonPoints = 149,
	GetChestLogs = 150,
	GetAccessRightLogs = 151,
	GetGuildAccountLogs = 152,
	GetGuildAccountLogsLargeAmount = 153,
	InviteToPlayerTrade = 154,
	PlayerTradeCancel = 155,
	PlayerTradeInvitationAccept = 156,
	PlayerTradeAddItem = 157,
	PlayerTradeRemoveItem = 158,
	PlayerTradeAcceptTrade = 159,
	PlayerTradeSetSilverOrGold = 160,
	SendMiniMapPing = 161,
	Stuck = 162,
	BuyRealEstate = 163,
	ClaimRealEstate = 164,
	GiveUpRealEstate = 165,
	ChangeRealEstateOutline = 166,
	GetMailInfos = 167,
	GetMailCount = 168,
	ReadMail = 169,
	SendNewMail = 170,
	DeleteMail = 171,
	MarkMailUnread = 172,
	ClaimAttachmentFromMail = 173,
	ApplyToGuild = 174,
	AnswerGuildApplication = 175,
	RequestGuildFinderFilteredList = 176,
	UpdateGuildRecruitmentInfo = 177,
	RequestGuildRecruitmentInfo = 178,
	RequestGuildFinderNameSearch = 179,
	RequestGuildFinderRecommendedList = 180,
	RegisterChatPeer = 181,
	SendChatMessage = 182,
	SendModeratorMessage = 183,
	JoinChatChannel = 184,
	LeaveChatChannel = 185,
	SendWhisperMessage = 186,
	Say = 187,
	PlayEmote = 188,
	StopEmote = 189,
	GetClusterMapInfo = 190,
	AccessRightsChangeSettings = 191,
	Mount = 192,
	MountCancel = 193,
	BuyJourney = 194,
	SetSaleStatusForEstate = 195,
	ResolveGuildOrPlayerName = 196,
	GetRespawnInfos = 197,
	MakeHome = 198,
	LeaveHome = 199,
	ResurrectionReply = 200,
	AllianceCreate = 201,
	AllianceDisband = 202,
	AllianceGetMemberInfos = 203,
	AllianceInvite = 204,
	AllianceAnswerInvitation = 205,
	AllianceCancelInvitation = 206,
	AllianceKickGuild = 207,
	AllianceLeave = 208,
	AllianceChangeGoldPaymentFlag = 209,
	AllianceGetDetailInfo = 210,
	GetIslandInfos = 211,
	AbandonMyIsland = 212,
	BuyMyIsland = 213,
	BuyGuildIsland = 214,
	AbandonGuildIsland = 215,
	UpgradeMyIsland = 216,
	UpgradeGuildIsland = 217,
	MoveMyIsland = 218,
	MoveGuildIsland = 219,
	TerritoryFillNutrition = 220,
	TeleportBack = 221,
	PartyInvitePlayer = 222,
	PartyRequestJoin = 223,
	PartyAnswerInvitation = 224,
	PartyAnswerJoinRequest = 225,
	PartyLeave = 226,
	PartyKickPlayer = 227,
	PartyMakeLeader = 228,
	PartyChangeLootSetting = 229,
	PartyMarkObject = 230,
	PartySetRole = 231,
	SetGuildCodex = 232,
	ExitEnterStart = 233,
	ExitEnterCancel = 234,
	QuestGiverRequest = 235,
	GoldMarketGetBuyOffer = 236,
	GoldMarketGetBuyOfferFromSilver = 237,
	GoldMarketGetSellOffer = 238,
	GoldMarketGetSellOfferFromSilver = 239,
	GoldMarketBuyGold = 240,
	GoldMarketSellGold = 241,
	GoldMarketCreateSellOrder = 242,
	GoldMarketCreateBuyOrder = 243,
	GoldMarketGetInfos = 244,
	GoldMarketCancelOrder = 245,
	GoldMarketGetAverageInfo = 246,
	TreasureChestUsingStart = 247,
	TreasureChestUsingCancel = 248,
	UseLootChest = 249,
	UseShrine = 250,
	UseHellgateShrine = 251,
	GetSiegeBannerInfo = 252,
	LaborerStartJob = 253,
	LaborerTakeJobLoot = 254,
	LaborerDismiss = 255,
	LaborerMove = 256,
	LaborerBuyItem = 257,
	LaborerUpgrade = 258,
	BuyPremium = 259,
	RealEstateGetAuctionData = 260,
	RealEstateBidOnAuction = 261,
	FriendInvite = 262,
	FriendAnswerInvitation = 263,
	FriendCancelnvitation = 264,
	FriendRemove = 265,
	InventoryStack = 266,
	InventorySort = 267,
	InventoryDropAll = 268,
	InventoryAddToStacks = 269,
	EquipmentItemChangeSpell = 270,
	ExpeditionRegister = 271,
	ExpeditionRegisterCancel = 272,
	JoinExpedition = 273,
	DeclineExpeditionInvitation = 274,
	VoteStart = 275,
	VoteDoVote = 276,
	RatingDoRate = 277,
	EnteringExpeditionStart = 278,
	EnteringExpeditionCancel = 279,
	ActivateExpeditionCheckPoint = 280,
	ArenaRegister = 281,
	ArenaAddInvite = 282,
	ArenaRegisterCancel = 283,
	ArenaLeave = 284,
	JoinArenaMatch = 285,
	DeclineArenaInvitation = 286,
	EnteringArenaStart = 287,
	EnteringArenaCancel = 288,
	ArenaCustomMatch = 289,
	UpdateCharacterStatement = 290,
	BoostFarmable = 291,
	GetStrikeHistory = 292,
	UseFunction = 293,
	UsePortalEntrance = 294,
	ResetPortalBinding = 295,
	QueryPortalBinding = 296,
	ClaimPaymentTransaction = 297,
	ChangeUseFlag = 298,
	ClientPerformanceStats = 299,
	ExtendedHardwareStats = 300,
	ClientLowMemoryWarning = 301,
	TerritoryClaimStart = 302,
	TerritoryClaimCancel = 303,
	DeliverCarriableObjectStart = 304,
	DeliverCarriableObjectCancel = 305,
	TerritoryUpgradeWithPowerCrystal = 306,
	RequestAppStoreProducts = 307,
	VerifyProductPurchase = 308,
	QueryGuildPlayerStats = 309,
	QueryAllianceGuildStats = 310,
	TrackAchievements = 311,
	SetAchievementsAutoLearn = 312,
	DepositItemToGuildCurrency = 313,
	WithdrawalItemFromGuildCurrency = 314,
	AuctionSellSpecificItemRequest = 315,
	FishingStart = 316,
	FishingCasting = 317,
	FishingCast = 318,
	FishingCatch = 319,
	FishingPull = 320,
	FishingGiveLine = 321,
	FishingFinish = 322,
	FishingCancel = 323,
	CreateGuildAccessTag = 324,
	DeleteGuildAccessTag = 325,
	RenameGuildAccessTag = 326,
	FlagGuildAccessTagGuildPermission = 327,
	AssignGuildAccessTag = 328,
	RemoveGuildAccessTagFromPlayer = 329,
	ModifyGuildAccessTagEditors = 330,
	RequestPublicAccessTags = 331,
	ChangeAccessTagPublicFlag = 332,
	UpdateGuildAccessTag = 333,
	SteamStartMicrotransaction = 334,
	SteamFinishMicrotransaction = 335,
	SteamIdHasActiveAccount = 336,
	CheckEmailAccountState = 337,
	LinkAccountToSteamId = 338,
	InAppConfirmPaymentGooglePlay = 339,
	InAppConfirmPaymentAppleAppStore = 340,
	InAppPurchaseRequest = 341,
	InAppPurchaseFailed = 342,
	CharacterSubscriptionInfo = 343,
	AccountSubscriptionInfo = 344,
	BuyGvgSeasonBooster = 345,
	ChangeFlaggingPrepare = 346,
	OverCharge = 347,
	OverChargeEnd = 348,
	RequestTrusted = 349,
	ChangeGuildLogo = 350,
	PartyFinderRegisterForUpdates = 351,
	PartyFinderUnregisterForUpdates = 352,
	PartyFinderEnlistNewPartySearch = 353,
	PartyFinderDeletePartySearch = 354,
	PartyFinderChangePartySearch = 355,
	PartyFinderChangeRole = 356,
	PartyFinderApplyForGroup = 357,
	PartyFinderAcceptOrDeclineApplyForGroup = 358,
	PartyFinderGetEquipmentSnapshot = 359,
	PartyFinderRegisterApplicants = 360,
	PartyFinderUnregisterApplicants = 361,
	PartyFinderFulltextSearch = 362,
	PartyFinderRequestEquipmentSnapshot = 363,
	GetPersonalSeasonTrackerData = 364,
	GetPersonalSeasonPastRewardData = 365,
	UseConsumableFromInventory = 366,
	ClaimPersonalSeasonReward = 367,
	EasyAntiCheatMessageToServer = 368,
	XignCodeMessageToServer = 369,
	BattlEyeMessageToServer = 370,
	SetNextTutorialState = 371,
	AddPlayerToMuteList = 372,
	RemovePlayerFromMuteList = 373,
	ProductShopUserEvent = 374,
	GetVanityUnlocks = 375,
	BuyVanityUnlocks = 376,
	GetMountSkins = 377,
	SetMountSkin = 378,
	SetWardrobe = 379,
	ChangeCustomization = 380,
	ChangePlayerIslandData = 381,
	GetGuildChallengePoints = 382,
	SmartQueueJoin = 383,
	SmartQueueLeave = 384,
	SmartQueueSelectSpawnCluster = 385,
	UpgradeHideout = 386,
	InitHideoutAttackStart = 387,
	InitHideoutAttackCancel = 388,
	HideoutFillNutrition = 389,
	HideoutGetInfo = 390,
	HideoutGetOwnerInfo = 391,
	HideoutSetTribute = 392,
	HideoutUpgradeWithPowerCrystal = 393,
	HideoutDeclareHQ = 394,
	HideoutUndeclareHQ = 395,
	HideoutGetHQRequirements = 396,
	HideoutBoost = 397,
	HideoutBoostConstruction = 398,
	OpenWorldAttackScheduleStart = 399,
	OpenWorldAttackScheduleCancel = 400,
	OpenWorldAttackConquerStart = 401,
	OpenWorldAttackConquerCancel = 402,
	GetOpenWorldAttackDetails = 403,
	GetNextOpenWorldAttackScheduleTime = 404,
	RecoverVaultFromHideout = 405,
	GetGuildEnergyDrainInfo = 406,
	ChannelingUpdate = 407,
	UseCorruptedShrine = 408,
	RequestEstimatedMarketValue = 409,
	LogFeedback = 410,
	GetInfamyInfo = 411,
	GetPartySmartClusterQueuePriority = 412,
	SetPartySmartClusterQueuePriority = 413,
	ClientAntiAutoClickerInfo = 414,
	ClientBotPatternDetectionInfo = 415,
	ClientAntiGatherClickerInfo = 416,
	LoadoutCreate = 417,
	LoadoutRead = 418,
	LoadoutReadHeaders = 419,
	LoadoutUpdate = 420,
	LoadoutDelete = 421,
	LoadoutOrderUpdate = 422,
	LoadoutEquip = 423,
	BatchUseItemCancel = 424,
	EnlistFactionWarfare = 425,
	GetFactionWarfareWeeklyReport = 426,
	ClaimFactionWarfareWeeklyReport = 427,
	GetFactionWarfareCampaignData = 428,
	ClaimFactionWarfareItemReward = 429,
	SendMemoryConsumption = 430,
	PickupCarriableObjectStart = 431,
	PickupCarriableObjectCancel = 432,
	SetSavingChestLogsFlag = 433,
	GetSavingChestLogsFlag = 434,
	RegisterGuestAccount = 435,
	ResendGuestAccountVerificationEmail = 436,
	DoSimpleActionStart = 437,
	DoSimpleActionCancel = 438,
	GetGvgSeasonContributionByActivity = 439,
	GetGvgSeasonContributionByCrystalLeague = 440,
	GetGuildMightCategoryContribution = 441,
	GetGuildMightCategoryOverview = 442,
	GetPvpChallengeData = 443,
	ClaimPvpChallengeWeeklyReward = 444,
	GetPersonalMightStats = 445,
	AuctionGetLoadoutOffers = 446,
	AuctionBuyLoadoutOffer = 447,
	AccountDeletionRequest = 448,
	AccountReactivationRequest = 449,
	GetModerationEscalationDefiniton = 450,
	EventBasedPopupAddSeen = 451,
	GetItemKillHistory = 452,
	GetVanityConsumables = 453,
	EquipKillEmote = 454,
	ChangeKillEmotePlayOnKnockdownSetting = 455,
	BuyVanityConsumableCharges = 456,
	ReclaimVanityItem = 457,
	GetArenaRankings = 458,
	GetCrystalLeagueStatistics = 459,
	SendOptionsLog = 460,
	SendControlsOptionsLog = 461,
	MistsUseImmediateReturnExit = 462,
	MistsUseStaticEntrance = 463,
	MistsUseCityRoadsEntrance = 464,
	ChangeNewGuildMemberMail = 465,
	GetNewGuildMemberMail = 466,
	ChangeGuildFactionAllegiance = 467,
	GetGuildFactionAllegiance = 468,
	GuildBannerChange = 469,
	GuildGetOptionalStats = 470,
	GuildSetOptionalStats = 471,
	GetPlayerInfoForStalk = 472,
	PayGoldForCharacterTypeChange = 473,
	QuickSellAuctionQueryAction = 474,
	QuickSellAuctionSellAction = 475,
	FcmTokenToServer = 476,
	ApnsTokenToServer = 477,
	DeathRecap = 478,
	AuctionFetchFinishedAuctions = 479,
	AbortAuctionFetchFinishedAuctions = 480,
	RequestLegendaryEvenHistory = 481,
	PartyAnswerStartHuntRequest = 482,
	HuntAbort = 483,
	UseFindTrackSpellFromItemPrepare = 484,
	InteractWithTrackStart = 485,
	InteractWithTrackCancel = 486,
	TerritoryRaidStart = 487,
	TerritoryRaidCancel = 488,
	TerritoryClaimRaidedRawEnergyCrystalResult = 489,
	GvGSeasonPlayerGuildParticipationDetails = 490,
	DailyMightBonus = 491,
	ClaimDailyMightBonus = 492,
	GetFortificationGroupInfo = 493,
	UpgradeFortificationGroup = 494,
	GetClusterActivityChestEstimates = 495,
}

