using System.Collections;
using AEBestGatePath.Core;
using AEBestGatePath.Core.Parsers;

namespace AEBestGatePath.Test;

public class BasePasteParserTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
	    // Recorded data, unoccupied
        yield return [ """
                        
                       Ranks (697)
                        
                        
                        
                       Updates
                        
                        
                        
                       Rules
                        
                        
                        
                       Help
                        
                        
                        
                       Tables
                        
                        
                        
                       Portal
                        
                        
                        
                       Forum
                        
                        
                        
                       Support
                        
                        
                        
                       Logout
                        
                       17 Jan 2025, 19:54:51
                        
                        
                       Account
                        
                        	300080	 
                        
                       Messages
                        
                        	0 New	 
                        
                       Credits
                        
                        	56,674	 
                        
                       Board
                        
                        	0 New	 
                       Server: Alpha ▼	
                         [SHLD] V for Vig90 vs. [CRUEL] Thrawn losses: 560 / 1,500    [{V}] HariSeldon vs. [CRUEL] Rabbit losses: 13,825 / 29,355
                        
                        
                       Bases
                        
                        
                       Map
                        
                        
                       Fleets
                        
                        
                       Empire
                        
                        
                       Commanders
                        
                        
                       Guild
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                       Tutorial
                        
                        	
                        	Guadalcanal	 
                        
                        	
                        
                       Location: A22:26:60:11
                       Astro Type: Moon
                       Terrain: Oceanic
                       Area: 71
                       Solar Energy: 4
                       Fertility: 8
                        	
                        	Resources	 
                        
                        	
                        
                       Metal	1
                       Gas	2
                       Crystals	0
                        
                        	 	 
                       
                        	
                        	Base information	 
                        
                        	
                        
                       Base Owner:   [CRUEL] Ivan
                       Unrest:   70%
                        
                        	 	 
                        
                        
                        	
                        	Base Commander: Morgan Uranus (Tactical 15)	 
                        
                       Recorded data from 5 hour(s) ago.
                       
                        Move fleet here    Trade here
                        	
                        	Fleets	 
                        
                        	
                        
                       Fleet
                       Player
                       Arrival
                       Size
                       Recorded data	[CRUEL] Ivan		2,000
                        
                        	 	 
                        	 	 
                        	
                       Structures	Level	Structures	Level	Defenses (100%)	Units
                       Urban Structures
                       Solar Plants
                       Fusion Plants
                       Antimatter Plants
                       Orbital Plants
                       Research Labs
                       Metal Refineries
                       Robotic Factories
                       Shipyards
                       Orbital Shipyards
                       Spaceports
                       Nanite Factories
                       Android Factories
                       Economic Centers
                       Terraform
                       Multi-Level Platforms
                       Orbital Base
                       Biosphere Modification
                       30
                       15
                       16
                       14
                       10
                       28
                       30
                       30
                       30
                       11
                       30
                       22
                       15
                       23
                       24
                       13
                       13
                       2
                       Command Centers
                       Jump Gate
                       20
                       15
                       Deflection Shields
                       Planetary Shield
                       Planetary Ring
                       5 / 5
                       60 / 60
                       50 / 50
                        
                        	 	 
                       """, new BaseParser.ParsedBase("Ivan", "Guadalcanal", new Astro("A22:26:60:11")) { GuildTag = "CRUEL", LastSeen = new TimeSpan(5, 0, 0) } ];
        
        // Recorded data, Occupied
        yield return [ """
                        
                       Ranks (697)
                        
                        
                        
                       Updates
                        
                        
                        
                       Rules
                        
                        
                        
                       Help
                        
                        
                        
                       Tables
                        
                        
                        
                       Portal
                        
                        
                        
                       Forum
                        
                        
                        
                       Support
                        
                        
                        
                       Logout
                        
                       17 Jan 2025, 20:10:08
                        
                        
                       Account
                        
                        	300080	 
                        
                       Messages
                        
                        	0 New	 
                        
                       Credits
                        
                        	56,674	 
                        
                       Board
                        
                        	0 New	 
                       Server: Alpha ▼	
                         [SHLD] V for Vig90 vs. [CRUEL] Thrawn losses: 560 / 1,500    [{V}] HariSeldon vs. [CRUEL] Rabbit losses: 13,825 / 29,355
                        
                        
                       Bases
                        
                        
                       Map
                        
                        
                       Fleets
                        
                        
                       Empire
                        
                        
                       Commanders
                        
                        
                       Guild
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                        
                       Tutorial
                        
                        	
                        	07 Alpha 20	 
                        
                        	
                        
                       Location: A07:42:22:42
                       Astro Type: Moon
                       Terrain: Rocky
                       Area: 75
                       Solar Energy: 1
                       Fertility: 6
                        	
                        	Resources	 
                        
                        	
                        
                       Metal	3
                       Gas	3
                       Crystals	0
                        
                        	 	 
                       
                        	
                        	Base information	 
                        
                        	
                        
                       Base Owner:   Argus
                       Occupier:   [SHLD] Commander VoN
                       Base Stability:   91%
                        
                        	 	 
                        
                        	 	 
                       Recorded data from 17 hour(s) ago.
                       
                        Move fleet here    Trade here
                        	
                        	Fleets	 
                        
                        	
                        
                       Fleet
                       Player
                       Arrival
                       Size
                       Recorded data	[SHLD] Commander VoN		20,000
                        
                        	 	 
                        	 	 
                        	
                       Structures	Level	Structures	Level	Defenses (0%)	Units
                       Urban Structures
                       Gas Plants
                       Fusion Plants
                       Antimatter Plants
                       Orbital Plants
                       Metal Refineries
                       Robotic Factories
                       Shipyards
                       Orbital Shipyards
                       Spaceports
                       Nanite Factories
                       Android Factories
                       Economic Centers
                       Terraform
                       Multi-Level Platforms
                       Orbital Base
                       Biosphere Modification
                       28
                       24
                       22
                       11
                       5
                       34
                       29
                       27
                       13
                       26
                       24
                       17
                       16
                       20
                       10
                       12
                       1
                       Command Centers
                       Jump Gate
                       4
                       20
                       Planetary Shield
                       Planetary Ring
                       0 / 15
                       0 / 55
                        
                        	 	 
                       
                       """, new BaseParser.ParsedBase("Argus", "07 Alpha 20", new Astro("A07:42:22:42", 20)) { Occupied = true, LastSeen = new TimeSpan(17, 0, 0)}];
        
        // actual data, unoccupied
        yield return
	        ["""
	          
	         Ranks (697)
	          
	          
	          
	         Updates
	          
	          
	          
	         Rules
	          
	          
	          
	         Help
	          
	          
	          
	         Tables
	          
	          
	          
	         Portal
	          
	          
	          
	         Forum
	          
	          
	          
	         Support
	          
	          
	          
	         Logout
	          
	         17 Jan 2025, 20:14:52
	          
	          
	         Account
	          
	          	300080	 
	          
	         Messages
	          
	          	0 New	 
	          
	         Credits
	          
	          	58,870	 
	          
	         Board
	          
	          	2 New	 
	         Server: Alpha ▼	
	           [SHLD] Vent vs. [SLDF] Ice Hellion losses: 78,065 / 10,000    [SHLD] Vent vs. [SLDF] Ice Hellion losses: 180,290 / 79,000
	          
	          
	         Bases
	          
	          
	         Map
	          
	          
	         Fleets
	          
	          
	         Empire
	          
	          
	         Commanders
	          
	          
	         Guild
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	         Tutorial
	          
	          	 	 
	          	
	         Base Name	Location	Area	Energy	Population	Trade Routes
	         Atlantis	A70:39:64:21	285/290	651/729	296/302	7/7
	          
	          	 	 
	          	
	          	Atlantis	 
	          
	          	
	          
	         Astro Type: Moon
	         Terrain: Rocky
	         Area: 75
	         Solar Energy: 3
	         Fertility: 7
	          	
	          	Resources	 
	          
	          	
	          
	         Metal	3
	         Gas	2
	         Crystals	0
	          
	          	 	 
	         
	          	
	          	Base information	 
	          
	          	
	          
	         Base Owner	[QUAD] Klaus
	          
	         Economy	319	cred./h
	         Owner Income	319	cred./h
	          
	         Construction	710	cred./h
	         Production	958	cred./h
	         Research	240	cred./h
	          
	          	 	 
	          
	          
	          	
	          	Base Commander: Nina Dobrev (Logistics 18)	 
	          
	         Minimum pillage 54,150 credits.
	         
	          Move fleet here
	          	
	          	Fleets	 
	          
	          	
	          
	         Fleet
	         Player
	         Arrival
	         Size
	         ⭐⭐	[QUAD] Corvidae		422,911,750
	         ★ Base Defence ★ 8	[QUAD] Pathfinder		399,959,025
	         SDFN-3	[QUAD] GaiaForce (Ni)		276,304,675
	         Stargazer	[QUAD] Phoenix Hawk		215,694,605
	         ︻┳テ=一	[QUAD] MadOwnage!		207,857,880
	         Fleet 1410	[QUAD] KevinC (Ni) CLS		171,137,565
	         Bright Moonlight	[QUAD] Sir Heiko		160,820,000
	         Classis Italica	[QUAD] Edward Longshanks		151,468,655
	         Expeditionary 44	[QUAD] A RabidDragoon		133,091,210
	         MothBall 25	[QUAD] NightOwl280		122,380,425
	         boingggg 16	[QUAD] Ziggy(BS)		121,644,220
	         Fleet 1501	[QUAD] Raptor RQ/CT		116,602,025
	         Fleet 4808	[QUAD] Mot		93,471,665
	         Scout 158	[QUAD] Buegur		74,849,410
	         Fleet 361	[QUAD] Nazgûl		62,864,345
	         ❌	[QUAD] Gorgo		56,508,215
	         Fleet 558	[QUAD] quail 2.0		48,681,820
	         Fleet 1094	[QUAD] Hardgrave		42,193,665
	         AQUA	[QUAD] Zev		40,798,290
	         Sparticus 954	[QUAD] MAYAN Tiberas RQ/CT		40,048,370
	         Fleet 1325	[QUAD] Minister Of Rejects		36,509,510
	         Fleet 126	[QUAD] - RaVeN -		33,831,500
	         Fleet 906	[QUAD] DOOM		29,946,765
	         Fleet 32	[QUAD] corwin de amber		28,200,790
	         MOVING TO Triad 122	[QUAD] Mr Chance		26,238,000
	         Fleet 105	[QUAD] Chosenone		24,993,660
	         Blob Squad 1	[QUAD] Shmoo		24,070,720
	         Fleet 281	[QUAD] Sniper		23,960,670
	         Fleet 352	[QUAD] AcidCore		22,966,480
	         Fleet 69	[QUAD] JJE		21,642,190
	         ⭐⭐	[QUAD] HarryTiger		21,527,100
	         Fleet 91	[QUAD] Louise Vallière		12,756,505
	         🐙 64	[QUAD] A Cup of Tea		12,216,885
	         Fleet 1129	[QUAD] Aether		9,194,350
	         Fleet 28	[QUAD] A.C.T.V.		6,435,440
	         Fleet 117	[QUAD] Fool		4,904,935
	         Fleet 49	[QUAD] Bird Dog		3,539,500
	         Fleet 78	[QUAD] James Langley		3,038,500
	         Fleet 73	[CRUEL] ShadowX {Anime}		2,801,630
	         Fleet 75636	[QUAD] Creeda		2,403,200
	         Fleet 54	[QUAD] lycan1		2,210,600
	         Kinetic Front	[QUAD] Neo		1,605,000
	         Enterprise Group 80	[QUAD] Royal Canadian Corp.		1,433,120
	         💯💯💯💯	[QUAD] Cowpower		1,323,180
	         Fleet 29	[QUAD] Pr!ngl£s		1,178,400
	         Fleet 364	[QUAD] Baxslash		977,500
	         Fleet 19	[QUAD] Timcanpy		869,560
	         Fleet 77	[QUAD] Cyndara		483,885
	         Fleet 14	[QUAD] Tyranitar		395,670
	         Fleet 1124	[QUAD] Angry Clown (Ni)		244,460
	         Astrix 1	[QUAD] TOPs		225,620
	         Fleet 111	[QUAD] cuchillo		216,080
	         Fleet 1	[QUAD] Cub		149,960
	         Fleet 100	[QUAD] JUCAPETA		110,880
	         Fleet 79	[QUAD] Annihilator		15,000
	         YaHelloOldBlob 70	[CRUEL] ogpauly		10,000
	         Fleet 228	[QUAD] wolfie5		7,195
	         Fleet 113	[QUAD] Axel27		6,410
	         |-o-| pew pew	[QUAD] Scotch Bingington		2,240
	         Fleet 6022	[QUAD] razorfish		220
	         ○○○ 1	[CRUEL] Kyo		30
	         Fleet 1795	[QUAD] Buegur	0:00:39	27,000
	         Scout 1 s	[QUAD] Ziggy(BS)	0:03:00	40
	         Popsicles 1	[QUAD] Red Momma	0:25:08	40
	         Popsicles 3	[QUAD] Red Momma	0:44:22	40
	         Fleet 1798	[QUAD] Buegur	0:58:18	30,000
	         SDFN-3 36	[QUAD] GaiaForce (Ni)	1:39:13	30,000
	         Fleet 188	[QUAD] Shmoo	1:59:09	37,500
	         Fleet 1811	[QUAD] Buegur	2:09:44	30,000
	         Fleet 1813	[QUAD] Buegur	2:12:12	30,000
	         ☠️ 78	[QUAD] Zev	2:56:58	65,000
	         ☠️ 79	[QUAD] Zev	2:57:07	100,000
	         Fleet 815	[QUAD] Nazgûl	6:12:58	52,220
	         fleet 598	[QUAD] Red Momma	6:46:47	21,000
	         fleet 599	[QUAD] Red Momma	6:46:58	21,000
	         Fleet 1892	[QUAD] KevinC (Ni) CLS	7:09:33	32,964,440
	         Fleet 1796	[QUAD] Buegur	7:13:45	120,000
	         ☠️ 80	[QUAD] Zev	10:02:47	100,000
	         ☠️ 81	[QUAD] Zev	10:02:55	105,000
	         Fleet 50	[QUAD] Trapper	10:07:47	60,620
	         Fleet 1810	[QUAD] Buegur	10:09:42	30,000
	         Fleet 1609	[QUAD] koko	11:19:45	60,000
	         Fleet 1253	[QUAD] Angry Clown (Ni)	11:24:14	5,400
	         |-o-| pew pew 1	[QUAD] Scotch Bingington	11:39:11	466,800
	         fleet 600	[QUAD] Red Momma	12:20:31	21,000
	         fleet 601	[QUAD] Red Momma	12:20:41	21,000
	         fleet 602	[QUAD] Red Momma	12:20:53	21,000
	         fleet 603	[QUAD] Red Momma	12:21:03	21,000
	         fleet 604	[QUAD] Red Momma	12:21:13	21,000
	         fleet 605	[QUAD] Red Momma	12:21:23	21,000
	         fleet 606	[QUAD] Red Momma	12:21:35	21,000
	         fleet 607	[QUAD] Red Momma	12:21:45	21,000
	         fleet 608	[QUAD] Red Momma	12:21:56	21,000
	         fleet 609	[QUAD] Red Momma	12:22:07	21,000
	         fleet 610	[QUAD] Red Momma	12:22:17	21,000
	         fleet 611	[QUAD] Red Momma	12:22:27	21,000
	         fleet 612	[QUAD] Red Momma	12:22:37	21,000
	         fleet 613	[QUAD] Red Momma	12:22:48	21,000
	         fleet 614	[QUAD] Red Momma	12:22:58	21,000
	         fleet 615	[QUAD] Red Momma	12:23:09	21,000
	         fleet 616	[QUAD] Red Momma	12:23:19	21,000
	         fleet 617	[QUAD] Red Momma	12:23:33	21,000
	         fleet 618	[QUAD] Red Momma	12:23:43	21,000
	         fleet 619	[QUAD] Red Momma	12:23:52	21,000
	         fleet 620	[QUAD] Red Momma	12:24:02	21,000
	         Fleet 219	[QUAD] Fool	12:35:24	321,000
	         Fleet 814	[QUAD] Nazgûl	12:54:44	45,320
	         Fleet 1250	[QUAD] Angry Clown (Ni)	13:24:54	10,000
	         Fleet 1610	[QUAD] koko	13:55:18	60,000
	         Fleet 1870	[QUAD] KevinC (Ni) CLS	15:42:57	86,306,485
	         Fleet 1612	[QUAD] koko	15:58:55	60,000
	         Fleet 921	[QUAD] wolfie5	16:52:01	7,140
	         ☠️ 82	[QUAD] Zev	17:08:35	110,000
	         ☠️ 83	[QUAD] Zev	17:08:41	105,000
	         Fleet 822	[QUAD] Nazgûl	17:42:19	57,190
	         Fleet 353	[QUAD] Shmoo	18:21:09	20,200
	         Fleet 940	[QUAD] wolfie5	20:25:47	38,380
	         Fleet 1246	[QUAD] Angry Clown (Ni)	21:50:17	10,000
	         Fleet 829	[QUAD] Nazgûl	25:34:03	33,000
	         Fleet 1248	[QUAD] Angry Clown (Ni)	27:40:43	10,000
	         Fleet 824	[QUAD] Nazgûl	27:46:14	55,000
	         Fleet 825	[QUAD] Nazgûl	27:46:26	56,500
	         Fleet 826	[QUAD] Nazgûl	27:46:51	33,000
	         Fleet 828	[QUAD] Nazgûl	27:47:08	33,000
	         Fleet 831	[QUAD] Nazgûl	27:53:25	33,000
	         Fleet 1255	[QUAD] Angry Clown (Ni)	29:31:41	10,770
	         Fleet 823	[QUAD] Nazgûl	30:30:30	33,000
	         Fleet 827	[QUAD] Nazgûl	30:31:24	44,000
	         Fleet 832	[QUAD] Nazgûl	30:38:00	26,310
	         Fleet 219	[QUAD] Shmoo	31:11:07	125,000
	         Fleet 1148	[QUAD] Aether	32:09:58	250,000
	         Fleet 1247	[QUAD] Angry Clown (Ni)	34:55:51	10,000
	         Fleet 830	[QUAD] Nazgûl	37:56:07	33,000
	         Fleet 1144	[QUAD] Angry Clown (Ni)	48:15:05	10,000
	         Fleet 939	[QUAD] wolfie5	55:33:33	4,720
	         Fleet 1252	[QUAD] Angry Clown (Ni)	56:23:31	14,000
	         Fleet 105	[QUAD] James Langley	65:23:09	220,000
	         Fleet 929	[QUAD] wolfie5	77:41:36	4,600
	         Fleet 261	[QUAD] NightOwl280	93:16:04	45,000
	         Fleet 262	[QUAD] NightOwl280	93:16:22	21,600
	         Fleet 97	[QUAD] Shmoo	108:50:55	25,000
	         Fleet 98	[QUAD] Shmoo	109:12:04	5,000
	         Fleet 17	[QUAD] Shmoo	110:39:19	165,000
	         Fleet 100	[QUAD] Shmoo	112:35:53	5,000
	         Fleet 101	[QUAD] Shmoo	123:01:52	45,000
	         Fleet 122	[QUAD] Shmoo	137:03:51	5,000
	         Fleet 123	[QUAD] Shmoo	150:17:14	5,000
	         Fleet 125	[QUAD] Shmoo	163:10:58	25,000
	         Fleet 142	[QUAD] Shmoo	172:59:45	30,000
	         Fleet 129	[QUAD] Shmoo	173:00:11	50,000
	         Fleet 143	[QUAD] Shmoo	180:13:25	55,000
	         Fleet 816	[QUAD] Nazgûl	193:46:04	37,400
	          
	          
	          	
	          	Show fleets summary	 
	          
	          	 	 
	          	
	         Structures	Level	Structures	Level	Defenses (100%)	Units
	         Urban Structures
	         Solar Plants
	         Fusion Plants
	         Antimatter Plants
	         Orbital Plants
	         Research Labs
	         Metal Refineries
	         Robotic Factories
	         Shipyards
	         Orbital Shipyards
	         Spaceports
	         Nanite Factories
	         Android Factories
	         Economic Centers
	         Terraform
	         Multi-Level Platforms
	         Orbital Base
	         Biosphere Modification
	         26
	         11
	         15
	         11
	         5
	         20
	         33
	         28
	         28
	         11
	         30
	         21
	         16
	         21
	         21
	         11
	         12
	         1
	         Command Centers
	         Jump Gate
	         24
	         20
	         Planetary Ring
	         5 / 5
	          
	          	 	 
	         Rogue 90 arrived at Dirty Deeds (A70:95:61:20).20:14
	         """, new BaseParser.ParsedBase("Klaus", "Atlantis", new Astro("A70:39:64:21", 20, 18)) { GuildTag = "QUAD" }];
        // actual data, occupied
        yield return
	        ["""
	          
	         Ranks (697)
	          
	          
	          
	         Updates
	          
	          
	          
	         Rules
	          
	          
	          
	         Help
	          
	          
	          
	         Tables
	          
	          
	          
	         Portal
	          
	          
	          
	         Forum
	          
	          
	          
	         Support
	          
	          
	          
	         Logout
	          
	         17 Jan 2025, 20:22:08
	          
	          
	         Account
	          
	          	300080	 
	          
	         Messages
	          
	          	0 New	 
	          
	         Credits
	          
	          	58,870	 
	          
	         Board
	          
	          	4 New	 
	         Server: Alpha ▼	
	           [SHLD] Foladorn Mac Datho vs. [CRUEL] Hero losses: 1,500 / 4,890    [SHLD] Vent vs. [SLDF] Ice Hellion losses: 78,065 / 10,000
	          
	          
	         Bases
	          
	          
	         Map
	          
	          
	         Fleets
	          
	          
	         Empire
	          
	          
	         Commanders
	          
	          
	         Guild
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	         Tutorial
	          
	          	 	 
	          	
	         Base Name	Location	Area	Energy	Population	Trade Routes
	         09-aoe-rm/nm-w13	A09:55:59:10	275/285	923/979	288/323	0/7
	          
	          	 	 
	          	
	          	09-aoe-rm/nm-w13	 
	          
	          	
	          
	         Astro Type: Planet
	         Terrain: Rocky
	         Area: 85
	         Solar Energy: 4
	         Fertility: 7
	          	
	          	Resources	 
	          
	          	
	          
	         Metal	3
	         Gas	2
	         Crystals	0
	          
	          	 	 
	         
	          	
	          	Base information	 
	          
	          	
	          
	         Base Owner	[QUAD] DOOM
	         Occupier	[SHLD] Bruskie
	         Unrest	100%	
	          
	         Economy	287	cred./h
	         Owner Income	201	cred./h
	          
	         Construction	369	cred./h
	         Production	480	cred./h
	         Research	247	cred./h
	          
	          	 	 
	          
	          	 	 
	         This base was pillaged 17 hour(s) ago.

	         55 credits in space debris.
	         
	          Move fleet here    Trade here
	          	
	          	Fleets	 
	          
	          	
	          
	         Fleet
	         Player
	         Arrival
	         Size
	         Fleet 12346	[SHLD] Bruskie		219,955
	          
	          	 	 
	          	 	 
	          	
	         Structures	Level	Structures	Level	Defenses (0%)	Units
	         Urban Structures
	         Solar Plants
	         Fusion Plants
	         Antimatter Plants
	         Orbital Plants
	         Research Labs
	         Metal Refineries
	         Robotic Factories
	         Shipyards
	         Orbital Shipyards
	         Spaceports
	         Nanite Factories
	         Android Factories
	         Economic Centers
	         Terraform
	         Multi-Level Platforms
	         Orbital Base
	         Biosphere Modification
	         29
	         16
	         10
	         13
	         8
	         28
	         25
	         12
	         26
	         7
	         30
	         21
	         15
	         22
	         20
	         10
	         12
	         2
	         Command Centers
	         Jump Gate
	         20
	         15
	         Planetary Shield
	         Planetary Ring
	         0 / 30
	         0 / 60
	          
	          	 	 
	         """, new BaseParser.ParsedBase("DOOM", "09-aoe-rm/nm-w13", new Astro("A09:55:59:10")) { GuildTag = "QUAD", Occupied = true }];
        // recorded data, no jump gate
        yield return
	        ["""
	          
	         Ranks (697)
	          
	          
	          
	         Updates
	          
	          
	          
	         Rules
	          
	          
	          
	         Help
	          
	          
	          
	         Tables
	          
	          
	          
	         Portal
	          
	          
	          
	         Forum
	          
	          
	          
	         Support
	          
	          
	          
	         Logout
	          
	         17 Jan 2025, 20:24:27
	          
	          
	         Account
	          
	          	300080	 
	          
	         Messages
	          
	          	0 New	 
	          
	         Credits
	          
	          	58,870	 
	          
	         Board
	          
	          	4 New	 
	         Server: Alpha ▼	
	           [SHLD] Foladorn Mac Datho vs. [CRUEL] Hero losses: 1,500 / 4,890    [SHLD] Vent vs. [SLDF] Ice Hellion losses: 78,065 / 10,000
	          
	          
	         Bases
	          
	          
	         Map
	          
	          
	         Fleets
	          
	          
	         Empire
	          
	          
	         Commanders
	          
	          
	         Guild
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	         Tutorial
	          
	          	
	          	9-A54 *	 
	          
	          	
	          
	         Location: A54:47:82:10
	         Astro Type: Planet
	         Terrain: Rocky
	         Area: 85
	         Solar Energy: 4
	         Fertility: 5
	          	
	          	Resources	 
	          
	          	
	          
	         Metal	3
	         Gas	2
	         Crystals	0
	          
	          	 	 
	         
	          	
	          	Base information	 
	          
	          	
	          
	         Base Owner:   [BOB] .PeteR.
	          
	          	 	 
	          
	          
	          	
	          	Base Commander: 9 (Defense 7)	 
	          
	         Recorded data from 1 day(s) ago.

	         4 credits in space debris.
	         
	          Move fleet here    Trade here
	          	
	          	Fleets	 
	          
	          	
	          
	         Fleet
	         Player
	         Arrival
	         Size
	         Recorded data	[BOB] .PeteR.		100
	          
	          	 	 
	          	 	 
	          	
	         Structures	Level	Structures	Level	Defenses (100%)	Units
	         Urban Structures
	         Solar Plants
	         Fusion Plants
	         Research Labs
	         Metal Refineries
	         Robotic Factories
	         Shipyards
	         Spaceports
	         Nanite Factories
	         Economic Centers
	         Terraform
	         Orbital Base
	         19
	         9
	         2
	         6
	         22
	         18
	         19
	         5
	         5
	         5
	         5
	         5
	          
	          	 	 
	         """, new BaseParser.ParsedBase(".PeteR.", "9-A54 *", new Astro("A54:47:82:10")) { GuildTag = "BOB", LastSeen = new TimeSpan(1, 0, 0, 0)}];
        // actual data, no jump gate
        yield return
	        ["""
	          
	         Ranks (697)
	          
	          
	          
	         Updates
	          
	          
	          
	         Rules
	          
	          
	          
	         Help
	          
	          
	          
	         Tables
	          
	          
	          
	         Portal
	          
	          
	          
	         Forum
	          
	          
	          
	         Support
	          
	          
	          
	         Logout
	          
	         17 Jan 2025, 20:26:07
	          
	          
	         Account
	          
	          	300080	 
	          
	         Messages
	          
	          	0 New	 
	          
	         Credits
	          
	          	58,870	 
	          
	         Board
	          
	          	4 New	 
	         Server: Alpha ▼	
	           [SHLD] Foladorn Mac Datho vs. [CRUEL] Hero losses: 1,500 / 4,890    [SHLD] Vent vs. [SLDF] Ice Hellion losses: 78,065 / 10,000
	          
	          
	         Bases
	          
	          
	         Map
	          
	          
	         Fleets
	          
	          
	         Empire
	          
	          
	         Commanders
	          
	          
	         Guild
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	          
	         Tutorial
	          
	          	 	 
	          	
	         
	          Aiur 
	         Location	Area	Energy	Population	Trade Routes
	          
	         Rename
	          
	          
	         Disband
	          
	         A70:33:63:10	103/105	88/97	86/95	3/3
	          
	          
	          	
	          	
	          
	         Overview
	          
	          
	         Structures
	          
	          
	         Defenses
	          
	          
	         Production
	          
	          
	         Research
	          
	          
	         Trade
	          
	          
	          
	          	
	          	Aiur	 
	          
	          	
	          
	         Astro Type: Planet
	         Terrain: Rocky
	         Area: 85
	         Solar Energy: 4
	         Fertility: 5
	          	
	          	Resources	 
	          
	          	
	          
	         Metal	3
	         Gas	2
	         Crystals	0
	          
	          	 	 
	         
	          	
	          	Base information	 
	          
	          	
	          
	         Base Owner	[QUAD] moeta
	          
	         Economy	76	cred./h
	         Owner Income	76	cred./h
	          
	         Construction	129	cred./h
	         Production	113	cred./h
	         Research	166	cred./h
	          
	          	 	 
	          
	          
	          	
	          	Base Commander: Russell Vogel (Research 6)	 
	          
	         Minimum pillage 2,904 credits.
	         
	          Move fleet here
	          	
	          	Events	 
	          
	          	
	          
	         22:55:43	Research of Photon technology
	         32:41:57	Production of 749 Fighters
	         106:18:51	Construction of Research Labs
	          
	          	 	 
	          	
	          	Fleets	 
	          
	          	
	          
	         Fleet
	         Player
	         Arrival
	         Size
	         Fleet 38	[QUAD] moeta		16,705
	          
	          	 	 
	          	 	 
	          	
	         Structures	Level	Structures	Level	Defenses (100%)	Units
	         Urban Structures
	         Solar Plants
	         Fusion Plants
	         Research Labs
	         Metal Refineries
	         Robotic Factories
	         Shipyards
	         Spaceports
	         Nanite Factories
	         Android Factories
	         Economic Centers
	         Terraform
	         Orbital Base
	         17
	         10
	         1
	         23
	         17
	         12
	         2
	         10
	         7
	         1
	         3
	         4
	         1
	          
	          	 	 
	         """, new BaseParser.ParsedBase("moeta", "Aiur", new Astro("A70:33:63:10")) { GuildTag = "QUAD" }];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}