using AEBestGatePath.Core.Parsers;

namespace AEBestGatePath.Test;

public class GuildListParserTests
{
    [Fact]
    public void ParseSampleData()
    {
        var parseSlice = @"	 	 
 Historical graphs    Request to join        List bases and fleets    Report
 	
 	Guild Members	 
 
 	
 
ID
Title/Rank
Player
Level
Economy
227256	CLS	Creeda	205.48	18,266
51835	with sunglasses 😎	Helios	194.71	18,246
3725	Ethicist	Philosopher Cody	190.57	2,046
12433	Hololive+VSPO Votary	Annihilator	175.17	13,796
859	with Prada Gloves 🧤	Klaus	174.20	15,991
13452	🏞	Maple	159.71	9,876";
        
        var playerList = GuildListParser.ParsePlayerListFromGuildPaste(parseSlice);
        
        Assert.NotEmpty(playerList);
        Assert.Equal(playerList, new List<(int id, string name)>
        {
            (227256, "Creeda"),
            (51835, "Helios"),
            (3725, "Philosopher Cody"),
            (12433, "Annihilator"),
            (859, "Klaus"),
            (13452, "Maple"),
        });
        
    }
    [Fact]
    public void ParseLargeData()
    {
        var parseSlice = @"	 	  
Ranks (707)
 
 
 
Updates
 
 
 
Rules
 
 
 
Help
 
 
 
Tables
 
 
 
Portal
 
 
 
Forum
 
 
 
Support
 
 
 
Logout
 
14 Jan 2025, 06:22:27
 
 
Account
 
 	300080	 
 
Messages
 
 	0 New	 
 
Credits
 
 	41,445	 
 
Board
 
 	0 New	 
Server: Alpha ▼	
  [{V}] HariSeldon vs. [QUAD] koko losses: 126,140 / 10,200    [{V}] HariSeldon vs. [QUAD] koko losses: 153,645 / 200
 
 
Bases
 
 
Map
 
 
Fleets
 
 
Empire
 
 
Commanders
 
 
Guild
 
 
 
 
 
 
 
 
 
 
 
Tutorial
 
 	
 	actually four guilds	 
 
 	
 
Guild: 12530

Tag: [QUAD]

Guild Master: Louise Vallière

Members: 110

Level: 296.52 (Rank 4)

Economy: 813,292 (Rank 4)
Fleet: 7,518,856,365 (Rank 4)

Guild Created: 85 Days
	[CLS] | [GRLL] | [Anime] | [OOTW]

MDP:
[CRUEL]

WAR:
[SHLD] [SPuD] [{V}]

 
 	 	 
 Historical graphs    Request to join        List bases and fleets    Report
 	
 	Guild Members	 
 
 	
 
ID
Title/Rank
Player
Level
Economy
227256	CLS	Creeda	205.48	18,266
51835	with sunglasses 😎	Helios	194.71	18,246
3725	Ethicist	Philosopher Cody	190.57	2,046
12433	Hololive+VSPO Votary	Annihilator	175.17	13,796
859	with Prada Gloves 🧤	Klaus	174.20	15,991
13452	🏞	Maple	159.71	9,876
228	CLS	Sir Heiko	154.27	5,881
222494	without a gun	Sniper	152.47	12,272
26685	Double Vision	Shadows	151.46	8,226
268212	CLS (Ni)	GaiaForce (Ni)	150.76	11,204
65397	CLS	Phoenix Hawk	150.06	8,610
279139	Feed me anything	Corvidae	148.85	8,520
134	OOTW GM	Hardgrave	148.74	11,714
71904	Lost my GPS	Pathfinder	147.85	4,760
201749	Golden Path to	JJE	147.66	14,517
238439		Minister Of Rejects	146.27	12,960
2297	Score⚽Goal	Gejl	145.52	14,532
246084	Job Opening for	Angry Clown (Ni)	144.64	7,900
130854	CLS VGM	Edward Longshanks	144.25	8,549
235981	McD	MadOwnage!	143.79	14,136
279577	Sharp	razorfish	142.45	9,846
98478	CLS ( Ni )	KevinC (Ni) CLS	140.66	4,815
241179	loco	koko	140.31	5,089
27708	Extra	Mot	139.97	14,089
171725	Fan of Star Wars	Lucasjuh	139.06	3,963
10830	Cannot type /	Baxslash	135.42	3,437
171439	Only IN no Out🍔	Buegur	134.49	13,254
296446	HOT 🔥	Horchata	134.42	7,932
93315	Spells Shampoo	Shmoo	131.70	4,630
59185	Looney Tunes	A RabidDragoon	131.24	13,761
279281	CLS	DOOM	130.24	6,971
24703	The nine 9⃣	Nazgûl	129.80	9,828
1975	vp ams	quail 2.0	129.06	17,519
171442	Gorgo the	Gorgo	128.70	11,246
31563	Life beyond	Death7270	124.45	10,842
206205	Doctor	Zev	123.82	12,933
296576	🧸ྀི	Ziggy(BS)	123.66	6,263
274010		Zhao Yun	122.65	15,829
14176	Anime GM	Louise Vallière	120.19	17,096
274311		HarryTiger	119.83	13,875
196083		Raptor RQ/CT	114.93	11,703
295779	Sun Burnt	Red Momma	113.40	15,298
5894		Neo	112.81	6,447
3581	Ai powered	-LUE- Elmnt80	109.07	4,820
298204	CoRsAiR	NightOwl280	108.59	6,254
298693		Bearded Angel	106.17	10,107
78389		gundamwing3	103.45	3,705
293278	Melt Down ⚛	AcidCore	100.67	13,667
292761	⛛	MAYAN Tiberas RQ/CT	97.23	10,655
273542		Gatorbait 2	96.96	6,281
75263		Royal Canadian Corp.	93.95	10,320
276558	Working for ElonMusk	ShadowX {Anime}	91.06	6,016
159277	Has no fleet	Aether	90.57	10,828
298525	Owe ME	A Cup of Tea	90.47	7,488
273181		Confector de Caeli	81.91	4,865
298680	👻Very EVIL 😈	Green Alien CARTEL ®	81.61	4,632
298843	Touch Down 🏈	- RaVeN -	81.07	8,778
298422	Son of Oberon	corwin de amber	76.53	2,834
299320		Chosenone	75.84	6,595
297884		Darth Splitfoot	74.71	6,866
298614		Mr Chance	74.70	3,911
299350	I Am The	Synod	71.73	4,516
299102	Captain	James Langley	65.16	6,313
299579	Off Road 🚙	Forrester	64.04	8,985
299634	LostMyFlashlight🔦	Darkfallen	60.01	8,677
299621	Global Warming	Koala boy	59.97	9,047
299603	Sold Out 🥩	Angus	59.23	9,659
299573	Never Again	Ashley	57.60	9,107
299527	VGM GRLL	wolfie5	57.57	7,403
299629	Who wants to act	Tomcruiser	57.57	8,768
299515	Digital Upgrade	A.C.T.V.	57.36	1,776
299676	Dragon 🐲 Ball ⚽	Goku	57.02	8,880
299610	Scary👻 Brain 🧠	Braveheart	56.98	8,842
299717	Another	Fool	55.88	5,801
299584	Anti	Proton	55.64	8,812
299572	Fingers	Sticky	54.56	8,568
299375		Meow	54.24	7,765
299677	Hairy	JohnWick	52.73	8,083
299571	Tiny Werewolf	lycan1	51.47	6,679
299766	Dolphin 🐬Octopus 🐙	Bird Dog	50.50	5,351
299708		Artur	48.11	7,046
299705		Kalya	47.76	6,607
299854	GARY	Gary	45.64	6,050
299849	I lov My bottle🍾of	Chani	44.84	6,415
299698	Looking for	Dr. Jones	44.42	6,094
299850	John	Dalton	43.81	5,831
299942	Fine Figure of a Man	Trapper	42.72	3,503
299941	Green House🏡Effect	Cowpower	42.28	5,351
299891	Good till Dec 2024	Pr!ngl£s	42.08	3,292
299892	Sensational	JUCAPETA	41.78	2,998
299958	Magical 🧝‍♂️	Timcanpy	39.10	2,270
299680	SITH	Lordvader	38.98	1,593
300048	TROLL 🃏	Axel27	38.94	3,426
300027		Scotch Bingington	38.16	2,238
299886	World of Blizzard	Cyndara	36.32	1,574
299957	Episode V	Maverick_pt	35.77	2,019
300044	Disney Plus➕	The Cylons	31.12	1,654
299651	In training	conquistador	30.98	1,134
299765	I sell Grain	Khirkre	30.08	1,132
300039	Hallowed	The Doci	29.94	2,207
300033	Stolen License	Renegade	29.26	1,734
299952	Cut like a	cuchillo	28.61	508
300025	Pay me to be an	Artemis	28.36	1,120
300052	Soldier	TOPs	28.14	1,240
300065		Cub	28.11	1,994
300080	Number Go Up	moeta	27.87	2,172
300059		Rat Brainz	20.75	585
300096		Cuyito	18.10	720
300082		Sunshine	15.49	407
300094		Cam76	9.11	56
 
 	 	 ";
        
        var playerList = GuildListParser.ParsePlayerListFromGuildPaste(parseSlice);
        
        Assert.NotEmpty(playerList);
        
    }
}