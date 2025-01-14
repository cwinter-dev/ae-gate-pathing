using AEBestGatePath.Core;
using AEBestGatePath.Core.Parsers;

namespace AEBestGatePath.Test;

public class BaseReportParserTests
{
    [Fact]
    public void ParseSampleData()
    {
        var parseSlice = @" 
Guild: 
[QUAD] actually four guilds
Show: 
Bases

Player
Base
Location
[QUAD] Phoenix Hawk	Dustball Station	A00:04:92:11
[QUAD] Sir Heiko	Lunar III	A00:05:45:10
[QUAD] Sir Heiko	Moondew	A00:15:43:11
[QUAD] Sir Heiko	Lunar IX	A00:15:50:10
[QUAD] Phoenix Hawk	Newport Station	A00:15:50:12
[QUAD] Cyndara	Base 10	A00:22:84:21
[QUAD] Khirkre	01	A00:23:55:31
[QUAD] Khirkre	02	A00:23:55:32";
        
        var playerList = BaseListParser.ParseFromBaseReport(parseSlice);
        
        Assert.NotEmpty(playerList);
        Assert.Equal(playerList, [
	        ("Phoenix Hawk", "Dustball Station", new Astro("A00:04:92:11")),
	        ("Sir Heiko", "Lunar III", new Astro("A00:05:45:10")),
	        ("Sir Heiko", "Moondew", new Astro("A00:15:43:11")),
	        ("Sir Heiko", "Lunar IX", new Astro("A00:15:50:10")),
	        ("Phoenix Hawk", "Newport Station", new Astro("A00:15:50:12")),
	        ("Cyndara", "Base 10", new Astro("A00:22:84:21")),
	        ("Khirkre", "01", new Astro("A00:23:55:31")),
	        ("Khirkre", "02", new Astro("A00:23:55:32"))
        ]);
        
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
 
14 Jan 2025, 06:21:26
 
 
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
 
 	 	 
 	
 
Events
 
 
Production
 
 
Economy
 
 
Trade
 
 
Reports
 
 
Capacities
 
 
Structures
 
 
Fleets
 
 
Units
 
 
Technologies
 
 
 	 	 
 	
 	Reports	 
 
 	
 
 	 	 
 	
 
Scanners
 
 
Player
 
 
Guild
 
 
Galaxy
 
 
Top Scouters
 
 
Top Jump Gates
 
 
Trade
 
 
Wormholes
 
 
Astros
 
 
 	 	 
Guild: 
[QUAD] actually four guilds
Show: 
Bases

Player
Base
Location
[QUAD] Phoenix Hawk	Dustball Station	A00:04:92:11
[QUAD] Sir Heiko	Lunar III	A00:05:45:10
[QUAD] Sir Heiko	Moondew	A00:15:43:11
[QUAD] Sir Heiko	Lunar IX	A00:15:50:10
[QUAD] Phoenix Hawk	Newport Station	A00:15:50:12
[QUAD] Cyndara	Base 10	A00:22:84:21
[QUAD] Khirkre	01	A00:23:55:31
[QUAD] Khirkre	02	A00:23:55:32
[QUAD] ShadowX {Anime}	Anime	A00:32:46:21
[QUAD] ShadowX {Anime}	GUNDOM	A00:32:46:32
[QUAD] Sir Heiko	Independence	A00:35:38:11
[QUAD] Sir Heiko	New Earth	A00:36:79:30
[QUAD] Sir Heiko	Lunar II	A00:36:85:10
[QUAD] Sir Heiko	Lunar V	A00:36:85:50
[QUAD] Sir Heiko	Lunar IV	A00:36:99:32
[QUAD] Cyndara	Base 11	A00:37:67:10
[QUAD] TOPs	Avis	A00:43:83:13
[QUAD] Khirkre	10	A00:44:45:21
[QUAD] Phoenix Hawk	Memorial Station	A00:44:62:10
[QUAD] Phoenix Hawk	Honor Hold	A00:44:84:12
[QUAD] Khirkre	C6	A00:45:61:11
[QUAD] Sir Heiko	Sternenwacht	A00:45:67:11
[QUAD] Khirkre	20	A00:45:86:21
[QUAD] Sir Heiko	Lunar I	A00:46:16:12
[QUAD] Phoenix Hawk	Stardawn Station	A00:46:42:11
[QUAD] Sir Heiko	Lunar VI	A00:47:40:30
[QUAD] Sir Heiko	Lunar VII	A00:47:60:10
[QUAD] Sir Heiko	Lunar X	A00:47:94:10
[QUAD] Khirkre	J1	A00:54:19:31
[QUAD] Phoenix Hawk	Black Cloud Base	A00:54:81:21
[QUAD] Khirkre	K2	A00:54:92:21
[QUAD] Death7270	Enigma	A00:55:00:22
[QUAD] Phoenix Hawk	Sentry Station	A00:55:15:10
[QUAD] Phoenix Hawk	Thunder Station	A00:55:58:40
[QUAD] Khirkre	C5	A00:55:84:12
[QUAD] Khirkre	1K	A00:55:89:10
[QUAD] Phoenix Hawk	New Eden	A00:55:89:20
[QUAD] Sir Heiko	Moonshadow	A00:56:05:10
[QUAD] Sir Heiko	Lunar VIII	A00:60:27:10
[QUAD] Phoenix Hawk	Styx Station	A00:62:77:10
[QUAD] Cyndara	Base 12	A00:63:37:10
[QUAD] Phoenix Hawk	New Hope Station	A00:63:74:30
[QUAD] Phoenix Hawk	Moonfire Station	A00:63:86:10
[QUAD] Sir Heiko	Lunar XIII	A00:64:76:10
[QUAD] Phoenix Hawk	Nowhere Station	A00:64:77:10
[QUAD] Phoenix Hawk	Antigone Station	A00:65:10:10
[QUAD] Phoenix Hawk	Odessa Station	A00:65:16:11
[QUAD] Phoenix Hawk	Crystal Port	A00:67:99:10
[QUAD] Phoenix Hawk	Westwind Station	A00:73:15:11
[QUAD] Sir Heiko	Lunar XI	A00:74:39:10
[QUAD] Sir Heiko	Lunar XII	A00:74:45:10
[QUAD] Phoenix Hawk	Terra Incognita	A00:75:22:21
[QUAD] Phoenix Hawk	Farpoint Station	A00:81:04:41
[QUAD] Phoenix Hawk	Rockball Station	A00:81:04:42
[QUAD] TOPs	Canter	A00:83:63:11
[QUAD] Sir Heiko	Little Rock	A00:83:70:11
[QUAD] TOPs	XarteX	A00:84:70:41
[QUAD] ShadowX {Anime}	Star Trek	A01:27:12:11
[QUAD] Cyndara	Base 09	A01:55:45:10
[QUAD] GaiaForce (Ni)	EA Games	A01:81:48:10
[QUAD] ShadowX {Anime}	Pokemon	A02:26:60:11
[QUAD] razorfish	IntenseStupidity	A02:27:52:23
[QUAD] Zev	Abandoned	A02:42:34:21
[QUAD] Cyndara	Base 08	A02:50:83:12
[QUAD] Ziggy(BS)	Duster	A02:97:20:10
[QUAD] Shmoo	Rogue 16	A03:64:29:50
[QUAD] Shmoo	Rogue 12	A03:85:06:10
[QUAD] Shmoo	Rogue 10	A03:85:09:51
[QUAD] Shmoo	Rogue 11	A03:85:09:52
[QUAD] Shmoo	Rogue 15	A03:85:87:40
[QUAD] Shmoo	Rogue6	A03:86:00:30
[QUAD] Shmoo	Rogue7	A03:86:00:31
[QUAD] Shmoo	Rogue8	A03:86:00:32
[QUAD] Shmoo	Rogue9	A03:86:00:33
[QUAD] Shmoo	Rogue1	A03:86:72:11
[QUAD] Shmoo	Rogue2	A03:86:72:12
[QUAD] Shmoo	Rogue 14	A03:86:73:10
[QUAD] Shmoo	Rogue4	A03:86:73:11
[QUAD] Shmoo	Rogue3	A03:86:73:31
[QUAD] Shmoo	Rogue 13	A03:86:73:40
[QUAD] Shmoo	Rogue5	A03:86:73:42
[QUAD] gundamwing3	Gunbuster	A04:34:17:20
[QUAD] MAYAN Tiberas RQ/CT	Onyx	A04:34:30:11
[QUAD] gundamwing3	Shin Getter robo	A04:34:51:10
[QUAD] gundamwing3	Death Sycthe	A04:35:02:40
[QUAD] gundamwing3	Godzilla	A04:35:11:10
[QUAD] gundamwing3	Blue destiny	A04:35:12:10
[QUAD] gundamwing3	heavy arms	A04:35:13:30
[QUAD] gundamwing3	Home Planet	A04:35:17:11
[QUAD] gundamwing3	zhen long	A04:35:31:10
[QUAD] gundamwing3	Gundam colony	A04:35:41:50
[QUAD] gundamwing3	Wing zero	A04:35:85:30
[QUAD] gundamwing3	Nadesico Colony	A04:35:85:40
[QUAD] gundamwing3	sand rock	A04:35:92:10
[QUAD] -LUE- Elmnt80	Braavos	A04:46:81:31
[QUAD] -LUE- Elmnt80	Astapor	A04:54:95:21
[QUAD] -LUE- Elmnt80	Vaes Dothrak	A04:62:37:21
[QUAD] -LUE- Elmnt80	Yunkai	A04:65:32:32
[QUAD] -LUE- Elmnt80	Buttes	A04:65:34:21
[QUAD] -LUE- Elmnt80	Qarth	A04:65:34:22
[QUAD] -LUE- Elmnt80	Meereen	A04:74:26:21
[QUAD] Shmoo	Rogue 17	A04:74:69:10
[QUAD] -LUE- Elmnt80	Pentos	A04:82:77:32
[QUAD] -LUE- Elmnt80	Volantis	A04:85:21:33
[QUAD] Mot	RAVEN	A05:25:36:10
[QUAD] Gejl	Starbase A5	A05:35:13:11
[QUAD] Gejl	Starbase A5	A05:35:99:20
[QUAD] HarryTiger	Flensburg	A06:13:93:31
[QUAD] Death7270	Partisan	A06:29:71:11
[QUAD] Mot	Zhitkur	A06:43:30:11
[QUAD] Royal Canadian Corp.	E. Ice Cube PWR	A07:38:66:10
[QUAD] KevinC (Ni) CLS	14	A08:34:78:22
[QUAD] -LUE- Elmnt80	Winterfell	A08:45:43:32
[QUAD] -LUE- Elmnt80	Kings Landing	A08:54:43:23
[QUAD] -LUE- Elmnt80	Dragonstone	A08:61:80:32
[QUAD] -LUE- Elmnt80	Hightower	A08:62:08:31
[QUAD] -LUE- Elmnt80	Riverrun	A08:63:10:23
[QUAD] -LUE- Elmnt80	Castle Black	A08:63:96:21
[QUAD] -LUE- Elmnt80	Oldtown	A08:64:28:21
[QUAD] -LUE- Elmnt80	Sun Spear	A08:64:40:21
[QUAD] Ziggy(BS)	Whipping Post	A08:71:64:11
[QUAD] -LUE- Elmnt80	Pyke	A08:73:04:31
[QUAD] -LUE- Elmnt80	Storms End	A08:73:04:32
[QUAD] -LUE- Elmnt80	The Eryie	A08:75:03:23
[QUAD] -LUE- Elmnt80	Casterly Rock	A08:75:93:31
[QUAD] Confector de Caeli	Lasterin	A09:16:71:20
[QUAD] Confector de Caeli	Navmitin	A09:33:29:50
[QUAD] gundamwing3	Imperial Base	A09:34:84:11
[QUAD] Confector de Caeli	Defentriv	A09:49:20:10
[QUAD] DOOM	09-aoe-rm/nm-w13	A09:55:59:10
[QUAD] Royal Canadian Corp.	E.2Pac shpyrds	A10:33:65:11
[QUAD] Royal Canadian Corp.	E. CKY lowerRBF	A10:34:00:20
[QUAD] Royal Canadian Corp.	T.LimpBizkit PWR	A10:34:98:10
[QUAD] Cyndara	Base 07	A10:55:29:11
[QUAD] Royal Canadian Corp.	R. DMX GAS	A10:66:18:20
[QUAD] Maple	006442024006	A11:03:81:10
[QUAD] Maple	007442024007	A11:03:81:21
[QUAD] Maple	Jump	A11:05:44:21
[QUAD] Maple	005442024005	A11:13:29:30
[QUAD] Maple	011442024011	A11:13:63:40
[QUAD] Maple	015442024015	A11:13:75:30
[QUAD] Maple	003442024003	A11:13:77:10
[QUAD] Maple	001442024001	A11:13:77:21
[QUAD] Maple	004442024004	A11:13:77:31
[QUAD] Maple	002442024002	A11:13:77:40
[QUAD] Maple	010442024010	A11:14:30:20
[QUAD] Maple	014442024014	A11:14:78:40
[QUAD] Maple	012442024012	A11:15:53:10
[QUAD] Maple	017442024017	A11:16:13:20
[QUAD] Maple	020442024020	A11:28:52:20
[QUAD] Maple	013442024013	A11:39:98:50
[QUAD] Maple	016442024016	A11:41:49:40
[QUAD] Philosopher Cody	Sepasi	A11:42:07:10
[QUAD] Maple	018442024018	A11:45:72:20
[QUAD] Maple	009442024009	A11:75:17:20
[QUAD] Maple	019442024019	A11:75:81:20
[QUAD] Gatorbait 2	Genocide City	A12:12:84:10
[QUAD] Shadows	t.Oi	A12:16:09:11
[QUAD] Shadows	Z.ha.dum	A12:22:23:12
[QUAD] razorfish	Bolshevik Muppet	A12:22:53:10
[QUAD] Shadows	Gaea	A12:23:07:11
[QUAD] Shadows	Deimos	A12:26:14:11
[QUAD] Shadows	Izual	A12:28:33:13
[QUAD] Shadows	Cirus	A12:36:50:12
[QUAD] Shadows	Jocelene	A12:41:84:11
[QUAD] Shadows	Azusienis	A12:43:15:12
[QUAD] Shadows	Azathoth	A12:45:41:12
[QUAD] Shadows	Aaryn	A12:46:94:11
[QUAD] Shadows	Da.suk.ra	A12:51:25:11
[QUAD] Shadows	Shay-ul	A12:52:70:12
[QUAD] Shadows	K.vizd	A12:53:82:11
[QUAD] Shadows	Baal	A12:54:81:11
[QUAD] Shadows	Urzka	A12:55:78:13
[QUAD] Shadows	Hera	A12:56:79:11
[QUAD] Shadows	Kra.ku.s	A12:62:42:12
[QUAD] Shadows	Scishm	A12:63:23:12
[QUAD] Shadows	Furion	A12:65:55:11
[QUAD] Shadows	Chiron	A12:66:61:11
[QUAD] Shadows	Eros	A12:72:07:13
[QUAD] KevinC (Ni) CLS	9	A12:72:97:20
[QUAD] Shadows	Dysnomia	A12:74:10:13
[QUAD] Shadows	Oberon	A12:75:52:31
[QUAD] Aether	Basalt	A12:77:30:10
[QUAD] KevinC (Ni) CLS	megadeth3	A13:26:36:20
[QUAD] razorfish	Taking cover	A13:38:81:20
[QUAD] KevinC (Ni) CLS	4	A13:53:04:30
[QUAD] Aether	Pegasus	A15:22:97:11
[QUAD] Neo	Whitefall	A15:32:80:31
[QUAD] Neo	Aberdeen	A15:32:80:32
[QUAD] Neo	Ares	A15:32:90:23
[QUAD] Aether	Arrias Alpha	A15:34:07:10
[QUAD] Aether	Eden	A15:45:34:10
[QUAD] Aether	Nemisis	A15:55:43:11
[QUAD] Aether	Kobalt	A15:56:42:20
[QUAD] Aether	Albion	A15:65:90:20
[QUAD] Aether	Achilles	A15:66:78:20
[QUAD] Mot	Malmstrom	A15:68:82:11
[QUAD] Neo	Bernadette	A15:75:42:22
[QUAD] Neo	Osiris	A15:85:19:11
[QUAD] Neo	Whittier	A15:94:35:10
[QUAD] Royal Canadian Corp.	E. Megadeath PWR	A16:04:93:10
[QUAD] Neo	Santo	A16:35:55:21
[QUAD] Neo	Hera	A16:36:55:20
[QUAD] Neo	Jiangyin	A16:36:75:20
[QUAD] Neo	Haven	A16:37:44:21
[QUAD] Neo	Regina	A16:37:89:20
[QUAD] Neo	Ariel	A16:45:63:20
[QUAD] Neo	Persephone	A16:45:85:20
[QUAD] Neo	Bellerophon	A16:46:19:41
[QUAD] Neo	Lilac	A16:46:49:40
[QUAD] Neo	Beaumonde	A16:46:94:21
[QUAD] Neo	Beylix	A16:66:93:22
[QUAD] ShadowX {Anime}	Pandora	A16:68:68:12
[QUAD] Neo	Verbena	A16:96:02:11
[QUAD] razorfish	Carpenter	A17:72:44:21
[QUAD] HarryTiger	Kiel	A17:78:63:21
[QUAD] KevinC (Ni) CLS	2	A17:86:81:20
[QUAD] ShadowX {Anime}	Blue Exorcist	A18:69:72:13
[QUAD] Helios	FC Epitaph	A18:93:63:21
[QUAD] Klaus	Luke Parker	A19:45:47:31
[QUAD] Klaus	Wes Maxfield ^R^	A19:45:48:23
[QUAD] Klaus	Kai Parker @	A19:45:61:21
[QUAD] Klaus	Damon Salvatore	A19:45:62:50
[QUAD] Klaus	Olivia Parker	A19:55:15:31
[QUAD] DOOM	19-abc-mu/re-w01	A19:56:93:20
[QUAD] quail 2.0	New Caldari	A19:84:22:11
[QUAD] quail 2.0	Irjunen	A19:93:13:11
[QUAD] Horchata	Ethephon	A20:14:04:13
[QUAD] Baxslash	Clinton	A20:16:79:10
[QUAD] MAYAN Tiberas RQ/CT	Sandy man	A20:17:16:11
[QUAD] ShadowX {Anime}	Naruto	A20:25:73:31
[QUAD] ShadowX {Anime}	Zoids	A20:25:73:32
[QUAD] Baxslash	Kippen	A20:32:94:22
[QUAD] Mot	Helghan	A20:34:00:10
[QUAD] MAYAN Tiberas RQ/CT	Whiskers	A20:35:03:13
[QUAD] Mot	Dugway	A20:54:75:10
[QUAD] Horchata	Beelined	A20:62:30:13
[QUAD] Horchata	Calquing	A20:65:83:11
[QUAD] Horchata	Pranas	A20:67:25:10
[QUAD] Baxslash	Wingham	A20:68:37:51
[QUAD] Baxslash	Goderich	A20:82:60:21
[QUAD] Baxslash	Seaforth	A20:88:10:21
[QUAD] Ziggy(BS)	Cuda	A21:04:47:11
[QUAD] Ziggy(BS)	Disposable	A21:04:47:31
[QUAD] Ziggy(BS)	1	A21:04:47:32
[QUAD] GaiaForce (Ni)	16x the Detail	A21:11:86:12
[QUAD] GaiaForce (Ni)	Cake-citeD	A21:24:13:13
[QUAD] Ziggy(BS)	Hemi	A21:66:75:11
[QUAD] Ziggy(BS)	Demon	A21:66:81:11
[QUAD] Ziggy(BS)	Challenger	A21:66:97:30
[QUAD] Darth Splitfoot	Fortress Maximus	A21:71:05:10
[QUAD] Ziggy(BS)	Mopar	A21:75:08:11
[QUAD] Ziggy(BS)	Charger	A21:78:18:10
[QUAD] Ziggy(BS)	WTF???	A22:05:92:11
[QUAD] Nazgûl	Comandos	A22:21:63:12
[QUAD] Nazgûl	Espectáculo	A22:22:07:10
[QUAD] Nazgûl	Tarrafal	A22:23:56:11
[QUAD] Nazgûl	Great War Tower	A22:35:65:20
[QUAD] Nazgûl	Sardão	A22:38:30:11
[QUAD] Nazgûl	The Registater	A22:41:07:11
[QUAD] Nazgûl	Mistery	A22:43:32:21
[QUAD] Nazgûl	Massacre	A22:44:86:11
[QUAD] Nazgûl	Cavalaria	A22:54:30:30
[QUAD] Nazgûl	Alcatraz	A22:56:54:20
[QUAD] Nazgûl	Portucale	A22:58:98:10
[QUAD] Nazgûl	Lisboa	A22:64:15:13
[QUAD] Nazgûl	Formix	A22:67:73:11
[QUAD] Nazgûl	Angmar	A22:71:65:21
[QUAD] Nazgûl	Jerónimo	A22:75:22:10
[QUAD] Nazgûl	Nazíria	A22:76:02:20
[QUAD] Nazgûl	Badalhoca	A22:77:38:10
[QUAD] Nazgûl	Caixa Geral	A22:78:38:10
[QUAD] Nazgûl	Minas Tirith	A22:81:16:13
[QUAD] Nazgûl	Master	A22:84:26:31
[QUAD] Nazgûl	Manowar	A22:85:01:30
[QUAD] Nazgûl	Mastodonte	A22:93:14:13
[QUAD] Annihilator	Kogara Toto	A23:11:76:11
[QUAD] ShadowX {Anime}	Inuyasha	A23:28:23:30
[QUAD] Gatorbait 2	StardustSpeedway	A23:35:58:30
[QUAD] Cuyito	PI-A*13	A23:35:73:21
[QUAD] Gatorbait 2	Launch Base	A23:35:77:11
[QUAD] Gatorbait 2	Oil Ocean	A23:36:13:20
[QUAD] Cuyito	PH-A*14	A23:36:96:13
[QUAD] Annihilator	Shishiro Botan	A23:37:62:11
[QUAD] Annihilator	Usada Pekora	A23:38:25:11
[QUAD] Annihilator	Kaminari Qpi	A23:38:41:11
[QUAD] Annihilator	Sendo Yuuhi	A23:38:58:13
[QUAD] Annihilator	Nekota Tsuna	A23:38:68:12
[QUAD] Annihilator	Sakamata Chloe	A23:39:21:10
[QUAD] Annihilator	Ookami Mio	A23:44:04:31
[QUAD] Annihilator	Aizawa Ema	A23:44:11:13
[QUAD] Gatorbait 2	Scrap Brain	A23:44:83:20
[QUAD] Annihilator	Hakui Koyori	A23:47:49:13
[QUAD] Annihilator	Minato Aqua	A23:47:49:31
[QUAD] Annihilator	Shinomiya Runa	A23:47:56:11
[QUAD] Annihilator	Tokoyami Towa	A23:48:02:11
[QUAD] Gatorbait 2	Endless Mine	A23:53:22:30
[QUAD] KevinC (Ni) CLS	10	A23:54:88:12
[QUAD] Gatorbait 2	Wacky Workbench	A23:55:69:10
[QUAD] Gatorbait 2	Hidden Palace	A23:56:27:21
[QUAD] Gatorbait 2	Ice Cap	A23:56:95:10
[QUAD] ShadowX {Anime}	Blue Dragon	A23:60:77:40
[QUAD] Gatorbait 2	Green Hill	A23:65:18:20
[QUAD] Annihilator	Yakumo Beni	A23:65:42:11
[QUAD] Gatorbait 2	Quartz Quadrant	A23:67:65:31
[QUAD] Gatorbait 2	Metropolis	A23:68:46:20
[QUAD] Gatorbait 2	Diamond Dust	A23:75:02:13
[QUAD] Helios	Industrial 4	A23:75:62:11
[QUAD] Gatorbait 2	Chrome Gadget	A23:75:76:20
[QUAD] Helios	Industrial 2	A23:76:66:22
[QUAD] Helios	Gate Of Light	A23:76:79:11
[QUAD] Helios	Hybrid 2	A23:76:79:12
[QUAD] Helios	Vega Labs	A23:77:21:13
[QUAD] Helios	Hybrid 1	A23:77:64:21
[QUAD] Helios	Industrial 3	A23:77:64:31
[QUAD] Annihilator	Tachibana Hinano	A23:79:62:11
[QUAD] Annihilator	Anya Melfissa	A23:85:51:11
[QUAD] Annihilator	Arya Kuroha	A23:85:64:21
[QUAD] Helios	Industrial 1	A23:86:01:20
[QUAD] Helios	Industrial 7	A23:93:21:41
[QUAD] Horchata	Sudds	A24:21:13:13
[QUAD] A Cup of Tea	Chicken Kickers	A24:45:49:20
[QUAD] Death7270	Fort Alucard	A25:34:14:10
[QUAD] Death7270	Acrostel	A25:34:46:10
[QUAD] Death7270	Sureal	A25:36:96:10
[QUAD] razorfish	Looneyville	A25:37:33:11
[QUAD] HarryTiger	Glogau	A25:40:76:21
[QUAD] Death7270	Swardia	A25:46:82:40
[QUAD] Death7270	Darklands	A25:49:39:32
[QUAD] Death7270	Central Dogma	A25:53:24:30
[QUAD] razorfish	ReasonAndSanity	A25:58:01:20
[QUAD] Death7270	Logan	A25:69:01:21
[QUAD] Death7270	St. Ives	A25:71:55:10
[QUAD] Death7270	Raven	A25:83:53:10
[QUAD] Death7270	Abandon	A25:85:39:10
[QUAD] ShadowX {Anime}	25	A25:93:39:10
[QUAD] Death7270	Shadowland	A25:94:81:21
[QUAD] Sir Heiko	Starlight	A26:34:72:10
[QUAD] Louise Vallière	FLT Facility	A26:84:95:11
[QUAD] Louise Vallière	Iserlohn	A27:06:61:10
[QUAD] MAYAN Tiberas RQ/CT	Lucy	A27:27:88:20
[QUAD] Mot	Groom Lake	A27:56:63:11
[QUAD] Louise Vallière	Gate 01	A27:86:19:11
[QUAD] Louise Vallière	Astarte	A27:86:22:21
[QUAD] Louise Vallière	Transient Gate	A27:87:29:11
[QUAD] Annihilator	Tosaki Mimi	A27:96:44:23
[QUAD] Louise Vallière	Gate 03	A28:51:17:21
[QUAD] Louise Vallière	Tristain トリスタニア	A28:60:89:11
[QUAD] Louise Vallière	Jachin Due	A28:78:27:10
[QUAD] Louise Vallière	Vermillion	A29:24:68:13
[QUAD] Baxslash	Lucan	A29:24:98:20
[QUAD] DOOM	29-xyz-mu/re-w02	A29:34:05:10
[QUAD] Annihilator	Hanabusa Lisa	A29:66:92:40
[QUAD] Neo	Miranda	A29:73:38:21
[QUAD] Neo	Greenleaf	A29:73:79:21
[QUAD] Baxslash	Grand Bend	A29:95:32:11
[QUAD] HarryTiger	Dortmund	A30:04:99:20
[QUAD] Gatorbait 2	Mystic Cave	A30:13:51:13
[QUAD] KevinC (Ni) CLS	11	A30:14:04:30
[QUAD] HarryTiger	Frankfurt ★	A30:15:13:20
[QUAD] razorfish	Blampires	A30:17:92:21
[QUAD] HarryTiger	Königsberg ★	A30:23:31:30
[QUAD] HarryTiger	Stuttgart ★	A30:24:04:20
[QUAD] HarryTiger	Wolfsschanze	A30:28:28:21
[QUAD] HarryTiger	Essen	A30:34:47:20
[QUAD] HarryTiger	Chemnitz	A30:34:59:31
[QUAD] HarryTiger	Bonn	A30:34:60:30
[QUAD] HarryTiger	Leipzig	A30:34:64:21
[QUAD] HarryTiger	Breslau	A30:34:82:31
[QUAD] HarryTiger	Bremen	A30:34:82:32
[QUAD] HarryTiger	Dresden	A30:34:88:21
[QUAD] HarryTiger	Potsdam	A30:34:94:20
[QUAD] HarryTiger	Berlin	A30:34:96:21
[QUAD] HarryTiger	Görlitz	A30:40:36:20
[QUAD] HarryTiger	München ★	A30:47:99:21
[QUAD] HarryTiger	Duisburg	A30:51:28:30
[QUAD] HarryTiger	Düsseldorf ★	A30:68:90:21
[QUAD] HarryTiger	Hamburg ★	A30:77:38:31
[QUAD] razorfish	PolkaWillNvrDie!	A30:84:99:10
[QUAD] HarryTiger	Köln ★	A30:93:12:31
[QUAD] Darth Splitfoot	Ominousity	A31:45:54:21
[QUAD] Darth Splitfoot	Mandalore	A31:46:62:20
[QUAD] Darth Splitfoot	Natalia	A31:54:55:21
[QUAD] Darth Splitfoot	Ithor	A31:54:99:20
[QUAD] Darth Splitfoot	FHOST	A31:55:18:31
[QUAD] Darth Splitfoot	ZIOST	A31:55:95:31
[QUAD] Darth Splitfoot	Dathomir	A31:56:01:20
[QUAD] Darth Splitfoot	Ahsoka Tano	A31:57:34:10
[QUAD] Darth Splitfoot	Korriban	A31:66:97:42
[QUAD] Darth Splitfoot	Corellia	A31:67:61:20
[QUAD] Helios	First Prime	A31:79:03:11
[QUAD] Angry Clown (Ni)	VIII	A31:82:97:20
[QUAD] Angry Clown (Ni)	IX	A31:83:76:20
[QUAD] Darth Splitfoot	Ashas Ree	A31:93:12:21
[QUAD] ShadowX {Anime}	32	A32:17:22:10
[QUAD] Minister Of Rejects	The Big Dwarf JG	A32:26:53:12
[QUAD] Darth Splitfoot	Dantooine	A32:30:24:30
[QUAD] Darth Splitfoot	Tahiri Veila	A32:31:90:21
[QUAD] Zev	End of the world	A32:46:90:13
[QUAD] Angry Clown (Ni)	XVIII	A32:93:13:31
[QUAD] Horchata	Outjinx	A33:05:96:11
[QUAD] TOPs	Winfield	A33:61:17:21
[QUAD] Angry Clown (Ni)	X	A33:72:94:10
[QUAD] TOPs	Mithrander	A33:79:71:11
[QUAD] Angry Clown (Ni)	XI	A34:04:79:21
[QUAD] Angry Clown (Ni)	XII	A34:24:14:11
[QUAD] Darth Splitfoot	Kuat Driveyards	A34:40:24:30
[QUAD] Cam76	Home Planet	A34:45:75:11
[QUAD] Cam76	ARID	A34:55:97:10
[QUAD] Zhao Yun	Outbound-JG	A34:94:93:22
[QUAD] Zhao Yun	Capital	A35:02:97:21
[QUAD] Zhao Yun	St.Louis	A35:02:97:31
[QUAD] Zhao Yun	San Jose	A35:05:63:12
[QUAD] Zhao Yun	Austin	A35:13:26:30
[QUAD] Zhao Yun	Los Angeles	A35:15:69:22
[QUAD] Zhao Yun	San Francisco	A35:17:11:21
[QUAD] Ziggy(BS)	Tomorrow land	A35:23:30:13
[QUAD] Zhao Yun	Pangea	A35:26:02:21
[QUAD] Zhao Yun	New Orleans	A35:26:14:31
[QUAD] Zhao Yun	Miami	A35:26:73:21
[QUAD] Darth Splitfoot	Polis Massa	A35:30:39:21
[QUAD] Zhao Yun	Washington D.C.	A35:31:89:20
[QUAD] Zhao Yun	Baltimore	A35:32:89:20
[QUAD] Zhao Yun	Philadelphia	A35:33:26:20
[QUAD] A Cup of Tea	Stuffed crust	A35:36:77:20
[QUAD] Darth Splitfoot	Nal Hutta	A35:39:57:11
[QUAD] A Cup of Tea	Garlic and Herb	A35:42:59:20
[QUAD] A Cup of Tea	Mozzarella	A35:42:96:20
[QUAD] Cyndara	Base 06	A35:45:43:11
[QUAD] A Cup of Tea	Extra Cheese	A35:45:87:21
[QUAD] A Cup of Tea	Pepperoni	A35:54:94:20
[QUAD] Darth Splitfoot	Kamino	A35:58:69:30
[QUAD] Darth Splitfoot	ArkanianMicrotec	A35:59:14:20
[QUAD] A Cup of Tea	Chicken	A35:62:09:20
[QUAD] A Cup of Tea	Not pineapple	A35:62:37:21
[QUAD] Annihilator	Moona Hoshinova	A35:63:18:11
[QUAD] Death7270	Humperdinck	A35:63:51:20
[QUAD] A Cup of Tea	Chorizo	A35:63:85:20
[QUAD] Zhao Yun	FT_Production 6	A35:72:76:20
[QUAD] A Cup of Tea	Spicy beef	A35:73:46:21
[QUAD] A Cup of Tea	Home Planet	A35:73:57:23
[QUAD] Zhao Yun	FT_Product 7 JG	A35:78:77:10
[QUAD] Zhao Yun	FT_Production 7	A35:78:77:40
[QUAD] Zhao Yun	Deimos 5	A35:82:48:21
[QUAD] Zhao Yun	FT_Production 5	A35:82:48:23
[QUAD] A Cup of Tea	Bacon	A35:83:18:21
[QUAD] Zhao Yun	FT_Production 3	A35:86:35:11
[QUAD] Zhao Yun	FT_Production 4	A35:93:63:20
[QUAD] Zhao Yun	FT_Production 2	A35:95:08:21
[QUAD] Zhao Yun	New York-JG	A35:95:31:11
[QUAD] Zhao Yun	FT_Production 1	A35:95:31:20
[QUAD] Mot	Loring AFB	A35:96:14:11
[QUAD] Green Alien CARTEL ®	Chapter 1J36X7	A36:31:29:11
[QUAD] Green Alien CARTEL ®	Chapter 2R36X7	A36:42:26:10
[QUAD] Death7270	Grendel	A36:43:41:20
[QUAD] A Cup of Tea	Sauce	A36:60:68:20
[QUAD] ShadowX {Anime}	Naruto Shippuden	A36:95:16:40
[QUAD] Horchata	Vanners	A37:04:55:11
[QUAD] Lucasjuh	Thunderstorm	A37:13:42:10
[QUAD] Lucasjuh	Earthquake	A37:13:42:11
[QUAD] MAYAN Tiberas RQ/CT	Bullet	A37:14:26:11
[QUAD] Lucasjuh	Security	A37:14:62:11
[QUAD] Lucasjuh	Safe	A37:14:62:12
[QUAD] Lucasjuh	Blue Sky	A37:25:17:10
[QUAD] Lucasjuh	Home Planet	A37:25:17:21
[QUAD] Lucasjuh	Rainy Day	A37:25:17:40
[QUAD] Lucasjuh	Fishing Net	A37:25:24:31
[QUAD] Lucasjuh	BaseballCap	A37:25:24:32
[QUAD] Lucasjuh	Sunshine	A37:26:54:30
[QUAD] Lucasjuh	Fishing Bait	A37:26:55:21
[QUAD] Lucasjuh	NoNamePlanet	A37:26:57:50
[QUAD] Lucasjuh	BaseballBat	A37:26:85:21
[QUAD] Green Alien CARTEL ®	Chapter 4R37X7	A37:27:79:10
[QUAD] Green Alien CARTEL ®	Chapter 3J37X7	A37:28:44:11
[QUAD] ShadowX {Anime}	DMC	A37:60:37:20
[QUAD] GaiaForce (Ni)	Ente Isla	A37:61:68:11
[QUAD] MAYAN Tiberas RQ/CT	Horse Radish	A37:67:62:11
[QUAD] Mot	Kasputin Yar	A37:84:47:10
[QUAD] Green Alien CARTEL ®	Chapter 5JP37X8	A37:85:37:10
[QUAD] GaiaForce (Ni)	Ubis00ft	A37:85:68:12
[QUAD] Lucasjuh	Meteor Catcher	A37:96:20:10
[QUAD] Lucasjuh	Poison	A37:96:20:20
[QUAD] Baxslash	Brucefield	A38:05:78:42
[QUAD] A Cup of Tea	Sausage	A38:13:39:21
[QUAD] A Cup of Tea	BBQ	A38:14:04:20
[QUAD] Baxslash	Hensall	A38:75:87:10
[QUAD] Gatorbait 2	Hill Top	A38:82:09:10
[QUAD] GaiaForce (Ni)	Ragnar	A39:22:35:10
[QUAD] GaiaForce (Ni)	-Redacted-	A39:28:61:21
[QUAD] GaiaForce (Ni)	／人◕ ‿‿ ◕人＼	A39:32:75:10
[QUAD] GaiaForce (Ni)	Novus	A39:37:44:10
[QUAD] Ziggy(BS)	Newest	A39:43:42:20
[QUAD] DOOM	39.1-zed-r/n-w10	A39:45:40:10
[QUAD] GaiaForce (Ni)	Gekkostate	A39:54:01:11
[QUAD] A Cup of Tea	Ham	A39:55:15:21
[QUAD] GaiaForce (Ni)	Valgo	A39:55:55:11
[QUAD] GaiaForce (Ni)	Cat World	A39:55:65:20
[QUAD] GaiaForce (Ni)	Kaminatukisei	A39:55:89:21
[QUAD] GaiaForce (Ni)	Grabil	A39:56:69:22
[QUAD] GaiaForce (Ni)	Varuta	A39:62:76:13
[QUAD] DOOM	39.2-ram-mtp-w09	A39:63:57:10
[QUAD] GaiaForce (Ni)	Gepelnitch *	A39:65:11:13
[QUAD] GaiaForce (Ni)	Gavil	A39:67:98:20
[QUAD] GaiaForce (Ni)	Titin	A39:75:96:20
[QUAD] GaiaForce (Ni)	Melaka	A39:77:65:20
[QUAD] GaiaForce (Ni)	Azurite	A39:84:21:10
[QUAD] Helios	Pax	A40:28:34:20
[QUAD] Buegur	Crusade	A40:40:99:41
[QUAD] DOOM	40-rzr-wen-dn2	A40:44:26:10
[QUAD] Lordvader	Corralia	A40:64:74:11
[QUAD] DOOM	40-etc-mu/re-w03	A40:66:83:20
[QUAD] Lordvader	Mustafar	A40:73:49:11
[QUAD] razorfish	Pizza Lord	A41:14:42:21
[QUAD] Buegur	Pilgrim	A41:21:75:11
[QUAD] MAYAN Tiberas RQ/CT	Smokey	A41:54:67:11
[QUAD] DOOM	41-utc-n.-w.i.15	A41:63:80:10
[QUAD] Pathfinder	42.1	A42:06:97:11
[QUAD] Buegur	Glory	A42:63:19:11
[QUAD] MAYAN Tiberas RQ/CT	Sheltie	A42:70:06:10
[QUAD] Buegur	Paradise	A43:52:96:11
[QUAD] Mot	Papoose Lake S4	A43:72:23:10
[QUAD] Mot	Nellis Range	A43:72:87:10
[QUAD] Sir Heiko	Lunar Eclipse	A43:96:11:11
[QUAD] Gejl	Starbase A43	A43:97:08:50
[QUAD] Gejl	Starbase A43	A43:97:08:52
[QUAD] Horchata	Chanoyus	A44:04:84:11
[QUAD] Buegur	Halo	A44:16:90:21
[QUAD] Buegur	Prophet	A44:58:31:11
[QUAD] Pathfinder	44.1	A44:70:49:10
[QUAD] Helios	Hybrid 4	A44:70:49:31
[QUAD] Helios	New Vega	A44:75:78:31
[QUAD] Helios	Gate Of Shadows	A44:97:16:21
[QUAD] Shadows	Ba.Zahn	A45:14:95:11
[QUAD] corwin de amber	starmine 5	A45:24:53:20
[QUAD] corwin de amber	Emerald	A45:24:68:11
[QUAD] Pathfinder	45.1	A45:25:81:40
[QUAD] Pathfinder	45.2	A45:30:49:21
[QUAD] Pathfinder	45.3	A45:32:69:50
[QUAD] corwin de amber	starmine 1	A45:33:28:20
[QUAD] Pathfinder	45.4	A45:34:05:10
[QUAD] Pathfinder	45.5	A45:34:25:20
[QUAD] corwin de amber	space rock 2	A45:34:63:11
[QUAD] Pathfinder	45.6	A45:34:79:30
[QUAD] Pathfinder	45.7	A45:35:15:21
[QUAD] Pathfinder	45.8	A45:35:49:10
[QUAD] Pathfinder	45.9	A45:35:54:20
[QUAD] Pathfinder	45.10	A45:35:68:10
[QUAD] Pathfinder	45.11	A45:36:20:10
[QUAD] Pathfinder	45.12	A45:36:70:20
[QUAD] Buegur	Vatican	A45:37:66:11
[QUAD] corwin de amber	space rock 1	A45:44:24:21
[QUAD] Pathfinder	45.13	A45:44:70:12
[QUAD] corwin de amber	starmine 2	A45:45:88:20
[QUAD] Pathfinder	45.14	A45:45:93:20
[QUAD] Pathfinder	45.15	A45:46:22:13
[QUAD] Pathfinder	45.16	A45:49:35:10
[QUAD] Helios	Hybrid 5	A45:49:35:11
[QUAD] Helios	Hybrid 3	A45:50:47:31
[QUAD] Pathfinder	45.17	A45:52:88:12
[QUAD] corwin de amber	starmine 3	A45:53:35:20
[QUAD] Buegur	Cathedral	A45:67:68:10
[QUAD] corwin de amber	New Terra	A45:68:48:20
[QUAD] Helios	Gate Of Twilight	A45:95:59:33
[QUAD] Neo	Shadow	A46:28:94:11
[QUAD] Helios	Blood of 13th	A46:39:92:22
[QUAD] Buegur	St. Petersburg	A46:47:03:10
[QUAD] Buegur	Angels Abode	A46:47:98:11
[QUAD] Pathfinder	46.1	A46:60:56:21
[QUAD] Confector de Caeli	Kyristin	A46:60:98:30
[QUAD] Confector de Caeli	Vikarii	A46:61:19:10
[QUAD] Confector de Caeli	Trundine	A46:61:19:11
[QUAD] Confector de Caeli	Zyvel	A46:61:19:20
[QUAD] Confector de Caeli	Lantonine	A46:61:64:10
[QUAD] Confector de Caeli	Italtha	A46:61:91:21
[QUAD] Confector de Caeli	Jervera	A46:61:91:30
[QUAD] Confector de Caeli	Omorpha	A46:62:64:20
[QUAD] Confector de Caeli	Dorsemine	A46:62:64:21
[QUAD] Confector de Caeli	Murkella	A46:62:71:20
[QUAD] Confector de Caeli	Silvisur	A46:72:23:20
[QUAD] Confector de Caeli	Yasteril	A46:72:35:10
[QUAD] Confector de Caeli	Kenrak	A46:72:61:20
[QUAD] Buegur	Beacon	A46:77:61:10
[QUAD] Helios	Gate of Fire	A46:97:09:30
[QUAD] Baxslash	Dashwood	A47:06:64:30
[QUAD] Helios	Ashes of Cazanna	A47:18:90:31
[QUAD] Buegur	Cross	A47:36:75:21
[QUAD] Louise Vallière	Gate 05	A47:43:49:10
[QUAD] Buegur	Church	A47:46:12:11
[QUAD] Pathfinder	47.1	A47:55:43:10
[QUAD] Louise Vallière	Heinessen	A47:65:83:10
[QUAD] Louise Vallière	MSWAD HQ	A47:70:38:50
[QUAD] Louise Vallière	El-Facil	A47:73:67:10
[QUAD] Baxslash	Exeter	A47:75:20:30
[QUAD] Phoenix Hawk	Starfire Station	A48:05:40:10
[QUAD] Royal Canadian Corp.	E. AC/DC lowergs	A48:23:48:40
[QUAD] Royal Canadian Corp.	P. NOFX	A48:25:60:11
[QUAD] Royal Canadian Corp.	E. Slayer lowrgs	A48:26:62:50
[QUAD] Royal Canadian Corp.	T. KoRn	A48:26:75:30
[QUAD] Royal Canadian Corp.	R. OZZY PWR	A48:26:75:40
[QUAD] Royal Canadian Corp.	P. Stone SourPWR	A48:26:83:20
[QUAD] Royal Canadian Corp.	P. Manson PWR	A48:26:83:40
[QUAD] Royal Canadian Corp.	P. MushroomHead	A48:26:86:30
[QUAD] Royal Canadian Corp.	R. Slipknot	A48:26:99:11
[QUAD] Royal Canadian Corp.	R. Mudvayne	A48:26:99:30
[QUAD] Royal Canadian Corp.	E. Killswitch	A48:27:15:11
[QUAD] Buegur	Constantinople	A48:27:56:11
[QUAD] Royal Canadian Corp.	R. Offspring	A48:28:32:13
[QUAD] Buegur	Antioch	A48:38:42:21
[QUAD] Ziggy(BS)	farscape	A48:44:52:11
[QUAD] Royal Canadian Corp.	T.Metallical pwr	A48:56:03:11
[QUAD] Minister Of Rejects	Nikator	A48:66:27:11
[QUAD] Minister Of Rejects	The Ministry	A48:66:44:11
[QUAD] Minister Of Rejects	Kratos	A48:66:50:11
[QUAD] Minister Of Rejects	Rejects Forever	A48:66:97:11
[QUAD] Minister Of Rejects	Nike	A48:67:01:10
[QUAD] Minister Of Rejects	Patroclus	A48:67:34:10
[QUAD] Minister Of Rejects	Demostrate JG	A48:67:38:10
[QUAD] Minister Of Rejects	Zeus	A48:67:52:31
[QUAD] Minister Of Rejects	Berenice	A48:67:71:31
[QUAD] Minister Of Rejects	Eunice	A48:67:84:11
[QUAD] Louise Vallière	Junius Seven	A48:74:65:10
[QUAD] Sir Heiko	Sintares Glory	A48:83:53:11
[QUAD] Death7270	Thor	A49:02:77:30
[QUAD] ShadowX {Anime}	Zoids: Fusors	A49:04:39:30
[QUAD] Phoenix Hawk	Aurora Station	A49:12:79:20
[QUAD] Buegur	Jericho	A49:42:93:11
[QUAD] Louise Vallière	Krung Thep	A49:52:68:12
[QUAD] Death7270	Emerald	A49:55:00:13
[QUAD] Louise Vallière	Celestial Being	A49:63:47:10
[QUAD] Helios	Lilarcors Ashes	A49:79:14:21
[QUAD] Mot	Rendlesham	A50:13:13:13
[QUAD] AcidCore	Tesla Memorial	A50:34:08:10
[QUAD] DOOM	50-ftw-mtdup-w11	A50:44:44:10
[QUAD] conquistador	*STARGATE 51*	A51:46:84:10
[QUAD] KevinC (Ni) CLS	6	A51:63:03:21
[QUAD] conquistador	*STARGATE 52*	A52:16:87:10
[QUAD] KevinC (Ni) CLS	17	A52:35:37:20
[QUAD] Cyndara	Base 03	A52:54:61:21
[QUAD] James Langley	Alta Astarii	A52:76:74:20
[QUAD] James Langley	Varn	A52:76:80:11
[QUAD] Darth Splitfoot	Jeddha	A53:05:79:20
[QUAD] James Langley	Vega Prime	A53:05:79:22
[QUAD] James Langley	Dal Koro	A53:26:28:20
[QUAD] conquistador	*STARGATE 53*	A53:34:96:10
[QUAD] Mot	Dyatlov	A53:35:32:10
[QUAD] James Langley	Arcturus Landing	A53:36:45:20
[QUAD] James Langley	Mercury	A53:36:58:10
[QUAD] James Langley	Earth	A53:36:58:30
[QUAD] James Langley	Xix-t-van	A53:36:80:20
[QUAD] James Langley	Armageddon Reef	A53:36:87:11
[QUAD] James Langley	Chora-Kath	A53:37:31:11
[QUAD] James Langley	Enarius	A53:37:76:20
[QUAD] James Langley	Barnards World	A53:37:84:21
[QUAD] James Langley	Achernar Prime	A53:38:70:20
[QUAD] James Langley	Rokara	A53:39:72:11
[QUAD] Cyndara	Home Planet	A53:44:35:22
[QUAD] James Langley	Argosia	A53:55:11:31
[QUAD] James Langley	Maraketh	A53:55:30:20
[QUAD] James Langley	Babylon Station	A53:55:46:11
[QUAD] James Langley	Altaris	A53:55:58:20
[QUAD] Cyndara	Base 02	A53:96:81:21
[QUAD] Angry Clown (Ni)	XIII.	A53:96:82:10
[QUAD] conquistador	*STARGATE 54*	A54:34:39:10
[QUAD] Cyndara	Base 04	A54:45:42:11
[QUAD] Minister Of Rejects	Nausicaa JG	A54:73:60:11
[QUAD] wolfie5	Ty	A55:13:09:11
[QUAD] Mot	1283-420-20-17	A55:20:97:12
[QUAD] wolfie5	Dann	A55:34:69:11
[QUAD] Ziggy(BS)	Production1	A55:43:40:11
[QUAD] Ziggy(BS)	Daytona	A55:43:40:12
[QUAD] Ziggy(BS)	crystal ship	A55:43:40:13
[QUAD] Cowpower	C4 04	A55:50:57:21
[QUAD] conquistador	*STARGATE 55*	A55:54:20:10
[QUAD] Cowpower	C4 02	A55:57:06:11
[QUAD] Cowpower	C4 01	A55:57:50:10
[QUAD] Cowpower	C4 03	A55:77:64:10
[QUAD] Pr!ngl£s	Otrix	A56:03:99:30
[QUAD] Pr!ngl£s	Jandro	A56:12:99:21
[QUAD] gundamwing3	Freedom	A56:23:52:22
[QUAD] Pr!ngl£s	Retklir	A56:27:56:20
[QUAD] KevinC (Ni) CLS	15	A56:28:37:21
[QUAD] conquistador	*STARGATE 56*	A56:44:11:10
[QUAD] Pr!ngl£s	Flavitne	A56:45:95:20
[QUAD] Pr!ngl£s	Production	A56:54:29:20
[QUAD] Pr!ngl£s	Creyt	A56:55:37:20
[QUAD] gundamwing3	Shin Dragon	A56:55:71:11
[QUAD] gundamwing3	Justice	A56:55:73:11
[QUAD] gundamwing3	Alien Base	A56:55:84:22
[QUAD] gundamwing3	Predator Base	A56:55:92:31
[QUAD] Pr!ngl£s	Research B	A56:56:46:20
[QUAD] Pr!ngl£s	Naswro	A56:63:77:20
[QUAD] Pr!ngl£s	Inprim	A56:65:35:21
[QUAD] Pr!ngl£s	Pynrak	A56:66:35:20
[QUAD] Pr!ngl£s	Gwithnok	A56:66:83:21
[QUAD] Pr!ngl£s	Trazz	A56:69:31:21
[QUAD] Pr!ngl£s	Research A	A56:76:55:13
[QUAD] conquistador	AREA 56	A56:77:43:11
[QUAD] Pr!ngl£s	Trebb	A56:86:57:20
[QUAD] Horchata	Nunatak	A57:11:96:11
[QUAD] Mot	Los Alamos	A57:32:19:11
[QUAD] conquistador	*STARGATE 57*	A57:33:95:10
[QUAD] Mot	Thule Air Base	A57:44:55:11
[QUAD] Mot	Mot	A57:44:84:11
[QUAD] Mot	Muldrow 17	A57:54:14:11
[QUAD] Mot	Luna 5	A57:54:27:11
[QUAD] Baxslash	Bayfield	A58:04:75:11
[QUAD] Angry Clown (Ni)	Onyx	A58:15:91:21
[QUAD] Angry Clown (Ni)	XIV	A58:39:50:10
[QUAD] Angry Clown (Ni)	XV	A58:41:89:40
[QUAD] Edward Longshanks	Aquae Arnemetiae	A58:50:59:10
[QUAD] Edward Longshanks	Alsium	A58:58:65:41
[QUAD] Angry Clown (Ni)	XVI	A58:61:78:20
[QUAD] Angry Clown (Ni)	Reach	A58:75:12:11
[QUAD] Edward Longshanks	Aternum	A58:84:86:12
[QUAD] Baxslash	Kirkton	A58:86:27:12
[QUAD] Edward Longshanks	Daedalium	A58:87:14:51
[QUAD] Angry Clown (Ni)	:(	A59:13:43:11
[QUAD] Edward Longshanks	Corfinium	A59:31:10:31
[QUAD] Angry Clown (Ni)	Home C	A59:32:68:21
[QUAD] Edward Longshanks	Catania	A59:40:54:20
[QUAD] Edward Longshanks	Cagliari	A59:45:03:30
[QUAD] razorfish	Velvet Room	A59:45:47:13
[QUAD] Edward Longshanks	Falerii Novi	A59:51:07:31
[QUAD] Edward Longshanks	Entella	A59:52:56:20
[QUAD] Edward Longshanks	Rome	A59:53:79:33
[QUAD] Edward Longshanks	Forum Novum	A59:54:93:10
[QUAD] Edward Longshanks	Longaricum	A59:66:04:21
[QUAD] Edward Longshanks	Lilybaeum	A59:67:59:11
[QUAD] Edward Longshanks	Mevania	A59:73:02:30
[QUAD] Edward Longshanks	Soluntum	A59:74:55:20
[QUAD] Edward Longshanks	Derthona	A59:83:66:31
[QUAD] razorfish	Blue Beetle	A59:85:71:23
[QUAD] Edward Longshanks	Tharros	A59:86:44:13
[QUAD] Angry Clown (Ni)	Oh no	A59:97:16:11
[QUAD] koko	A60 ACME 17	A60:24:74:10
[QUAD] koko	A60 ACME 6	A60:28:82:11
[QUAD] koko	A60 ACME 7	A60:28:85:11
[QUAD] koko	A60 ACME 9	A60:34:69:11
[QUAD] Gatorbait 2	Lava Powerhouse	A60:35:20:10
[QUAD] koko	A60 ACME 15	A60:35:79:20
[QUAD] koko	A60 ACME 10	A60:36:95:11
[QUAD] Gatorbait 2	Flying Battery	A60:43:22:20
[QUAD] koko	A60 ACME 4	A60:44:69:10
[QUAD] koko	A60 ACME 12	A60:45:63:10
[QUAD] koko	A60 ACME 13	A60:45:69:10
[QUAD] Gatorbait 2	Sunset Park	A60:45:76:10
[QUAD] koko	A60 ACME 3	A60:47:25:10
[QUAD] Sniper	Unicoi 12	A60:47:92:20
[QUAD] koko	A60 ACME 14	A60:49:57:10
[QUAD] koko	A60 ACME 16	A60:54:54:10
[QUAD] DOOM	60-omg-wen	A60:55:86:10
[QUAD] koko	A60 ACME 18	A60:56:00:20
[QUAD] DOOM	60-ron-rm/nm-w14	A60:56:94:20
[QUAD] koko	go away no fleet	A60:60:14:10
[QUAD] koko	A60 ACME 1	A60:60:14:31
[QUAD] koko	A60 ACME 5	A60:65:85:20
[QUAD] koko	A60 ACME 2	A60:67:10:10
[QUAD] koko	A60 ACME 11	A60:76:01:10
[QUAD] koko	A60 ACME 8	A60:77:61:20
[QUAD] Helios	Industrial 5	A61:29:94:11
[QUAD] Helios	Industrial 6	A62:06:91:20
[QUAD] Klaus	Janet Gilbert	A62:24:68:11
[QUAD] KevinC (Ni) CLS	MEGADETH 9	A63:78:41:20
[QUAD] KevinC (Ni) CLS	7	A64:15:80:30
[QUAD] Edward Longshanks	Turin	A64:22:99:21
[QUAD] KevinC (Ni) CLS	16	A64:23:80:13
[QUAD] Edward Longshanks	Ventimiglia	A64:38:90:21
[QUAD] Edward Longshanks	Vercelli	A64:39:62:11
[QUAD] Edward Longshanks	Veleia	A64:45:14:21
[QUAD] Green Alien CARTEL ®	Chapter 12JPX7	A64:46:92:11
[QUAD] Edward Longshanks	Taormina	A64:54:81:21
[QUAD] Corvidae	Winterfell	A64:73:28:42
[QUAD] Edward Longshanks	Mytistraton	A64:82:16:31
[QUAD] Edward Longshanks	Falacrine	A64:86:75:11
[QUAD] Baxslash	Stratford	A65:16:96:12
[QUAD] Angry Clown (Ni)	XVII	A65:22:53:32
[QUAD] Raptor RQ/CT	Pastapolis	A65:22:53:33
[QUAD] Raptor RQ/CT	Pippapolis	A65:22:80:21
[QUAD] Raptor RQ/CT	Exotapolis	A65:22:80:22
[QUAD] Raptor RQ/CT	Festiopolis	A65:22:82:11
[QUAD] Raptor RQ/CT	*Elektropolis	A65:22:99:31
[QUAD] Raptor RQ/CT	Yunapolis	A65:23:34:31
[QUAD] Raptor RQ/CT	Banglopolis	A65:23:99:11
[QUAD] wolfie5	Claire	A65:32:21:30
[QUAD] Raptor RQ/CT	Andropolis	A65:32:34:21
[QUAD] wolfie5	Gordon	A65:32:93:20
[QUAD] wolfie5	Kelly1	A65:35:09:20
[QUAD] wolfie5	Isaac2	A65:35:09:30
[QUAD] wolfie5	Alara3	A65:35:09:40
[QUAD] wolfie5	Ed	A65:36:29:52
[QUAD] wolfie5	Talla	A65:43:74:40
[QUAD] Fool	Base 10	A65:45:23:11
[QUAD] Fool	Base 13	A65:45:23:12
[QUAD] Fool	Base 9	A65:45:45:11
[QUAD] wolfie5	John	A65:45:45:20
[QUAD] wolfie5	Bortus	A65:47:46:50
[QUAD] wolfie5	Marcus	A65:57:22:21
[QUAD] Fool	Base 11	A65:62:49:21
[QUAD] Baxslash	Blyth	A65:78:18:12
[QUAD] Fool	Base 16	A66:14:74:20
[QUAD] Fool	Base 14	A66:24:06:11
[QUAD] Fool	Base 8	A66:24:61:11
[QUAD] The Cylons	Yoooooo	A66:25:25:10
[QUAD] The Cylons	Picon	A66:34:16:10
[QUAD] Bearded Angel	Happy	A66:39:43:11
[QUAD] The Cylons	Yyyyy	A66:41:45:10
[QUAD] Fool	Base 15	A66:45:77:31
[QUAD] The Cylons	Hhhhh	A66:51:87:10
[QUAD] The Cylons	Scorpia	A66:52:68:10
[QUAD] Fool	Base 4	A66:54:23:12
[QUAD] Fool	Base 3	A66:54:41:13
[QUAD] Fool	Base 2	A66:54:71:21
[QUAD] The Cylons	Tauron	A66:60:88:20
[QUAD] Fool	Base 5	A66:64:14:22
[QUAD] The Cylons	Caprica	A66:64:14:41
[QUAD] Fool	Base 1	A66:64:20:11
[QUAD] The Cylons	Amidala Prime	A66:64:33:20
[QUAD] Fool	Base 7	A66:65:45:11
[QUAD] Artemis	Ancient Tomb	A66:65:90:21
[QUAD] Fool	Base 12	A66:66:04:13
[QUAD] Fool	Base 6 G	A66:66:32:11
[QUAD] Artemis	Chantar	A66:74:13:11
[QUAD] Artemis	Home Planet	A66:75:35:11
[QUAD] Artemis	Reparo	A66:75:37:23
[QUAD] Artemis	Study Hall	A66:75:62:21
[QUAD] The Cylons	8888	A66:75:83:10
[QUAD] Artemis	Hydra	A66:75:88:21
[QUAD] Fool	Base 17	A66:76:98:40
[QUAD] Artemis	Terestia	A66:77:54:13
[QUAD] Artemis	Compani	A66:83:69:12
[QUAD] Mot	Urka	A67:97:34:22
[QUAD] razorfish	Kincaid	A68:76:07:21
[QUAD] ShadowX {Anime}	Star Wars	A68:81:67:11
[QUAD] Neo	St. Albans	A68:85:51:11
[QUAD] Mot	RAF Bentwaters	A69:12:56:21
[QUAD] Mot	RAF Woodbridge	A69:12:56:31
[QUAD] Philosopher Cody	Zepasi	A69:14:48:11
[QUAD] Philosopher Cody	Zepasi II	A69:16:04:12
[QUAD] Philosopher Cody	Zepasi III	A69:17:71:11
[QUAD] Corvidae	Blackhaven	A69:23:47:33
[QUAD] Corvidae	Riverspring	A69:25:65:32
[QUAD] Philosopher Cody	Zepasi VII	A69:27:91:11
[QUAD] GaiaForce (Ni)	Battlefield 2069	A69:28:80:21
[QUAD] Corvidae	Felwood	A69:30:59:52
[QUAD] Gejl	Starbase A69	A69:31:55:10
[QUAD] Gejl	Starbase A69	A69:31:57:10
[QUAD] Angry Clown (Ni)	Another one	A69:33:05:11
[QUAD] Corvidae	Dragonstone	A69:33:62:31
[QUAD] Corvidae	Torrhens Square	A69:36:32:51
[QUAD] Gejl	Starbase A69	A69:39:20:22
[QUAD] Corvidae	Nightsong	A69:39:20:31
[QUAD] Gejl	Starbase A69	A69:40:49:11
[QUAD] Gejl	Starbase A69 1	A69:41:63:10
[QUAD] Gejl	Starbase A69	A69:41:89:10
[QUAD] Gejl	Starbase A69*	A69:42:72:10
[QUAD] Philosopher Cody	Zepasi XIII	A69:43:28:11
[QUAD] Philosopher Cody	Zepasi XIV	A69:44:63:11
[QUAD] Creeda	Creedledad	A69:44:84:10
[QUAD] Corvidae	Crows Nest	A69:44:84:13
[QUAD] Philosopher Cody	Zepasi XV	A69:45:09:11
[QUAD] Corvidae	Ashemark	A69:46:53:11
[QUAD] Creeda	Creedledon	A69:46:81:20
[QUAD] Gejl	Starbase A69	A69:47:11:12
[QUAD] Gejl	Starbase A69	A69:47:46:11
[QUAD] Gejl	Starbase A69	A69:47:76:21
[QUAD] Gejl	Starbase A69	A69:47:79:11
[QUAD] Gejl	Starbase A69	A69:47:97:11
[QUAD] Corvidae	Kingsgrave	A69:48:80:23
[QUAD] Philosopher Cody	Zepasi XVIII	A69:50:09:11
[QUAD] Corvidae	Skyreach	A69:51:74:21
[QUAD] Gejl	Starbase A69	A69:52:14:11
[QUAD] Gejl	Starbase A69	A69:52:14:12
[QUAD] Gejl	Starbase A69	A69:52:32:11
[QUAD] Corvidae	Shatterstone	A69:53:14:31
[QUAD] Philosopher Cody	Zepasi XIX	A69:53:54:11
[QUAD] Creeda	Creedledin	A69:55:37:10
[QUAD] Corvidae	Last Hearth	A69:55:37:21
[QUAD] Philosopher Cody	Zepasi XXI	A69:55:45:11
[QUAD] Creeda	Creedleden	A69:56:59:20
[QUAD] Corvidae	Driftmark	A69:57:91:51
[QUAD] Horchata	Lornest	A69:60:59:11
[QUAD] Corvidae	Highgarden	A69:64:27:50
[QUAD] Creeda	Creedledan	A69:65:02:20
[QUAD] Corvidae	Gallowsgrey	A69:66:35:21
[QUAD] Philosopher Cody	Zepasi XXIV	A69:67:29:12
[QUAD] Gejl	Starbase A69	A69:72:47:11
[QUAD] Corvidae	Oakenshield	A69:72:54:42
[QUAD] Gejl	Starbase A69	A69:74:02:11
[QUAD] Gejl	Starbase A69	A69:74:02:12
[QUAD] Gejl	Starbase A69	A69:74:02:13
[QUAD] Zev	C69	A69:74:51:21
[QUAD] Sniper	Vico 12	A69:74:80:10
[QUAD] Angry Clown (Ni)	Nice C	A69:74:89:12
[QUAD] Corvidae	Hammerhorn	A69:75:73:51
[QUAD] AcidCore	69	A69:81:16:20
[QUAD] Corvidae	Iron Holt	A69:84:35:52
[QUAD] Creeda	Creedledust	A69:84:60:20
[QUAD] Lordvader	Terrifya	A70:03:53:53
[QUAD] KevinC (Ni) CLS	MEGADETH 7	A70:03:76:20
[QUAD] Lordvader	ryloth	A70:05:94:10
[QUAD] Lordvader	pantora	A70:12:53:41
[QUAD] Lordvader	bespin	A70:12:53:42
[QUAD] Lordvader	Starkiller base	A70:12:68:10
[QUAD] Lordvader	corusant	A70:12:89:10
[QUAD] quail 2.0	Chris m RF	A70:13:74:12
[QUAD] Cowpower	WONKA	A70:14:79:23
[QUAD] Lordvader	Tatoonee	A70:14:79:41
[QUAD] Helios	Hachendell	A70:18:94:20
[QUAD] TOPs	Arnolds Creek	A70:21:44:41
[QUAD] A RabidDragoon	X22	A70:22:01:10
[QUAD] conquistador	*STARGATE 70*	A70:23:78:10
[QUAD] A RabidDragoon	X21	A70:24:01:10
[QUAD] A RabidDragoon	X18	A70:24:09:10
[QUAD] A RabidDragoon	X17	A70:24:34:10
[QUAD] Cowpower	Ewewew	A70:24:44:30
[QUAD] Cub	70 Fith	A70:26:52:31
[QUAD] A.C.T.V.	Arturo Roger	A70:26:81:11
[QUAD] MAYAN Tiberas RQ/CT	VMF 333	A70:27:61:31
[QUAD] Cub	70 Seventh	A70:33:34:31
[QUAD] Cub	70 Eighth	A70:33:45:31
[QUAD] moeta	Aiur	A70:33:63:10
[QUAD] razorfish	Shadowlands	A70:33:93:21
[QUAD] Chosenone	Yay	A70:34:84:21
[QUAD] MAYAN Tiberas RQ/CT	VMAT102	A70:35:09:31
[QUAD] wolfie5	Charly	A70:35:71:11
[QUAD] A.C.T.V.	Pascal Kleimann	A70:36:25:11
[QUAD] A RabidDragoon	X10	A70:36:32:10
[QUAD] Scotch Bingington	Big Mac	A70:37:12:20
[QUAD] A.C.T.V.	Manolo PIRATA	A70:37:19:11
[QUAD] A.C.T.V.	Jorge Zamora	A70:37:28:31
[QUAD] Zev	A70	A70:37:75:11
[QUAD] Cowpower	Asha	A70:37:75:21
[QUAD] A RabidDragoon	X5	A70:37:85:10
[QUAD] A.C.T.V.	Fran Lenaers	A70:37:85:20
[QUAD] KevinC (Ni) CLS	MEGADETH 1	A70:38:00:21
[QUAD] Klaus	Atlantis	A70:39:64:21
[QUAD] KevinC (Ni) CLS	MEGADETH 6	A70:39:64:51
[QUAD] wolfie5	Yaphit	A70:41:27:31
[QUAD] TOPs	Pernod	A70:41:27:33
[QUAD] NightOwl280	4m-ft	A70:41:44:32
[QUAD] Cyndara	Base 05	A70:41:58:10
[QUAD] NightOwl280	umber70a	A70:41:82:21
[QUAD] KevinC (Ni) CLS	MEGADETH 8	A70:42:89:11
[QUAD] Bird Dog	Zurbarràn	A70:42:89:13
[QUAD] Zev	A70	A70:43:17:11
[QUAD] A.C.T.V.	€	A70:43:17:31
[QUAD] A.C.T.V.	£	A70:43:17:32
[QUAD] Cub	70 Tenth	A70:43:70:31
[QUAD] A.C.T.V.	#	A70:43:70:32
[QUAD] Lordvader	Yavin 4	A70:43:86:41
[QUAD] A RabidDragoon	X13	A70:44:37:10
[QUAD] A RabidDragoon	X14	A70:44:40:10
[QUAD] HarryTiger	Lindau	A70:45:10:21
[QUAD] A RabidDragoon	X12	A70:45:21:10
[QUAD] TOPs	Pentagram	A70:45:32:31
[QUAD] TOPs	Cambrian	A70:45:32:32
[QUAD] A RabidDragoon	X9	A70:45:82:10
[QUAD] A RabidDragoon	X7	A70:45:95:10
[QUAD] A RabidDragoon	X4	A70:45:98:10
[QUAD] Cub	70 Fourth	A70:46:13:31
[QUAD] Cub	70 Nine	A70:46:26:31
[QUAD] Gorgo	🌌	A70:46:42:10
[QUAD] A.C.T.V.	Josel Jimenez	A70:47:42:11
[QUAD] A.C.T.V.	Kike Jaen	A70:47:42:12
[QUAD] A.C.T.V.	Manolo MACHACA	A70:47:60:13
[QUAD] Mot	Pine Gap	A70:47:65:20
[QUAD] MAYAN Tiberas RQ/CT	1stMAW	A70:48:68:31
[QUAD] Horchata	Seconal	A70:49:13:20
[QUAD] moeta	BelShir	A70:51:45:10
[QUAD] Bird Dog	Castle Sol	A70:51:72:22
[QUAD] MAYAN Tiberas RQ/CT	MAG 11	A70:51:79:50
[QUAD] A RabidDragoon	X19	A70:52:15:10
[QUAD] A RabidDragoon	X16	A70:52:27:10
[QUAD] Bird Dog	Kaer Morhen	A70:52:30:13
[QUAD] A RabidDragoon	X20	A70:52:52:10
[QUAD] A.C.T.V.	@	A70:53:55:31
[QUAD] Cowpower	Deep Wall	A70:54:06:21
[QUAD] A RabidDragoon	X8	A70:54:09:10
[QUAD] A RabidDragoon	X11	A70:54:12:10
[QUAD] Raptor RQ/CT	Forzapolis	A70:54:47:11
[QUAD] DOOM	70-diy-rm/nm-w12	A70:54:65:20
[QUAD] A RabidDragoon	X6	A70:54:89:10
[QUAD] Raptor RQ/CT	Metropolis	A70:55:44:31
[QUAD] razorfish	arctis tor	A70:55:68:13
[QUAD] A RabidDragoon	X3	A70:55:82:10
[QUAD] A RabidDragoon	X23	A70:56:35:10
[QUAD] Raptor RQ/CT	Transfopolis	A70:56:60:31
[QUAD] A.C.T.V.	Andrés Llatas	A70:57:01:11
[QUAD] Raptor RQ/CT	Crystalpolis	A70:57:13:31
[QUAD] Cub	70 Sixth	A70:57:13:33
[QUAD] wolfie5	Klyden	A70:57:59:31
[QUAD] Bird Dog	USG Ishimura	A70:59:64:21
[QUAD] Sunshine	Genesis	A70:59:64:23
[QUAD] Mot	Dulce	A70:59:92:11
[QUAD] Sunshine	Spin	A70:60:79:32
[QUAD] wolfie5	Teleya	A70:63:06:22
[QUAD] Cub	70 Third	A70:64:42:31
[QUAD] wolfie5	Halsey	A70:65:08:21
[QUAD] A RabidDragoon	X2	A70:65:26:10
[QUAD] quail 2.0	Deep space 8	A70:65:51:11
[QUAD] quail 2.0	Star fleet hq	A70:65:59:11
[QUAD] Raptor RQ/CT	Zeropolis	A70:65:64:11
[QUAD] Raptor RQ/CT	Nestopolis*	A70:66:41:21
[QUAD] Cub	70 second	A70:66:56:31
[QUAD] Chosenone	yays	A70:66:74:11
[QUAD] Raptor RQ/CT	Teleiopolis	A70:67:37:31
[QUAD] A RabidDragoon	X1	A70:68:46:10
[QUAD] Hardgrave	Astro 9	A70:73:37:21
[QUAD] quail 2.0	Deep space 9	A70:73:47:11
[QUAD] razorfish	Lasciel	A70:73:47:21
[QUAD] quail 2.0	Fort hood c	A70:74:42:11
[QUAD] razorfish	Denali	A70:76:63:21
[QUAD] Ziggy(BS)	8675309	A70:83:24:11
[QUAD] quail 2.0	bs 7	A70:83:24:12
[QUAD] quail 2.0	Starbase 19 c	A70:83:24:13
[QUAD] A RabidDragoon	X15	A70:83:40:10
[QUAD] Ziggy(BS)	Jinkies	A70:83:65:11
[QUAD] corwin de amber	Space Rock 3	A70:84:13:21
[QUAD] razorfish	Dresden	A70:84:25:21
[QUAD] Ziggy(BS)	Toledo	A70:84:64:11
[QUAD] Ziggy(BS)	Sanctuary	A70:84:68:11
[QUAD] razorfish	Mouse	A70:84:77:12
[QUAD] NightOwl280	HotPink-hub	A70:84:98:12
[QUAD] Trapper	La Plata	A70:85:55:11
[QUAD] quail 2.0	Starbase 1 c	A70:86:60:11
[QUAD] quail 2.0	Starbase 14 c	A70:86:60:12
[QUAD] razorfish	Demonreach	A70:86:86:40
[QUAD] Cub	70 First	A70:87:05:21
[QUAD] Zev	A70	A70:87:38:20
[QUAD] Green Alien CARTEL ®	Chapter 6RJ70X9	A70:88:90:20
[QUAD] TOPs	Cluster	A70:96:07:22
[QUAD] razorfish	Bob the Skull	A70:96:10:20
[QUAD] Bearded Angel	Nightmarte	A70:96:74:11
[QUAD] Bearded Angel	Hum	A70:96:74:20
[QUAD] Sunshine	Lunar	A71:04:92:31
[QUAD] Angus	Lua	A71:12:74:11
[QUAD] JohnWick	Migh	A71:12:74:12
[QUAD] Angus	Tirion	A71:12:74:13
[QUAD] JohnWick	Juis	A71:13:77:11
[QUAD] Creeda	Creedan 3	A71:15:66:20
[QUAD] Koala boy	Beerstation	A71:15:84:21
[QUAD] Zev	A71	A71:16:07:11
[QUAD] Creeda	Creedaland	A71:16:53:21
[QUAD] Creeda	Jonnan 4	A71:16:55:11
[QUAD] moeta	Slayn	A71:16:67:11
[QUAD] Creeda	Creedan 4	A71:16:78:20
[QUAD] Creeda	Creedan	A71:16:78:21
[QUAD] Creeda	New Creedaland	A71:16:88:51
[QUAD] Koala boy	Woot	A71:22:46:11
[QUAD] Koala boy	Air Fryer	A71:23:35:21
[QUAD] JohnWick	huhki	A71:23:86:11
[QUAD] Creeda	Creedledee	A71:24:28:21
[QUAD] cuchillo	ngojumba kang	A71:24:37:12
[QUAD] JohnWick	Pierce	A71:24:37:13
[QUAD] JohnWick	Windsorf	A71:24:54:11
[QUAD] Angus	Ferrari	A71:24:67:11
[QUAD] Angus	Playground	A71:24:67:21
[QUAD] Creeda	Jonnan 1	A71:26:34:11
[QUAD] Creeda	Jonnan 2	A71:26:34:12
[QUAD] Creeda	Jonnan 3	A71:26:34:13
[QUAD] Creeda	Creedan 2	A71:27:13:20
[QUAD] cuchillo	cho oyu	A71:28:06:11
[QUAD] JohnWick	Kirill	A71:28:60:11
[QUAD] Angus	Handerburg	A71:28:60:13
[QUAD] Louise Vallière	Minerva	A71:31:00:20
[QUAD] Angus	Kedbe	A71:32:36:21
[QUAD] JohnWick	Anklo	A71:32:77:11
[QUAD] Zev	A71	A71:33:91:11
[QUAD] Angus	Werewolf	A71:34:47:21
[QUAD] Creeda	Creedledum	A71:35:21:21
[QUAD] JohnWick	Chases	A71:35:35:11
[QUAD] Angry Clown (Ni)	Base	A71:35:59:10
[QUAD] Creeda	Fort Creeda	A71:36:07:22
[QUAD] JohnWick	clear	A71:36:16:11
[QUAD] cuchillo	dhaula giri	A71:37:51:11
[QUAD] Angus	Playground	A71:37:76:21
[QUAD] Angus	Maine	A71:41:74:21
[QUAD] JohnWick	Calk	A71:41:82:11
[QUAD] Green Alien CARTEL ®	Chapter 11J71X7	A71:41:82:31
[QUAD] Lordvader	Tantis	A71:43:49:41
[QUAD] Angus	Club	A71:43:53:21
[QUAD] JohnWick	Thecontinental	A71:43:57:11
[QUAD] JohnWick	Heimatplanet	A71:43:57:41
[QUAD] Angus	BLASTER	A71:43:64:11
[QUAD] JohnWick	Playground	A71:43:64:12
[QUAD] Angus	Crasid	A71:43:64:13
[QUAD] cuchillo	gyachung kang	A71:43:94:11
[QUAD] Angus	Home Planet	A71:44:12:21
[QUAD] Angus	MUvhk	A71:44:24:22
[QUAD] Angus	Ankar	A71:44:24:23
[QUAD] JohnWick	Mache	A71:44:26:11
[QUAD] JohnWick	Castly	A71:44:38:11
[QUAD] Angus	heeghaa	A71:44:45:11
[QUAD] Koala boy	Ambar	A71:44:45:12
[QUAD] Angus	DANGER	A71:44:45:13
[QUAD] JohnWick	Anhu	A71:45:07:11
[QUAD] Artur	Gouda	A71:45:26:11
[QUAD] The Doci	71厂0	A71:45:61:11
[QUAD] cuchillo	yalung kang	A71:45:90:11
[QUAD] moeta	Char	A71:46:02:10
[QUAD] Sniper	Agro 15	A71:46:58:20
[QUAD] Klaus	Klaus Mikaelson	A71:46:95:10
[QUAD] Lordvader	kuat	A71:46:97:42
[QUAD] Green Alien CARTEL ®	Chapter 7J71X10	A71:51:09:11
[QUAD] cuchillo	ma kalu	A71:54:47:11
[QUAD] Koala boy	Anahhu	A71:54:74:11
[QUAD] cuchillo	ku tang	A71:57:24:11
[QUAD] Koala boy	Coke	A71:57:24:12
[QUAD] Buegur	Templer	A71:58:33:12
[QUAD] Lordvader	Hoth	A71:58:72:41
[QUAD] cuchillo	shisha pangma	A71:60:65:11
[QUAD] Koala boy	Bambu	A71:61:17:11
[QUAD] Koala boy	kilso	A71:61:17:12
[QUAD] Koala boy	Tricky	A71:61:17:13
[QUAD] Angry Clown (Ni)	Never	A71:63:52:11
[QUAD] Lordvader	kashyyk	A71:64:79:42
[QUAD] moeta	Zerus	A71:65:32:10
[QUAD] Koala boy	Anthony hawkins	A71:73:15:11
[QUAD] Koala boy	Sean connery	A71:73:15:12
[QUAD] Koala boy	Mando	A71:73:15:13
[QUAD] Koala boy	Justteh	A71:73:37:11
[QUAD] Koala boy	Unstoppable	A71:74:53:11
[QUAD] Koala boy	Manchester	A71:74:53:12
[QUAD] Koala boy	Playons	A71:74:70:11
[QUAD] Koala boy	Home Planet	A71:74:98:11
[QUAD] Angus	Mally	A71:75:41:12
[QUAD] JohnWick	Balti	A71:76:04:11
[QUAD] cuchillo	deo mir	A71:76:51:12
[QUAD] Klaus	Stefan Salvator@	A71:77:56:10
[QUAD] Lordvader	Utapau	A71:79:43:41
[QUAD] ShadowX {Anime}	Giver	A71:79:43:42
[QUAD] cuchillo	anna purna	A71:82:06:11
[QUAD] JohnWick	Kaos	A71:82:06:12
[QUAD] Buegur	Harp	A71:85:08:11
[QUAD] Axel27	Raluca	A71:85:08:21
[QUAD] Koala boy	okhu	A71:85:13:13
[QUAD] Angus	Naomi	A71:94:12:23
[QUAD] Sunshine	SanSan	A71:94:18:21
[QUAD] Lordvader	wayland	A71:97:25:41
[QUAD] Cowpower	A02	A72:05:26:21
[QUAD] Cowpower	A03	A72:05:90:21
[QUAD] Raptor RQ/CT	Dynapolis	A72:13:90:22
[QUAD] Cowpower	RnD 01	A72:13:98:20
[QUAD] Sunshine	Mumbad	A72:13:98:22
[QUAD] - RaVeN -	13	A72:14:58:11
[QUAD] Braveheart	Woodstock	A72:15:44:13
[QUAD] AcidCore	72_3D	A72:16:22:13
[QUAD] Green Alien CARTEL ®	Chapter 8PJ72X7	A72:17:34:11
[QUAD] Klaus	Elizabeth Forbes	A72:17:53:10
[QUAD] - RaVeN -	14	A72:17:70:11
[QUAD] Braveheart	Offspring	A72:17:70:12
[QUAD] Braveheart	Double	A72:17:70:13
[QUAD] Hardgrave	Astro 10	A72:18:98:21
[QUAD] - RaVeN -	16	A72:21:29:21
[QUAD] AcidCore	72_2D	A72:22:76:11
[QUAD] Braveheart	Farrawel	A72:23:36:12
[QUAD] AcidCore	72_1D	A72:23:51:13
[QUAD] Tomcruiser	Martinitown	A72:23:63:11
[QUAD] Braveheart	er5t6	A72:25:16:11
[QUAD] Braveheart	Kilah	A72:25:16:12
[QUAD] Braveheart	Tomorrow	A72:25:16:13
[QUAD] Zev	LCrS1	A72:25:57:11
[QUAD] Cowpower	A01	A72:25:70:21
[QUAD] Louise Vallière	Aprilius One	A72:25:78:21
[QUAD] Braveheart	Home Planet	A72:26:25:11
[QUAD] Cowpower	RnD 02	A72:26:40:20
[QUAD] Braveheart	Thoma	A72:26:54:11
[QUAD] Braveheart	Alosubs	A72:26:54:12
[QUAD] MAYAN Tiberas RQ/CT	HMS 11	A72:26:67:11
[QUAD] Sniper	Pix 12	A72:26:96:20
[QUAD] - RaVeN -	17	A72:31:73:11
[QUAD] Gary	Aurora	A72:33:35:11
[QUAD] Gary	Red Mountain	A72:33:83:11
[QUAD] Gary	Train	A72:33:83:12
[QUAD] Tomcruiser	Topgun	A72:33:90:13
[QUAD] Cub	2 first	A72:34:31:31
[QUAD] Braveheart	Marilao	A72:34:37:21
[QUAD] Cowpower	C72 02	A72:34:74:11
[QUAD] Raptor RQ/CT	Polopolis	A72:34:74:21
[QUAD] Cub	2 Second	A72:35:26:31
[QUAD] Green Alien CARTEL ®	Chapter 10JS72X8	A72:35:47:11
[QUAD] Braveheart	Unusual	A72:35:52:13
[QUAD] Braveheart	Chewie	A72:36:02:11
[QUAD] Sniper	Micro 12	A72:36:34:21
[QUAD] Sniper	Kiro 12	A72:36:95:13
[QUAD] Braveheart	Joincon	A72:37:14:12
[QUAD] Braveheart	Anmo	A72:37:14:13
[QUAD] Darkfallen	Molobo	A72:37:89:11
[QUAD] Braveheart	Buster	A72:38:05:11
[QUAD] Braveheart	D12	A72:38:24:11
[QUAD] Braveheart	Elora	A72:38:24:13
[QUAD] Green Alien CARTEL ®	Chapter 9RP72X7	A72:38:57:10
[QUAD] MAYAN Tiberas RQ/CT	Zebra	A72:41:44:21
[QUAD] Darkfallen	Malware	A72:42:17:12
[QUAD] Darkfallen	Klosd	A72:42:17:13
[QUAD] Sniper	Necro 12	A72:43:06:23
[QUAD] Cowpower	C72 03	A72:43:65:11
[QUAD] Raptor RQ/CT	Casiopolis	A72:44:33:22
[QUAD] Zev	LCrS2	A72:44:49:11
[QUAD] Cowpower	C72 01	A72:44:99:12
[QUAD] Darkfallen	Spycom	A72:45:17:11
[QUAD] Darkfallen	Annaht	A72:45:17:12
[QUAD] Sniper	Stine 12	A72:45:85:20
[QUAD] Sniper	Gyro 12	A72:46:04:30
[QUAD] Sniper	Cane 12	A72:46:09:21
[QUAD] Sniper	Egress 12	A72:46:13:21
[QUAD] Sniper	Leper 12	A72:46:13:23
[QUAD] Sniper	Hydro 12	A72:46:13:40
[QUAD] Sniper	Diamond 12	A72:46:39:10
[QUAD] Sniper	Figaro 12	A72:46:39:40
[QUAD] Tomcruiser	Destructor	A72:46:64:11
[QUAD] Sniper	Jupiter 12	A72:46:64:21
[QUAD] Gary	Tundra	A72:46:86:11
[QUAD] Sniper	Icon 12	A72:46:90:20
[QUAD] Sniper	Bingo 16	A72:47:30:10
[QUAD] Darkfallen	Anaha	A72:47:37:11
[QUAD] Klaus	Caroline Forbes	A72:47:39:10
[QUAD] Gary	Artic Char	A72:47:45:11
[QUAD] Gary	Red lake	A72:47:45:21
[QUAD] MAYAN Tiberas RQ/CT	Coffee	A72:47:56:11
[QUAD] Gary	Polar Bear	A72:47:56:31
[QUAD] Gary	Snowy Owl	A72:47:72:11
[QUAD] Gary	Home Planet	A72:47:72:41
[QUAD] Gary	Iceland	A72:48:31:11
[QUAD] Gary	Ellesmere	A72:48:31:12
[QUAD] Gary	Green river	A72:48:31:13
[QUAD] - RaVeN -	15	A72:48:53:11
[QUAD] Gary	Baffin	A72:49:71:11
[QUAD] - RaVeN -	11	A72:51:38:21
[QUAD] Gary	Walrus	A72:51:75:21
[QUAD] Tomcruiser	Clamsy	A72:52:99:11
[QUAD] Gorgo	👨‍👨‍👧‍👦	A72:54:29:10
[QUAD] Louise Vallière	Macross	A72:54:39:31
[QUAD] Gorgo	🐴	A72:54:68:10
[QUAD] Darkfallen	Justin	A72:54:96:11
[QUAD] Gary	Puffin	A72:55:05:11
[QUAD] DOOM	72-987-mu/re-w04	A72:55:23:10
[QUAD] The Doci	72厂0	A72:55:25:11
[QUAD] Tomcruiser	ghuap	A72:55:60:13
[QUAD] Raptor RQ/CT	Xenopolis*	A72:56:34:11
[QUAD] Sniper	Reckt 12	A72:56:42:21
[QUAD] - RaVeN -	2	A72:56:47:11
[QUAD] KevinC (Ni) CLS	MEGADETH 4	A72:56:47:31
[QUAD] Sniper	Quint 11	A72:56:49:12
[QUAD] Tomcruiser	Killah	A72:56:63:11
[QUAD] Tomcruiser	Hutt	A72:57:17:11
[QUAD] Tomcruiser	Amazeus	A72:57:22:13
[QUAD] Tomcruiser	Turnig	A72:57:81:11
[QUAD] Tomcruiser	Aroha	A72:57:81:21
[QUAD] Klaus	Jeremy Gilbert @	A72:60:99:40
[QUAD] Darkfallen	ANAHIA	A72:62:18:11
[QUAD] Darkfallen	Stronghold	A72:63:09:21
[QUAD] Darkfallen	Tirak	A72:63:92:11
[QUAD] Darkfallen	Jander	A72:64:46:11
[QUAD] Darkfallen	Baltimore	A72:64:68:11
[QUAD] Darkfallen	Drew	A72:64:80:11
[QUAD] Darkfallen	Areia	A72:64:80:12
[QUAD] Darkfallen	Letterman	A72:64:80:13
[QUAD] Darkfallen	Home Planet	A72:64:89:11
[QUAD] Tomcruiser	Wellington	A72:65:62:21
[QUAD] Tomcruiser	Anakin	A72:65:91:11
[QUAD] Sniper	Omni 12	A72:66:03:13
[QUAD] - RaVeN -	3	A72:66:16:11
[QUAD] Tomcruiser	Jumper	A72:66:22:11
[QUAD] Tomcruiser	Home Planet	A72:66:75:13
[QUAD] Klaus	Nina Dobrev	A72:67:47:10
[QUAD] Tomcruiser	Javit	A72:68:26:11
[QUAD] - RaVeN -	18	A72:68:34:11
[QUAD] Gary	Greenland	A72:68:34:21
[QUAD] Tomcruiser	Plackter	A72:68:85:11
[QUAD] Raptor RQ/CT	Degrapolis	A72:73:32:21
[QUAD] - RaVeN -	1	A72:73:48:11
[QUAD] Klaus	Emily Bennett	A72:74:20:13
[QUAD] Klaus	Finn Mikaelson	A72:74:29:11
[QUAD] Klaus	Enzo	A72:74:64:11
[QUAD] Klaus	Kol Mikaelson	A72:74:76:10
[QUAD] Klaus	Lexi Branson	A72:74:93:11
[QUAD] Klaus	Alaric Saltzman	A72:75:74:11
[QUAD] Tomcruiser	Banshee	A72:76:07:11
[QUAD] Klaus	Matt Donovan	A72:87:05:11
[QUAD] Darkfallen	Playoff	A72:87:05:21
[QUAD] Darkfallen	Bolton	A72:88:72:21
[QUAD] moeta	Zhakul	A72:93:10:10
[QUAD] - RaVeN -	12	A72:95:20:21
[QUAD] Sunshine	Flashpoint	A72:95:32:21
[QUAD] ShadowX {Anime}	Prince of Tennis	A72:97:33:31
[QUAD] Timcanpy	Hek	A73:04:57:21
[QUAD] AcidCore	73_1D	A73:12:49:21
[QUAD] Chani	Gym	A73:14:79:10
[QUAD] Gorgo	🈁	A73:15:34:10
[QUAD] Chani	Tarus	A73:23:15:31
[QUAD] Gorgo	🕋	A73:25:43:11
[QUAD] AcidCore	73_2	A73:26:09:21
[QUAD] Klaus	Tyler Lockwood @	A73:26:21:13
[QUAD] Klaus	Katherine Pierce	A73:26:94:11
[QUAD] Synod	Haven	A73:32:35:10
[QUAD] Chani	Aries	A73:33:17:11
[QUAD] Chani	Cancer	A73:33:36:10
[QUAD] Klaus	Wednessday Adams	A73:33:50:13
[QUAD] Synod	Gregor	A73:34:68:10
[QUAD] Synod	Gryphon	A73:37:98:10
[QUAD] Royal Canadian Corp.	E.TonyMontanaPWR	A73:42:53:11
[QUAD] Chani	Capricornius	A73:42:95:11
[QUAD] Chani	Tifu	A73:43:25:13
[QUAD] Synod	Grendelsbane	A73:43:39:10
[QUAD] Synod	Sphinx	A73:43:52:10
[QUAD] Chani	Sagittarius	A73:43:54:11
[QUAD] Chani	Leo	A73:43:54:12
[QUAD] Chani	Pegasus	A73:43:54:13
[QUAD] moeta	Braxis	A73:44:00:12
[QUAD] Synod	Grayson	A73:44:33:10
[QUAD] Chani	Morfeus	A73:44:53:10
[QUAD] Chani	Piscis	A73:44:59:10
[QUAD] Synod	Manticore	A73:45:14:10
[QUAD] Synod	Treadway	A73:45:65:10
[QUAD] Zev	A73	A73:46:41:11
[QUAD] Synod	Torch	A73:46:66:10
[QUAD] Sunshine	Red Sand	A73:48:17:21
[QUAD] Zev	A73	A73:48:24:21
[QUAD] Helios	Ashes of Thrax	A73:49:53:20
[QUAD] Sunshine	Kitara	A73:51:49:21
[QUAD] Synod	Spindle	A73:54:29:11
[QUAD] Synod	Alizon	A73:54:56:10
[QUAD] The Doci	73厂0	A73:55:33:11
[QUAD] Chani	NOSFERATUNM	A73:55:69:11
[QUAD] Chani	Blastery	A73:55:86:20
[QUAD] Chani	A	A73:55:98:11
[QUAD] Chani	Gemini	A73:57:38:10
[QUAD] AcidCore	73_4 T	A73:58:67:20
[QUAD] Sniper	Toxic 16	A73:61:85:21
[QUAD] Timcanpy	Delve*	A73:63:39:23
[QUAD] Timcanpy	Rens	A73:64:25:31
[QUAD] Timcanpy	Domain	A73:64:47:21
[QUAD] Gorgo	🚇	A73:64:67:10
[QUAD] Chani	Virgo	A73:68:93:31
[QUAD] MAYAN Tiberas RQ/CT	Crackers	A73:71:13:41
[QUAD] Synod	Seaford	A73:73:19:10
[QUAD] Timcanpy	Jita	A73:73:68:20
[QUAD] AcidCore	XX_3D	A73:73:72:11
[QUAD] Horchata	Barry	A73:74:32:12
[QUAD] Synod	Talbott	A73:75:93:10
[QUAD] Timcanpy	Amarr	A73:78:72:10
[QUAD] Timcanpy	The Forge	A73:95:30:20
[QUAD] Chani	Gemini	A73:97:41:20
[QUAD] AcidCore	74_1	A74:04:91:11
[QUAD] JUCAPETA	F006	A74:12:57:10
[QUAD] - RaVeN -	4	A74:12:57:21
[QUAD] - RaVeN -	5	A74:13:59:11
[QUAD] AcidCore	74_2D	A74:15:19:21
[QUAD] - RaVeN -	6	A74:15:56:11
[QUAD] Dalton	Pool10	A74:15:87:10
[QUAD] - RaVeN -	7	A74:17:42:11
[QUAD] Horchata	Sangreal	A74:17:42:12
[QUAD] Maverick_pt	Edoras	A74:21:09:20
[QUAD] - RaVeN -	10	A74:21:72:21
[QUAD] Dalton	Pool 12	A74:22:46:10
[QUAD] - RaVeN -	9	A74:22:92:11
[QUAD] Gorgo	👩🏽‍🦳	A74:23:04:10
[QUAD] - RaVeN -	8	A74:23:13:11
[QUAD] Mr Chance	14	A74:23:53:11
[QUAD] quail 2.0	Deep space 29 c	A74:24:20:21
[QUAD] Zev	A74	A74:24:28:11
[QUAD] AcidCore	74_4 D	A74:24:47:11
[QUAD] quail 2.0	Deep space 1 c	A74:24:66:11
[QUAD] quail 2.0	ds24	A74:25:15:11
[QUAD] JUCAPETA	E005	A74:25:41:10
[QUAD] quail 2.0	hhggy	A74:25:73:11
[QUAD] Mr Chance	13	A74:26:60:11
[QUAD] quail 2.0	denver	A74:28:80:11
[QUAD] Maverick_pt	Utumno	A74:29:73:21
[QUAD] quail 2.0	alpha knight c	A74:31:39:21
[QUAD] Zev	A74	A74:31:76:11
[QUAD] Zev	A74	A74:32:76:11
[QUAD] Gorgo	🙀	A74:32:97:10
[QUAD] Dalton	Pool9	A74:32:97:31
[QUAD] JUCAPETA	G007	A74:33:63:10
[QUAD] AcidCore	74_5 TC	A74:33:79:20
[QUAD] Gorgo	🤦🏻	A74:34:59:10
[QUAD] Maverick_pt	Mordor	A74:34:59:13
[QUAD] DOOM	74-wtf-mu/re-w05	A74:34:99:10
[QUAD] Maverick_pt	Annuminas	A74:35:50:21
[QUAD] Maverick_pt	Forochel	A74:35:50:22
[QUAD] Dalton	Chester	A74:35:52:11
[QUAD] Raptor RQ/CT	Micropolis*	A74:36:13:21
[QUAD] Raptor RQ/CT	Xtrapolis	A74:36:13:22
[QUAD] quail 2.0	Austin	A74:36:72:21
[QUAD] quail 2.0	quails new home	A74:36:79:12
[QUAD] Mr Chance	16	A74:36:85:10
[QUAD] AcidCore	74_3	A74:36:85:21
[QUAD] quail 2.0	Starbase 24 c	A74:37:74:11
[QUAD] Dalton	Pool11	A74:38:32:10
[QUAD] Gorgo	🛀🏼	A74:41:18:11
[QUAD] Gorgo	🎻	A74:41:26:11
[QUAD] Gorgo	👨‍👧‍👦	A74:41:26:12
[QUAD] Dalton	Pool8	A74:41:26:13
[QUAD] Gorgo	👢	A74:41:26:30
[QUAD] JUCAPETA	C003	A74:41:68:10
[QUAD] Gorgo	📗	A74:41:87:10
[QUAD] Gorgo	🗂	A74:41:87:20
[QUAD] Gorgo	🛃	A74:41:87:31
[QUAD] Gorgo	🌴	A74:41:87:50
[QUAD] Gorgo	👨🏼‍🎓	A74:41:87:51
[QUAD] Gorgo	🐞	A74:41:87:52
[QUAD] Mr Chance	11	A74:41:98:12
[QUAD] Gorgo	🧑‍🚀	A74:42:69:10
[QUAD] Mr Chance	8	A74:43:21:11
[QUAD] Maverick_pt	Rivendel	A74:43:99:21
[QUAD] Gorgo	🚶🏼‍♂️	A74:44:60:10
[QUAD] Dalton	Cool15	A74:45:09:11
[QUAD] Mr Chance	15	A74:45:14:11
[QUAD] The Doci	74厂0	A74:45:95:11
[QUAD] Dalton	Pool4	A74:50:39:11
[QUAD] Sunshine	Ashes	A74:50:39:31
[QUAD] Dalton	Pool1	A74:51:88:51
[QUAD] JUCAPETA	L013	A74:52:14:10
[QUAD] Dalton	Pool3	A74:52:52:11
[QUAD] Dalton	Pool6	A74:52:67:31
[QUAD] Mr Chance	9	A74:52:94:11
[QUAD] Dalton	Pool2	A74:53:07:10
[QUAD] Dalton	Pool5	A74:53:71:10
[QUAD] Gorgo	🤦🏽‍♀️	A74:54:19:10
[QUAD] AcidCore	74_7	A74:55:50:11
[QUAD] Mr Chance	1	A74:55:50:12
[QUAD] Gorgo	🥵	A74:56:29:10
[QUAD] JUCAPETA	A001	A74:57:54:10
[QUAD] JUCAPETA	Home Planet	A74:57:63:21
[QUAD] AcidCore	74_6 T	A74:58:46:10
[QUAD] JUCAPETA	K012	A74:58:86:10
[QUAD] Mr Chance	12	A74:60:54:21
[QUAD] Dalton	Pool7	A74:61:34:11
[QUAD] Dalton	Pool 14	A74:61:34:12
[QUAD] Maverick_pt	Gundabad	A74:61:54:21
[QUAD] Gorgo	🪖	A74:62:77:10
[QUAD] Mr Chance	7	A74:64:92:11
[QUAD] JUCAPETA	J011	A74:65:35:10
[QUAD] Dalton	Pool 13	A74:65:75:10
[QUAD] Zev	A74	A74:71:44:31
[QUAD] A Cup of Tea	Hot Dog	A74:72:98:21
[QUAD] A Cup of Tea	Cookies	A74:73:72:20
[QUAD] Mr Chance	17	A74:73:78:11
[QUAD] Maverick_pt	Numenor	A74:73:82:20
[QUAD] Mr Chance	4	A74:73:91:11
[QUAD] Zev	A74	A74:74:10:13
[QUAD] JUCAPETA	B002	A74:74:83:10
[QUAD] Mr Chance	3	A74:75:98:11
[QUAD] Timcanpy	Providence	A74:76:29:21
[QUAD] Mr Chance	10	A74:76:40:21
[QUAD] JUCAPETA	D004	A74:78:31:10
[QUAD] JUCAPETA	H009	A74:78:31:21
[QUAD] Timcanpy	Domain*	A74:82:20:11
[QUAD] Mr Chance	2	A74:82:53:21
[QUAD] Mr Chance	6	A74:84:36:11
[QUAD] JUCAPETA	I010	A74:92:37:10
[QUAD] Mr Chance	5	A74:93:05:11
[QUAD] Maverick_pt	Nargothrond	A74:95:15:40
[QUAD] AcidCore	74_8	A74:96:21:31
[QUAD] moeta	Vardona	A74:97:26:13
[QUAD] Horchata	Lycopsid	A75:12:19:11
[QUAD] Klaus	Elena Gilbert @	A75:20:87:21
[QUAD] Dr. Jones	Dr.Oetker	A75:30:57:10
[QUAD] Dr. Jones	Dr.Fred	A75:30:57:32
[QUAD] Dr. Jones	Dr.William	A75:30:57:40
[QUAD] Dr. Jones	Dr. Malcom	A75:30:57:50
[QUAD] Red Momma	22	A75:32:16:21
[QUAD] Dr. Jones	DR.WEST	A75:33:25:11
[QUAD] Dr. Jones	Dr.bat	A75:33:25:12
[QUAD] Red Momma	23	A75:34:01:21
[QUAD] Zev	A75	A75:34:48:31
[QUAD] Dr. Jones	DR.clast	A75:35:34:11
[QUAD] A Cup of Tea	Yum Disc	A75:35:35:21
[QUAD] AcidCore	75_2	A75:35:67:21
[QUAD] Hardgrave	75-1	A75:39:01:21
[QUAD] Hardgrave	75-2	A75:39:01:22
[QUAD] Hardgrave	75-3	A75:39:01:23
[QUAD] Dr. Jones	DR.NASTER	A75:41:99:11
[QUAD] AcidCore	75_3D	A75:43:82:11
[QUAD] A Cup of Tea	Chilli Cheese	A75:45:31:21
[QUAD] The Doci	75厂0	A75:45:92:11
[QUAD] Dr. Jones	dR.wRIGHT	A75:46:44:11
[QUAD] MAYAN Tiberas RQ/CT	Blue lite	A75:49:82:10
[QUAD] JJE	5.7	A75:50:47:11
[QUAD] AcidCore	XX_1	A75:53:57:11
[QUAD] Dr. Jones	dR.lOVE	A75:54:19:11
[QUAD] Bird Dog	The Swallow	A75:54:22:13
[QUAD] Bird Dog	Castle Ensis	A75:55:38:21
[QUAD] Dr. Jones	dR.Matter	A75:56:23:11
[QUAD] MAYAN Tiberas RQ/CT	revenge	A75:62:95:10
[QUAD] Creeda	Creedledig	A75:64:09:11
[QUAD] Dr. Jones	dR.LIVE	A75:64:75:11
[QUAD] Dr. Jones	dR.cOTY	A75:64:75:23
[QUAD] Dr. Jones	Dr.Cutty	A75:67:79:11
[QUAD] Dr. Jones	Dr.house	A75:67:79:12
[QUAD] Dr. Jones	dr.written	A75:67:79:13
[QUAD] KevinC (Ni) CLS	MEGADETH 2	A75:69:92:42
[QUAD] Zev	A75	A75:74:27:11
[QUAD] Hardgrave	Astro 11	A76:03:49:21
[QUAD] Hardgrave	Astro 12	A76:03:49:31
[QUAD] Ashley	Dinasty	A76:03:91:21
[QUAD] Hardgrave	Astro 16	A76:03:91:22
[QUAD] Ashley	Buster	A76:15:70:11
[QUAD] Ashley	Monster	A76:18:40:32
[QUAD] Ashley	Poky	A76:25:47:11
[QUAD] KevinC (Ni) CLS	MEGADETH 5	A76:26:09:41
[QUAD] Aether	Saphire	A76:26:16:20
[QUAD] Ashley	Milky	A76:27:73:11
[QUAD] Hardgrave	Astro 7	A76:30:78:11
[QUAD] Hardgrave	Astro 8	A76:30:78:21
[QUAD] Ashley	Scotch	A76:32:15:21
[QUAD] Aether	Ruby	A76:32:66:11
[QUAD] Ashley	Anom	A76:33:16:11
[QUAD] Ashley	Harbour	A76:33:35:11
[QUAD] Ashley	Mallaster	A76:33:35:12
[QUAD] Red Momma	1	A76:33:73:21
[QUAD] Red Momma	2	A76:34:05:21
[QUAD] Aether	Lacrimosa	A76:34:56:11
[QUAD] Ashley	Moltobenne	A76:34:61:11
[QUAD] Ashley	Butler	A76:35:19:11
[QUAD] Red Momma	3	A76:35:86:21
[QUAD] Ashley	MOSCU	A76:36:59:11
[QUAD] Ashley	Stray	A76:37:23:12
[QUAD] Ashley	Startro	A76:37:23:13
[QUAD] Ashley	Home Planet	A76:38:03:31
[QUAD] Red Momma	4	A76:39:10:21
[QUAD] Hardgrave	Astro 15	A76:39:43:21
[QUAD] Red Momma	5	A76:41:19:21
[QUAD] Red Momma	6	A76:43:08:21
[QUAD] Red Momma	7	A76:44:24:21
[QUAD] DOOM	76-ata-mu/re-w06	A76:44:85:10
[QUAD] Aether	Diamond	A76:45:01:13
[QUAD] Red Momma	8	A76:45:22:21
[QUAD] The Doci	76厂0	A76:45:33:11
[QUAD] Aether	Calaban	A76:46:82:20
[QUAD] MAYAN Tiberas RQ/CT	semper Fi	A76:46:94:30
[QUAD] Ashley	Ballsy	A76:47:23:12
[QUAD] Red Momma	9	A76:47:31:21
[QUAD] Ashley	Gin	A76:47:31:22
[QUAD] Ashley	Vodka	A76:48:04:12
[QUAD] Horchata	Litas	A76:49:90:11
[QUAD] Mot	AUTEC	A76:49:90:31
[QUAD] Red Momma	10	A76:52:23:21
[QUAD] Red Momma	13	A76:53:15:21
[QUAD] Aether	Centronom	A76:53:48:10
[QUAD] quail 2.0	Fort Lauderdale	A76:54:04:11
[QUAD] quail 2.0	ds 25	A76:54:46:11
[QUAD] Red Momma	11	A76:54:49:21
[QUAD] Aether	Olympia	A76:54:64:11
[QUAD] MAYAN Tiberas RQ/CT	2nd MAW	A76:55:00:31
[QUAD] Red Momma	12	A76:55:35:21
[QUAD] Horchata	Docusoap	A76:55:81:11
[QUAD] Red Momma	14	A76:56:11:21
[QUAD] Aether	Lyanden	A76:56:37:22
[QUAD] Red Momma	15	A76:58:37:21
[QUAD] JJE	6.7	A76:61:40:10
[QUAD] Red Momma	16	A76:63:04:21
[QUAD] Aether	Elysia	A76:64:22:20
[QUAD] Creeda	Creedledaft	A76:65:92:22
[QUAD] Red Momma	17	A76:66:47:21
[QUAD] Red Momma	18	A76:67:41:21
[QUAD] Red Momma	19	A76:71:14:21
[QUAD] Zev	BRK1	A76:71:78:11
[QUAD] Red Momma	20	A76:72:44:21
[QUAD] Aether	Kingdoms End	A76:73:94:12
[QUAD] Creeda	Creedledoom	A76:74:09:21
[QUAD] Aether	Sigma Draconis	A76:74:23:21
[QUAD] Aether	Emerald	A76:78:25:10
[QUAD] Zev	BAS1	A76:82:23:11
[QUAD] Red Momma	21	A76:86:90:21
[QUAD] Hardgrave	Astro 14	A77:03:68:11
[QUAD] Hardgrave	Astro 13	A77:03:68:21
[QUAD] Hardgrave	Astro 4	A77:04:63:11
[QUAD] Hardgrave	Astro 5	A77:04:63:12
[QUAD] Hardgrave	Astro 6	A77:04:63:13
[QUAD] Louise Vallière	Artemis	A77:05:96:11
[QUAD] MadOwnage!	Chadwell Heath	A77:13:97:12
[QUAD] Forrester	Talky	A77:15:46:11
[QUAD] Horchata	Diluviums	A77:18:80:11
[QUAD] Axel27	Antonica	A77:21:74:20
[QUAD] MadOwnage!	Woolwich	A77:23:83:11
[QUAD] MadOwnage!	Rainham	A77:24:00:20
[QUAD] MadOwnage!	Redbridge	A77:24:20:10
[QUAD] MadOwnage!	Barking	A77:24:58:21
[QUAD] MadOwnage!	Ilford	A77:24:87:11
[QUAD] MadOwnage!	Dagenham	A77:24:97:20
[QUAD] MadOwnage!	Home Planet	A77:24:97:51
[QUAD] MadOwnage!	Loxford	A77:24:97:52
[QUAD] MadOwnage!	Tower Hamlets	A77:25:00:21
[QUAD] Goku	Cersr	A77:25:69:11
[QUAD] Forrester	Bill	A77:25:82:11
[QUAD] Axel27	Anastasia	A77:25:82:21
[QUAD] Cuyito	Derry	A77:25:85:13
[QUAD] MadOwnage!	Dagenham East	A77:25:85:31
[QUAD] Goku	Boo	A77:26:50:11
[QUAD] Goku	Arch	A77:26:50:12
[QUAD] MadOwnage!	Mile End	A77:26:68:31
[QUAD] moeta	New Folsom	A77:28:98:12
[QUAD] Forrester	Jimbo	A77:32:42:21
[QUAD] Forrester	Mandy	A77:32:42:22
[QUAD] Minister Of Rejects	Sabaoth	A77:32:67:11
[QUAD] Minister Of Rejects	Diokles	A77:32:97:30
[QUAD] Minister Of Rejects	Perses	A77:33:20:11
[QUAD] Minister Of Rejects	Amon	A77:33:43:11
[QUAD] Cuyito	Cap	A77:33:61:11
[QUAD] MadOwnage!	Seven Kings	A77:33:66:21
[QUAD] Minister Of Rejects	Hydra	A77:33:84:11
[QUAD] MadOwnage!	Eastham	A77:34:14:11
[QUAD] Goku	Playst	A77:34:14:12
[QUAD] MadOwnage!	Stratford	A77:34:14:13
[QUAD] MadOwnage!	Beckton	A77:34:39:21
[QUAD] MadOwnage!	Manor Park	A77:35:01:22
[QUAD] Goku	Castle	A77:35:54:11
[QUAD] Goku	Knight	A77:37:22:22
[QUAD] MadOwnage!	Bow	A77:37:44:21
[QUAD] Minister Of Rejects	Tribes Gods	A77:42:19:11
[QUAD] Axel27	Angelica	A77:42:19:21
[QUAD] Minister Of Rejects	Heron	A77:42:75:11
[QUAD] Minister Of Rejects	Orpheus JG	A77:43:14:11
[QUAD] Minister Of Rejects	Alexander	A77:43:91:11
[QUAD] Minister Of Rejects	Charon	A77:44:14:11
[QUAD] Cuyito	YARP	A77:44:48:10
[QUAD] Zev	A77	A77:44:60:11
[QUAD] Axel27	Adriana	A77:45:16:21
[QUAD] MadOwnage!	Plaistow	A77:45:29:13
[QUAD] MadOwnage!	Custom House	A77:45:29:21
[QUAD] Cuyito	RFC	A77:45:72:10
[QUAD] Goku	Manhattan	A77:46:12:11
[QUAD] Goku	San Francisco	A77:46:12:12
[QUAD] Sticky	Vegeta	A77:46:12:13
[QUAD] Goku	Vegeta	A77:46:12:21
[QUAD] Goku	Earth	A77:46:58:11
[QUAD] Goku	Namek	A77:46:63:11
[QUAD] Goku	Krilin	A77:46:71:11
[QUAD] Goku	Yamcha	A77:46:71:21
[QUAD] Sticky	Master	A77:47:11:21
[QUAD] Goku	Picolo	A77:48:49:11
[QUAD] Sticky	Milhouse	A77:48:78:11
[QUAD] Axel27	Ana	A77:48:97:10
[QUAD] Sticky	Wharehouse	A77:49:01:11
[QUAD] Sticky	Strand	A77:49:01:12
[QUAD] Sticky	Mainvillage	A77:49:87:12
[QUAD] Goku	Gohan	A77:49:87:13
[QUAD] quail 2.0	ironwolf	A77:51:44:11
[QUAD] quail 2.0	bs 4	A77:51:44:12
[QUAD] quail 2.0	bs6	A77:51:44:13
[QUAD] MadOwnage!	Maryland	A77:52:74:21
[QUAD] Forrester	Time	A77:53:06:11
[QUAD] Forrester	Atomicroid	A77:53:06:12
[QUAD] Forrester	kotah	A77:53:06:13
[QUAD] The Doci	77厂0	A77:54:15:11
[QUAD] Creeda	Creedledot	A77:54:94:12
[QUAD] Goku	Android	A77:55:78:11
[QUAD] Louise Vallière	Gate 04	A77:59:66:11
[QUAD] Forrester	ATLANTIS	A77:62:27:11
[QUAD] Goku	Moneychase	A77:62:27:21
[QUAD] Sticky	blonde	A77:63:35:11
[QUAD] Forrester	Neil	A77:63:67:21
[QUAD] MadOwnage!	Forest Gate	A77:64:08:31
[QUAD] Sticky	Nomad	A77:64:61:21
[QUAD] JJE	7.7	A77:65:32:12
[QUAD] MadOwnage!	Hackney	A77:65:47:12
[QUAD] Cuyito	FloydFlow	A77:66:80:10
[QUAD] Goku	Whiteboat	A77:67:01:12
[QUAD] Cuyito	🙄	A77:67:69:12
[QUAD] Forrester	Home Planet	A77:72:18:41
[QUAD] Forrester	Uhut	A77:72:55:11
[QUAD] Sticky	Mars	A77:73:14:11
[QUAD] Sticky	Venus	A77:73:14:12
[QUAD] Sticky	Neptune	A77:73:14:13
[QUAD] Sticky	Mercury	A77:73:42:11
[QUAD] Sticky	Jupiter	A77:73:42:12
[QUAD] Forrester	Blindy	A77:73:89:11
[QUAD] Sticky	Pluton	A77:74:12:12
[QUAD] Sticky	Home Planet	A77:74:34:21
[QUAD] Sticky	Uranus	A77:74:81:11
[QUAD] Forrester	Minut	A77:75:46:41
[QUAD] Sticky	Venuso	A77:76:21:12
[QUAD] Forrester	Jackonville	A77:82:33:12
[QUAD] Forrester	California dream	A77:82:43:21
[QUAD] Forrester	Jasper	A77:83:31:11
[QUAD] Forrester	Oscar	A77:83:75:21
[QUAD] Sticky	Anchor	A77:84:83:11
[QUAD] Forrester	Alomon	A77:87:84:11
[QUAD] Axel27	Alexandra	A77:97:16:20
[QUAD] Louise Vallière	Gate 00	A77:97:50:11
[QUAD] Hardgrave	Astro 1	A78:05:51:11
[QUAD] Hardgrave	Astro 2	A78:05:51:31
[QUAD] Hardgrave	Astro 3	A78:05:51:32
[QUAD] Buegur	Mission	A78:12:78:11
[QUAD] Proton	Akna	A78:13:52:12
[QUAD] Proton	Caruha	A78:13:52:13
[QUAD] Kalya	ant	A78:14:41:21
[QUAD] Kalya	BLAST	A78:14:41:22
[QUAD] Proton	Makati	A78:14:51:21
[QUAD] Trapper	Shavano	A78:15:83:11
[QUAD] Bearded Angel	mexiccanno	A78:21:92:21
[QUAD] Proton	Pilot1	A78:23:25:21
[QUAD] Trapper	Wetterhorn	A78:23:81:11
[QUAD] Horchata	Branchy	A78:23:81:12
[QUAD] Trapper	Heliograph	A78:24:77:12
[QUAD] Renegade	KeeperResearch2	A78:25:48:10
[QUAD] Bearded Angel	Stash	A78:26:32:21
[QUAD] Buegur	Ark	A78:27:41:11
[QUAD] Proton	Alexis	A78:27:41:12
[QUAD] Bearded Angel	Where	A78:31:08:31
[QUAD] Ziggy(BS)	Steel City	A78:31:97:11
[QUAD] Tomcruiser	Obi wan	A78:33:82:11
[QUAD] Proton	Wally	A78:34:41:13
[QUAD] Proton	Pandi	A78:35:40:21
[QUAD] Kalya	hONEY	A78:35:44:11
[QUAD] Bearded Angel	Scruff	A78:36:92:21
[QUAD] Kalya	MORT	A78:41:14:22
[QUAD] MAYAN Tiberas RQ/CT	hope	A78:41:30:31
[QUAD] Kalya	Kler	A78:42:44:11
[QUAD] Bearded Angel	tank	A78:43:17:21
[QUAD] DOOM	78-ide-mu/re-w07	A78:43:89:10
[QUAD] Bearded Angel	Ser?	A78:45:64:11
[QUAD] The Doci	78厂0	A78:45:75:11
[QUAD] Bearded Angel	oxford	A78:45:97:22
[QUAD] Meow	16	A78:46:32:30
[QUAD] Louise Vallière	Fiore	A78:47:85:20
[QUAD] Creeda	Creedledog	A78:48:06:11
[QUAD] Proton	Yupling	A78:48:60:11
[QUAD] Bearded Angel	Bowser Castle	A78:51:19:11
[QUAD] Bearded Angel	turdpile	A78:51:98:12
[QUAD] Bearded Angel	Planète Mère	A78:52:06:11
[QUAD] Proton	Cassian	A78:54:44:11
[QUAD] Proton	Tugsy	A78:54:44:21
[QUAD] moeta	Khoral	A78:54:67:11
[QUAD] JJE	8.7	A78:55:12:11
[QUAD] JJE	8.8	A78:55:12:12
[QUAD] Meow	15	A78:55:31:21
[QUAD] Kalya	Larry	A78:55:31:22
[QUAD] Trapper	Handies	A78:55:45:11
[QUAD] Proton	Destroyer	A78:55:84:21
[QUAD] Kalya	Style	A78:56:70:11
[QUAD] Kalya	5	A78:56:70:21
[QUAD] Proton	Pop	A78:56:86:11
[QUAD] Proton	Mallister	A78:57:02:11
[QUAD] Bearded Angel	skyy	A78:57:46:21
[QUAD] Scotch Bingington	Large Chips	A78:57:63:20
[QUAD] Buegur	Inqusition	A78:58:02:11
[QUAD] Kalya	TRACKER	A78:61:09:11
[QUAD] Kalya	Fly	A78:61:09:21
[QUAD] Bearded Angel	toitle	A78:62:44:21
[QUAD] Proton	Candy	A78:62:76:11
[QUAD] Kalya	Honey	A78:63:30:21
[QUAD] Kalya	river	A78:63:30:22
[QUAD] Bearded Angel	Scar	A78:63:81:11
[QUAD] Scotch Bingington	Apple Pie	A78:65:41:20
[QUAD] Death7270	Quirm	A78:65:55:10
[QUAD] Death7270	Lagrange	A78:65:58:12
[QUAD] Kalya	tree	A78:66:01:21
[QUAD] Scotch Bingington	Hot Chocolate	A78:66:10:21
[QUAD] Proton	Maximun	A78:66:93:11
[QUAD] Scotch Bingington	Mc Flurry	A78:67:29:20
[QUAD] Proton	Underattack	A78:67:50:11
[QUAD] Scotch Bingington	Banana Milkshake	A78:67:54:20
[QUAD] Proton	Home Planet	A78:68:23:21
[QUAD] Bearded Angel	Crusader	A78:68:34:21
[QUAD] Trapper	Shasta	A78:68:91:11
[QUAD] Trapper	Blue Sky	A78:72:39:12
[QUAD] Bearded Angel	all ckear	A78:72:94:20
[QUAD] Kalya	Addon	A78:73:20:23
[QUAD] Kalya	bee	A78:74:01:21
[QUAD] Scotch Bingington	Fillet-o-Fish	A78:75:54:20
[QUAD] Scotch Bingington	Medium Chips	A78:75:77:20
[QUAD] Kalya	Home Planet	A78:75:86:11
[QUAD] Scotch Bingington	Small Chips	A78:76:33:20
[QUAD] Proton	Volcano	A78:77:51:11
[QUAD] Scotch Bingington	Cheese Burger	A78:77:70:23
[QUAD] Buegur	Bishop	A78:77:82:11
[QUAD] Zev	A78	A78:79:43:11
[QUAD] Louise Vallière	Gate 02	A78:82:28:21
[QUAD] NightOwl280	a78tricolorJG	A78:83:00:10
[QUAD] NightOwl280	Brown78JG	A78:83:62:21
[QUAD] Scotch Bingington	Fruit Bag	A78:86:11:20
[QUAD] KevinC (Ni) CLS	12	A78:86:24:21
[QUAD] Trapper	Glenn	A78:87:41:11
[QUAD] Zev	A78	A78:95:33:11
[QUAD] JJE	5.0	A79:03:93:20
[QUAD] AcidCore	79_2	A79:13:85:11
[QUAD] Artur	I	A79:13:85:21
[QUAD] Artur	Z	A79:15:95:21
[QUAD] Meow	17	A79:16:19:20
[QUAD] Trapper	Uncompahgre	A79:16:63:11
[QUAD] JJE	4.0	A79:18:61:22
[QUAD] The Doci	invalid	A79:22:68:13
[QUAD] NightOwl280	CRimsomJG	A79:22:90:21
[QUAD] lycan1	1	A79:23:30:20
[QUAD] lycan1	3	A79:24:07:20
[QUAD] Renegade	Base 4	A79:24:12:10
[QUAD] lycan1	4	A79:24:46:21
[QUAD] Bird Dog	Vizima	A79:26:66:12
[QUAD] MAYAN Tiberas RQ/CT	oh lady who	A79:26:84:20
[QUAD] AcidCore	79_1	A79:28:61:11
[QUAD] The Doci	undefined	A79:30:88:12
[QUAD] Rat Brainz	Trash craft	A79:31:80:12
[QUAD] Artur	e	A79:31:86:21
[QUAD] NightOwl280	ColorwheelJG	A79:32:70:11
[QUAD] Artur	K	A79:32:72:21
[QUAD] Rat Brainz	Skittering	A79:32:97:20
[QUAD] lycan1	5	A79:33:02:20
[QUAD] Rat Brainz	The Burrows	A79:33:12:10
[QUAD] Bird Dog	Toussaint	A79:33:28:11
[QUAD] lycan1	6	A79:33:58:20
[QUAD] lycan1	7	A79:33:93:21
[QUAD] lycan1	8	A79:33:93:23
[QUAD] lycan1	9	A79:34:82:21
[QUAD] Artur	a	A79:35:03:21
[QUAD] Artur	m	A79:35:52:21
[QUAD] Bird Dog	Arinbjorn	A79:36:59:12
[QUAD] Meow	13	A79:36:84:21
[QUAD] NightOwl280	violetGem	A79:37:67:12
[QUAD] Hardgrave	Astro 17	A79:38:80:30
[QUAD] NightOwl280	GreenLime01	A79:39:40:21
[QUAD] JJE	6.0	A79:40:95:11
[QUAD] Green Alien CARTEL ®	Chapter 13JX8	A79:41:63:21
[QUAD] NightOwl280	Red1	A79:41:96:11
[QUAD] Rat Brainz	Fetid Dump	A79:42:56:30
[QUAD] NightOwl280	OrangeJG	A79:42:86:12
[QUAD] lycan1	10	A79:42:94:22
[QUAD] Chosenone	boss	A79:43:13:21
[QUAD] Rat Brainz	Chedda House	A79:43:15:21
[QUAD] Chosenone	hoon	A79:43:60:21
[QUAD] Bird Dog	White Orchard	A79:43:64:11
[QUAD] NightOwl280	tealJG	A79:43:73:21
[QUAD] NightOwl280	BlackGemJG	A79:44:17:11
[QUAD] lycan1	11	A79:44:37:20
[QUAD] NightOwl280	Spectrum	A79:44:45:11
[QUAD] NightOwl280	opalgem	A79:44:46:11
[QUAD] lycan1	12	A79:44:46:21
[QUAD] lycan1	13	A79:44:46:23
[QUAD] Chosenone	Risty	A79:44:65:21
[QUAD] NightOwl280	UltraShift	A79:45:14:11
[QUAD] lycan1	14	A79:45:27:21
[QUAD] lycan1	15	A79:45:27:23
[QUAD] Chosenone	york	A79:45:38:11
[QUAD] Chosenone	otter	A79:45:75:21
[QUAD] Bird Dog	Novigrad	A79:47:08:11
[QUAD] Artur	t	A79:47:08:21
[QUAD] Axel27	Irina	A79:47:11:11
[QUAD] Creeda	Creedlescore	A79:47:17:10
[QUAD] Renegade	Base 2	A79:47:61:10
[QUAD] Bird Dog	Kaer Morhen	A79:47:61:21
[QUAD] Artur	b	A79:48:18:21
[QUAD] Artur	p	A79:48:53:21
[QUAD] Artur	l	A79:51:13:21
[QUAD] Artur	a	A79:51:13:22
[QUAD] Artur	t	A79:51:13:23
[QUAD] Rat Brainz	Plague	A79:51:44:20
[QUAD] Artur	h	A79:51:59:21
[QUAD] Artur	e	A79:51:64:21
[QUAD] moeta	Hydrax	A79:51:98:12
[QUAD] NightOwl280	OakerJG	A79:52:09:21
[QUAD] Axel27	Bianca	A79:52:55:11
[QUAD] lycan1	2	A79:52:70:21
[QUAD] Rat Brainz	Cess Pitt	A79:52:77:10
[QUAD] Chosenone	Kracker	A79:53:21:21
[QUAD] lycan1	16	A79:53:66:20
[QUAD] Chosenone	yuk	A79:53:89:11
[QUAD] Rat Brainz	Fleas	A79:53:98:12
[QUAD] Chosenone	Home Planet	A79:54:18:21
[QUAD] Chosenone	once	A79:54:18:23
[QUAD] Chosenone	guess	A79:54:34:11
[QUAD] Chosenone	mices	A79:54:71:21
[QUAD] Trapper	Whitney	A79:54:90:10
[QUAD] Renegade	KeeperResearch1	A79:55:07:10
[QUAD] Chosenone	Mudda	A79:55:07:21
[QUAD] Chosenone	mudda	A79:55:18:21
[QUAD] Chosenone	coolz	A79:55:22:13
[QUAD] Chosenone	cuzz	A79:55:47:21
[QUAD] Meow	14	A79:55:52:21
[QUAD] Bird Dog	Aedd Gynvael	A79:55:62:11
[QUAD] lycan1	17	A79:55:65:10
[QUAD] Bird Dog	Undvik	A79:55:75:11
[QUAD] Meow	11	A79:55:82:21
[QUAD] Bird Dog	Pont Vanis	A79:56:79:10
[QUAD] Creeda	Ed	A79:58:29:12
[QUAD] NightOwl280	Cobalt-new	A79:58:48:11
[QUAD] Renegade	Base 8	A79:62:36:10
[QUAD] The Doci	void	A79:62:94:12
[QUAD] Artur	s	A79:63:04:22
[QUAD] Meow	5	A79:63:33:21
[QUAD] Trapper	Sneffels	A79:63:65:13
[QUAD] Bird Dog	Nilfgaard	A79:64:12:11
[QUAD] Meow	8	A79:64:14:21
[QUAD] Meow	7	A79:64:19:20
[QUAD] Axel27	Maria	A79:64:20:21
[QUAD] Meow	6	A79:64:83:20
[QUAD] JJE	1.5	A79:64:94:11
[QUAD] Bird Dog	Rivia	A79:65:34:11
[QUAD] JJE	1.4	A79:65:75:11
[QUAD] Axel27	Madalina	A79:66:43:20
[QUAD] DOOM	79-usb-mu/re-w08	A79:66:44:10
[QUAD] Meow	18	A79:66:60:20
[QUAD] Renegade	Base 7	A79:67:53:10
[QUAD] Trapper	Humboldt	A79:67:53:13
[QUAD] Renegade	Base 6	A79:67:93:10
[QUAD] JJE	3.1	A79:68:78:31
[QUAD] Meow	4-R	A79:72:29:20
[QUAD] Renegade	Base 3	A79:72:72:10
[QUAD] Horchata	Nosology	A79:72:87:12
[QUAD] Meow	3	A79:73:34:21
[QUAD] Axel27	Ioana	A79:73:78:20
[QUAD] JJE	1.3	A79:74:88:13
[QUAD] Meow	10	A79:74:88:20
[QUAD] Renegade	Base 5	A79:75:39:10
[QUAD] Artur	Hf	A79:78:03:21
[QUAD] The Doci	zero	A79:78:16:12
[QUAD] JJE	3.2	A79:79:03:11
[QUAD] Death7270	Boorishness	A79:79:03:30
[QUAD] Meow	2	A79:84:10:21
[QUAD] JJE	0.1	A79:84:62:10
[QUAD] JJE	0.7	A79:84:62:11
[QUAD] JJE	0.0	A79:84:62:21
[QUAD] JJE	0.3	A79:84:62:22
[QUAD] Meow	1-R	A79:84:62:23
[QUAD] JJE	0.2	A79:84:62:30
[QUAD] JJE	0.4	A79:84:62:32
[QUAD] JJE	0.5	A79:84:62:41
[QUAD] Meow	12	A79:86:32:30
[QUAD] Hardgrave	y	A79:93:50:11
[QUAD] Hardgrave	x	A79:93:50:21
[QUAD] Meow	9	A79:94:67:20
 
 	 	 ";
        
        var playerList = BaseListParser.ParseFromBaseReport(parseSlice);
        
        Assert.NotEmpty(playerList);
        
    }
}