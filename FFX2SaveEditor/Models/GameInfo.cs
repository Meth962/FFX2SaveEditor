using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFX2SaveEditor
{
    public static class GameInfo
    {
        public static ushort[] ChapterTotals = new ushort[] { 126,109,77,81,124 };

        public static List<StoryFlag> Flags = new List<StoryFlag>()
        {
            // Intro Mission
            new StoryFlag(0x19,0x04,"Rikku: Hey, give it back already!", 1, "Intro Mission"),
            new StoryFlag(0x19,0x80,"????: Sorry, no time for an encore!",1, "Intro Mission"),
            new StoryFlag(0x25,0x20,"Rikku: Hold still!", 1,"Intro Mission"),
            new StoryFlag(0x32,0x02,"Rikku: Hey, you run too fast!",1, "Intro Mission"),
            new StoryFlag(0x32,0x04,"????: You're too slow, little girl.", 1,"Intro Mission"),
            new StoryFlag(0x33,0x40,"????: That's quite enough sniveling, boys.", 1,"Intro Mission"),
            new StoryFlag(0x34,0x20,"Leblanc: But it won't be yours for long, loves!", 1,"Intro Mission"),
            new StoryFlag(0x34,0x40,"Leblanc: I won't let you off so easily next time!",1, "Intro Mission"),
            //-Airship- (+1.8%) 3.4%
            new StoryFlag(0x4b,0x02,"Rikku: You sure look like you were enjoying yourself.", 1,"Airship After Intro Mission"),
            new StoryFlag(0x57,0x20,"Intro to Rikku", 1,"Airship After Intro Mission"),
            new StoryFlag(0x58,0x80,"Intro to Paine", 1,"Airship After Intro Mission"),
            new StoryFlag(0x59,0x20,"Intro to Brother", 1,"Airship After Intro Mission"),
            new StoryFlag(0x59,0x80,"Intro to Brother 2", 1,"Airship After Intro Mission"),
            new StoryFlag(0x5a,0x40,"Intro to Shin", 1,"Airship After Intro Mission"),
            new StoryFlag(0x5a,0x80,"Intro to Barkeep", 1,"Airship After Intro Mission"),
            new StoryFlag(0x1dd5,0x20,"Watched Treasure Sphere #1", 1,"Airship After Intro Mission"),
            new StoryFlag(0x64,0x02,"Buddy: Treasure sphere waves at Gagazete.",1, "Airship After Intro Mission"),
            //-Mt Gagazete- (+2.6%) 6.0%
            new StoryFlag(0x7d,0x02,"Yuna's intro to Gagazete mission.",1,"Gagazete"),
            new StoryFlag(0xbb,0x20,"Paine&Rikku: Yuna!",1,"Gagazete"),
            new StoryFlag(0xd4,0x20,"Rikku: We're not getting across this way.",1,"Gagazete"),
            new StoryFlag(0xed,0x20,"Brother: What happened? Is Yuna okay?",1,"Gagazete"),
            new StoryFlag(0xfa,0x08,"Leblanc: Er, Leblanc. Remember that name well, loves!",1,"Gagazete"),
            new StoryFlag(0xfc,0x02,"Leblanc: And this is the thanks I get for going easy on you.",1,"Gagazete"),
            new StoryFlag(0x113,0x02,"Logos: You look a tad flushed. Why not stop to catch your breath!",1,"Gagazete"),
            new StoryFlag(0x11f,0x20,"Leblanc: You know how I hate the damp!",1,"Gagazete"),
            new StoryFlag(0x12c,0x02,"Ormi: Let's show the ladies a nice, warm welcome!",1,"Gagazete"),
            new StoryFlag(0x138,0x20,"Leblanc: Would-Would you, would you stop staring!",1,"Gagazete"),
            new StoryFlag(0x145,0x10,"Rikku: It figures we'd run into something like this.",1,"Gagazete"),
            new StoryFlag(0x151,0x40,"Leblanc: It's obvious to the trained eye. That sphere's just a dud.",1,"Gagazete"),
            new StoryFlag(0x15e,0x02,"Rikku: Brother, mission complete!",1,"Gagazete"),
            //-Airship- (+0.6%) 6.6%
            new StoryFlag(0x4ee,0x20,"Buddy: He said something about Yuna being in trouble, then he just jumped ship.",1,"Airship After Mission 1"),
            new StoryFlag(0x4fb,0x08,"Yuna: Thank you, Brother.",1,"Airship After Mission 1"),
            new StoryFlag(0x507,0x40,"Yuna: Think it's worth anything? (Speak to Shinra to watch sphere)",1,"Airship After Mission 1"),
            //-Kilika- (+0.6%) 7.2%
            new StoryFlag(0x5e8,0x20,"Yuna's intro to Kilika",1,"Kilika"),
            new StoryFlag(0x5f5,0x02,"Barthello: Dona!",1,"Kilika"),
            new StoryFlag(0x601,0x20,"Dona: Well, look who we have here.",1,"Kilika"),
            //-Luca- (+1.6%) 8.8%
            new StoryFlag(0x93b,0x02,"Yuna: I couldn't bring myself to tell them it was just an impostor.",1,"Luca"),
            new StoryFlag(0x947,0x02,"Yuna: Believe it or not, this was the easy part!",1,"Luca"),
            new StoryFlag(0x954,0x80,"Yuna: The plan was to sneak into the concert, and recover the garment grid.",1,"Luca"),
            new StoryFlag(0x96d,0x08,"Yuna: Did I do it because I couldn't turn him down,...",1,"Luca"),
            new StoryFlag(0x992,0x02,"Yuna: It's me!",1,"Luca"),
            new StoryFlag(0x992,0x10,"Yuna: Rikku sure was having fun (must have talked to yuna as moogle)",1,"Luca"),
            new StoryFlag(0x9ab,0x80,"Yuna: So, this is my life now.",1,"Luca"),
            new StoryFlag(0x9b7,0x20,"Rin: Ah, the lady Yuna.",1,"Luca"),
            //-Mi'ihen Highroad- (+0.2%) 9.0%
            new StoryFlag(0x60e,0x02,"Yuna does intro to Mi'ihen",1,"Mi'ihen Highroad"),
            //-Mushroom Rock Road- (+4.6%) 13.6%
            new StoryFlag(0x61a,0x20,"Rikku: It's those creeps again!",1,"Mushroom Rock Road"),
            new StoryFlag(0x627,0x02,"????: Good to see you again, Lady Yuna!",1,"Mushroom Rock Road"),
            new StoryFlag(0x62a,0x02,"Rikku: Yeah! Let's hunt some fiend! (chose 'sure we're game!')",1,"Mushroom Rock Road"),
            new StoryFlag(0x633,0x20,"Claska: *sighs*",1,"Mushroom Rock Road"),
            new StoryFlag(0x640,0x02,"Yuna: There they are!",1,"Mushroom Rock Road"),
            new StoryFlag(0x64c,0x20,"Ormi: This one ain't no good?",1,"Mushroom Rock Road"),
            new StoryFlag(0x659,0x02,"????: Hey. Long time no see. Remember me?",1,"Mushroom Rock Road"),
            new StoryFlag(0x67e,0x20,"????: Oh, wow! Lady Yuna!",1,"Mushroom Rock Road"),
            new StoryFlag(0x665,0x20,"Yuna: This is Youth League Headquarters.",1,"Mushroom Rock Road"),
            new StoryFlag(0x672,0x02,"????: It's been too long, Lady Yuna.",1,"Mushroom Rock Road"),
            new StoryFlag(0x674,0x08,"Rikku: There sure do seem to be a lot of weirdos around here.",1,"Mushroom Rock Road"),
            new StoryFlag(0x666,0x02,"Maechen: Why, Lady Yuna! I believe it's been fully two years!",1,"Mushroom Rock Road"),
            new StoryFlag(0x666,0x10,"Maechen: These past two years have been truly tumultuous.",1,"Mushroom Rock Road"),
            new StoryFlag(0x667,0x20,"Maechen: The Seekers scoured Spira for ancient spheres,... (2nd iteration)",1,"Mushroom Rock Road"),
            new StoryFlag(0x668,0x80,"Maechen: The founder of the Seekers was a man by the name... (3rd iteration)",1,"Mushroom Rock Road"),
            new StoryFlag(0x669,0x80,"Maechen: New Yevon would not release its spheres. (4th iteration)",1,"Mushroom Rock Road"),
            new StoryFlag(0x66a,0x08,"Maechen: And the man who united them? (5th iteration)",1,"Mushroom Rock Road"),
            new StoryFlag(0x66b,0x10,"Maechen: Looking at all the young people gathered here to... (6th iteration)",1,"Mushroom Rock Road"),
            new StoryFlag(0x66c,0x08,"Maechen: I'd like to shake your hand... (7th final)",1,"Mushroom Rock Road"),
            new StoryFlag(0x66c,0x40,"Maechen: Oh, thank you. Now this old scholar can go in peace. (choose 'of course!')",1,"Mushroom Rock Road"),
            new StoryFlag(0x635,0x04,"Clasko: I want to find my place!",1,"Mushroom Rock Road"),
            new StoryFlag(0x1dbc,0x80,"Let's see, total surviving... (Crimson Report 1)",1,"Mushroom Rock Road"),
            new StoryFlag(0x520,0x20,"Clasko: Why won't the room stop shaking?",1,"Mushroom Rock Road"),
            //-Djose Temple- (+1.0%) 14.6%
            new StoryFlag(0x68b,0x02,"Yuna's intro to Djose Temple",1,"Djose Temple"),
            new StoryFlag(0x697,0x20,"Yuna: Everyone's staring.",1,"Djose Temple"),
            new StoryFlag(0x6a4,0x02,"Gippal: E ryva ymnayto ehdanveafat three people.",1,"Djose Temple"),
            new StoryFlag(0x6a4,0x40,"Gippal: You uh here for an interview?",1,"Djose Temple"),
            new StoryFlag(0x6b0,0x20,"Gippal: Never been this close to a celebrity before.",1,"Djose Temple"),
            //-Moonflow- (+0.6%) 15.2%
            new StoryFlag(0x6c9,0x20,"Yuna's intro to Moonflow",1,"Moonflow"),
            new StoryFlag(0x6d6,0x02,"Tobli: On this spot, I'll be sponsoring...",1,"Moonflow"),
            new StoryFlag(0x709,0x05,"Tobli: It's such a relief meeting reliable people...",1,"Moonflow"),
            //-Guadosalam- (+0.4%) 15.6%
            new StoryFlag(0x73a,0x02,"Yuna's intro to Guadosalam",1,"Guadosalam"),
            new StoryFlag(0x746,0x20,"Yuna: The Farplane: a place that unites the living...",1,"Guadosalam"),
            //-Thunder Plains- (+0.2%) 15.8%
            new StoryFlag(0x753,0x04,"Yuna: Guess what! Rikku finally overcame her fear...",1,"Thunder Plains"),
            //-Macalania Woods- (+2.2%) 18.0%
            new StoryFlag(0x75f,0x20,"Yuna's intro to Macalania",1,"Macalania Woods"),
            new StoryFlag(0x785,0x02,"Bayra: The woods will soon be no more.",1,"Macalania Woods"),
            new StoryFlag(0x791,0x20,"Donga: The end has come faster than I thought.",1,"Macalania Woods"),
            new StoryFlag(0x79e,0x02,"Pukutak: Oh me, oh my, what did you say?",1,"Macalania Woods"),
            new StoryFlag(0x75f,0x80,"Tromell: Oh, High Summoner Yuna.",1,"Macalania Woods"),
            new StoryFlag(0x760,0x10,"Tromell: Many Ronso lost their lives at... (2nd talk)",1,"Macalania Woods"),
            new StoryFlag(0x761,0x20,"Tromell: Ah, well, what brings the high summoner...(4th talk)",1,"Macalania Woods"),
            new StoryFlag(0x7aa,0x20,"Frana es ra?",1,"Macalania Woods"),
            new StoryFlag(0x76c,0x02,"Rikku: O'aka XXIII! Where are you?",1,"Macalania Woods"),
            new StoryFlag(0x778,0x20,"O'aka XXIII: Hahaha!",1,"Macalania Woods"),
            new StoryFlag(0x53A,0x10,"O'aka: Welcome to O'aka's. (first time speaking to him on ship)",1,"Macalania Woods"),
            //-Bikanel Island- (+0.8%) 18.8%
            new StoryFlag(0x7dc,0x20,"Yuna's intro to Bikanel",1,"Bikanel Island"),
            new StoryFlag(0x80e,0x20,"Muugs mega drao yna cusehk du.",1,"Bikanel Island"),
            new StoryFlag(0x827,0x20,"Nhadala: I'm busy, so make it fast okay?",1,"Bikanel Island"),
            new StoryFlag(0x840,0x20,"Nhadala: Just what we needed! (Mission complete)",1,"Bikanel Island"),
            //-Bevelle- (+0.6%) 19.4%
            new StoryFlag(0x7c3,0x20,"Yuna's intro of Bevelle",1,"Bevelle"),
            new StoryFlag(0x7d0,0x02,"Oh! The high summoner!",1,"Bevelle"),
            new StoryFlag(0x7d1,0x20,"Baralai: A pleasure, Lady Yuna. I am Baralai.",1,"Bevelle"),
            //-Calm Lands- (+0.2%) 19.6%
            new StoryFlag(0x859,0x20,"Yuna's intro to Calm Lands",1,"Calm Lands"),
            //-Mt Gagazete- (+0.4%) 20.0%
            new StoryFlag(0x866,0x02,"Yuna's intro to Gagazete",1,"Mt Gagazete"),
            new StoryFlag(0x872,0x40,"Yuna look well. Kimahri glad.",1,"Mt Gagazete"),
            //-Besaid- (+2.2%) 22.2%
            new StoryFlag(0x546,0x02,"Yuna's intro to Besaid",1,"Besaid"),
            new StoryFlag(0x55f,0x02,"LuLu: Welcome back",1,"Besaid"),
            new StoryFlag(0x56c,0x01,"Rikku: Kimahri said he found it on Mt. Gagazete. (sphere cutscene)",1,"Besaid"),
            new StoryFlag(0x584,0x40,"Yuna: Oh, where's Wakka?",1,"Besaid"),
            new StoryFlag(0x591,0x02,"Wakka: something wrong? (inside cave)",1,"Besaid"),
            new StoryFlag(0x59d,0x20,"Brother: This is Brother. You alright, Yuna?",1,"Besaid"),
            new StoryFlag(0x5aa,0x02,"Paine: Find a sphere and the fiends appear.",1,"Besaid"),
            new StoryFlag(0x5c3,0x02,"Wakka: Find anything?",1,"Besaid"),
            new StoryFlag(0x5c3,0x40,"Rikku: So, what sphere were you looking for?",1,"Besaid"),
            new StoryFlag(0x5c6,0x80,"Rikku: That's right, Dad.",1,"Besaid"),
            new StoryFlag(0x5c7,0x20,"Buddy: You read me? You guys about finished down there?",1,"Besaid"),
            //-Zanarkand- (+1.8%) 24.0%
            new StoryFlag(0x8ca,0x02,"Yuna's intro to Zanarkand",1,"Zanarkand"),
            new StoryFlag(0xad6,0x20,"????: Yuna?",1,"Zanarkand"),
            new StoryFlag(0x8e3,0x02,"????: Taro, Hana, you ready?",1,"Zanarkand"),
            new StoryFlag(0x8ef,0x20,"Come in. Come in. Do you read me?",1,"Zanarkand"),
            new StoryFlag(0x8fc,0x02,"Rikku: Um, the clue is \"monkey,\" right?",1,"Zanarkand"),
            new StoryFlag(0x908,0x20,"Cid: Welcome!",1,"Zanarkand"),
            new StoryFlag(0x915,0x02,"Two years ago, we cast off our beliefs here.",1,"Zanarkand"),
            new StoryFlag(0x918,0x08,"Isaaru: My job. I bring excitement to those...",1,"Zanarkand"),
            new StoryFlag(0x92e,0x08,"Paine: How about \"kick...its...ass.\"",1,"Zanarkand"),
            //-Airship- (+0.2%) 24.2%
            new StoryFlag(0x52d,0x02,"Brother: Ehcusehk dydy! Gullwings, du ouun sdydeuhs!",1,"Airship"),
            //-Kilika- (+1.0%) 25.2%
            new StoryFlag(0x898,0x02,"Rikku stumbles into scene giggling. A second before Yuna speaks.",1,"Kilika"),
            new StoryFlag(0x8a4,0x20,"Yuna: These are all sphere hunters?",1,"Kilika"),
            new StoryFlag(0x8a5,0x10,"Nooj: An important sphere is hidden in Kilika",1,"Kilika"),
            new StoryFlag(0x8bd,0x20,"Which is why I keep telling you...",1,"Kilika"),
            new StoryFlag(0x8be,0x40,"Rikku: Ha! How do you like that?",1,"Kilika"),
            //CHAPTER 2
            //-Airship- (+2.4%) 27.6%
            new StoryFlag(0x9d0,0x20,"Rikku: Did you see their faces? They totally wet their pants!",2,"Airship"),
            new StoryFlag(0x9dd,0x04,"Shinra: Hmmm... It's just a regular movie sphere.",2,"Airship"),
            new StoryFlag(0x9dd,0x10,"Brother: Wryd eh Spira es dryd machina?",2,"Airship"),
            new StoryFlag(0x9de,0x10,"Brother: Gullwings! Front and center!",2,"Airship"),
            new StoryFlag(0x9e9,0x20,"Brother: So, uh... Let's give back that sphere...",2,"Airship"),
            new StoryFlag(0x9ec,0x20,"Yuna: The exercise will do us good.",2,"Airship"),
            new StoryFlag(0x9f6,0x04,"Brother: Ah, just some hitchhikers I picked up.",2,"Airship"),
            new StoryFlag(0xa02,0x20,"Yuna: Who's Lenne?",2,"Airship"),
            new StoryFlag(0xa03,0x08,"Yuna: It must have been a dream.",2,"Airship"),
            new StoryFlag(0xa0f,0x02,"Yuna: What's up?",2,"Airship"),
            new StoryFlag(0xa0f,0x40,"Brother: Uh... Aha! As leader, I order Yuna to decide!",2,"Airship"),
            new StoryFlag(0xa1b,0x20,"Brother: Where to?",2,"Airship"),
            //-Youth League- (+1.0%) 28.6%
            new StoryFlag(0xa28,0x02,"Rikku: Wow! They're pulling out all the stops!",2,"Mushroom Rock", 1),
            new StoryFlag(0xa28,0x80,"Shinra: Gullwings, GO! La-la-la-la-la!",2,"Mushroom Rock", 1),
            new StoryFlag(0xa35,0x08,"Nooj: Everyone, three cheers for the Gullwings!",2,"Mushroom Rock",1),
            new StoryFlag(0xa35,0x10,"Nooj: So did you watch it?",2,"Mushroom Rock",1),
            new StoryFlag(0xa36,0x40,"Nooj: that...thing... The colossus you saw is....",2,"Mushroom Rock",1),
            //-New Yevon- (+0.6%) 28.2%
            new StoryFlag(0xa41,0x02,"Rikku: Wow! They're pulling out all the stops!",2,"Bevelle (New Yevon)",2),//NY
            new StoryFlag(0xa4d,0x20,"Baralai: Gullwings, I welcome you.",2,"Bevelle (New Yevon)",2),//NY
            new StoryFlag(0xa4f,0x02,"Baralai: What you saw is Vegnagun, a weapon...",2,"Bevelle (New Yevon)",2),//NY
            //-Airship- (+0.6%) 29.2%
            new StoryFlag(0xa5a,0x02,"Barkeep: Intruders?",2,"Airship"),
            new StoryFlag(0xa5a,0x40,"Leblanc: Who's on top now, Dullwings?",2,"Airship"),
            new StoryFlag(0xa5b,0x02,"Paine: She got us.",2,"Airship"),
            //-Guadosalam- (+0.2%) 29.4%
            new StoryFlag(0xb47,0x20,"Oh, look, the Dullwings.",2,"Guadosalam"),
            //-Besaid- (+0.8%) 30.2%
            new StoryFlag(0xa7f,0x20,"Datto: So you gave the sphere to the Youth League, ya?",2,"Besaid",1),//YL
            new StoryFlag(0xa7f,0x80,"Datto: So you returned the sphere to New Yevon?",2,"Besaid",2),//NY
            new StoryFlag(0xa80,0x80,"Beclem: I am Beclem. I've been dispatched to...",2,"Besaid"),
            new StoryFlag(0xa83,0x04,"Beclem: The way you twaddled on before,...",2,"Besaid"),
            new StoryFlag(0xa84,0x40,"Beclem: Must your kind always prattle on about...",2,"Besaid"),
            //-Kilika- (+0.2%) 30.4%
            new StoryFlag(0xa8c,0x02,"Dona: The Gullwings, was it not?",2,"Kilika"),
            new StoryFlag(0xa8c,0x10,"Dona: If you're going to side with New Yevon,...",2,"Kilika",2),//NY
            //-Luca- (+0.8%) 31.2%
            new StoryFlag(0xd22,0x20,"Shelinda: Hello and welcome, Luca viewers.",2,"Luca"),
            new StoryFlag(0xd24,0x20,"Yuna: huh?",2,"Luca"),
            new StoryFlag(0xd28,0x01,"Paine: Not bad.",2,"Luca"),
            new StoryFlag(0xd2a,0x40,"Yuna: Hey, cut that out!",2,"Luca"),
            //-Mi'ihen Highroad- (+1.4%) 32.6%
            new StoryFlag(0xa9b,0x10,"????: I see. Sorry to bother you...",2,"Mi'ihen Highroad"),
            new StoryFlag(0xa98,0x20,"????: You aren't Lady Yuna, by any chance?",2,"Mi'ihen Highroad"),
            new StoryFlag(0xa9b,0x04,"Rikku: It went this way!",2,"Mi'ihen Highroad"),
            new StoryFlag(0xaa6,0x08,"Rikku: Maybe it's just me...but this is starting...",2,"Mi'ihen Highroad"),
            new StoryFlag(0xaa7,0x40,"Hey! Your friend's in hot water!",2,"Mi'ihen Highroad"),
            new StoryFlag(0xad7,0x08,"Clasko: Hyah!",2,"Mi'ihen Highroad"),
            new StoryFlag(0xad8,0x80,"Yuna: She looks happy.",2,"Mi'ihen Highroad"),
            //-Mushroom Rock- (+1.0%) 33.6%
            new StoryFlag(0xae3,0x20,"Hey, it's the Gullwings!",2,"Mushroom Rock",1),
            new StoryFlag(0xb15,0x80,"Nooj: Oh. It's you.",2,"Mushroom Rock",1),
            new StoryFlag(0xb18,0x80,"Rikku: Whoa, whoa, whoa! You know him?",2,"Mushroom Rock"),
            new StoryFlag(0xb09,0x04,"Elma: So...is it true that once the Gullwings...",2,"Mushroom Rock",1),
            new StoryFlag(0x1da3,0x40,"Guys, where are you? (Crimson Record 7)",2,"Mushroom Rock"),
            //-Mushroom Rock- *New Yevon*
            new StoryFlag(0xae5,0x04,"It's those sphere thieves, the Gullwings!",2,"Mushroom Rock",2),//NY
            new StoryFlag(0xaf0,0x02,"Elma: Lady Yuna, say it ain't so.",2,"Mushroom Rock",2),//NY
            new StoryFlag(0xafc,0x20,"Rikku: It's no good. This thing's not gonna budge.",2,"Mushroom Rock",2),//NY
            new StoryFlag(0xb17,0x40,"Nooj: I see the Gullwings have guts.",2,"Mushroom Rock",2),//NY
            //-Moonflow- (+0.2%) 33.8%
            new StoryFlag(0xb3b,0x02,"Tobli: I am in big, big trouble! I'm supposed... (don't help tobli in Ch1)",7,"Moonflow"),
            new StoryFlag(0xb3c,0x08,"Tobli: With the Gullwings in charge, we'll sell...",2,"Moonflow"),
            new StoryFlag(0xb3d,0x04,"Tobli: And here it is! The promised... (don't help tobli in Ch1)",7,"Moonflow"),
            //-Thunder Plains- (+0.2%) 34.0%
            new StoryFlag(0xb9f,0x20,"Cid: What, ya blind? Can't ya see I'm...",2,"Thunder Plains"),
            //-Macalania Woods- (+1.4%) 35.4%
            new StoryFlag(0xbab,0x20,"Hello, Gullwings. Good to shee yoo.",2,"Macalania Woods"),
            new StoryFlag(0xbad,0x04,"Thank yoo. If yoo find musishun, give...",2,"Macalania Woods"),
            new StoryFlag(0xbb8,0x02,"Bayra: What business do you have with me?",2,"Macalania Woods"),
            new StoryFlag(0xbb8,0x10,"Bayra: I must speak with my friends. It...",2,"Macalania Woods"),
            new StoryFlag(0xbb9,0x01,"Bayra: The spirits of my friends often become...",2,"Macalania Woods"),
            new StoryFlag(0xbc4,0x20,"Donga: Huh? What can I do for ye?",2,"Macalania Woods"),
            new StoryFlag(0xbc5,0x02,"Yuna: I have a favor to ask.",2,"Macalania Woods"),
            //-Calm Lands- (+0.8%) 36.2%
            new StoryFlag(0xc03,0x04,"Clasko: Something tells me this is where...",2,"Calm Lands"),
            new StoryFlag(0xc03,0x10,"Lian: High Summoner Yuna, I am Lian Ronso.",2,"Calm Lands"),
            new StoryFlag(0xc0f,0x40,"Clasko: I was sure this would be the perfect spot,...",2,"Calm Lands"),
            new StoryFlag(0xc1c,0x80,"Clasko: I can't raise anything without a chocobo!",2,"Calm Lands"),
            //-Gagazete- (+0.2%) 36.4%
            new StoryFlag(0xc28,0x20,"Kimahri: Kimahri sorry.",2,"Gagazete"),
            //-Zanarkand- (+0.4%) 36.8%
            new StoryFlag(0xd09,0x20,"Yuna: Looks like business is booming.",2,"Zanarkand"),
            new StoryFlag(0xd16,0x08,"Isaaru: It's a never-ending struggle.",2,"Zanarkand"),
            //-Bikinel Desert- (+0.2%) 37%
            new StoryFlag(0xbf7,0x08,"Nhadala: Oh, before you start digging, I'd really like...",2,"Bikinel Desert"),
            //-Djose- (+0.4%) 37.4%
            new StoryFlag(0xb22,0x02,"That's weird. Where did we drop that thing?",2,"Djose"),
            new StoryFlag(0xb2e,0x20,"Ormi: So that's where it was!",2,"Djose"),
            //-Gagazete- (+0.8%) 38.2%
            new StoryFlag(0xc8c,0x20,"Kimahri: Ronso youth filled with anger. Hate Guado.",2,"Gagazete"),
            new StoryFlag(0xc41,0x20,"Rikku: You mean we're supposed to climb this?",2,"Gagazete"),
            new StoryFlag(0xc68,0x20,"Yuna: Well, as long as we're here...",2,"Gagazete"),
            new StoryFlag(0xc74,0x10,"Yuna: Mission accomplished! We found ourselves a uniform.",2,"Gagazete"),
            //-Airship- (+0.2%) 38.4%
            new StoryFlag(0xa66,0x40,"Brother: It's perfect!",2,"Airship"),
            //-Guadosalam- (+3.4%) 41.8%
            new StoryFlag(0xb48,0x08,"Rikku: Okie-dokie. Let's change.",2,"Guadosalam"),
            new StoryFlag(0xb54,0x04,"Paine: We're not done yet. Where's the sphere?",2,"Guadosalam"),
            new StoryFlag(0xb54,0x10,"Nooj: Thank you, Leblanc.",2,"Guadosalam"),
            new StoryFlag(0xb60,0x20,"Ormi: The boss is a different person when that Nooj...",2,"Guadosalam"),
            new StoryFlag(0xb6d,0x02,"Leblanc: I'm waiting.",2,"Guadosalam"),
            new StoryFlag(0xb6f,0x01,"Logos: The boss fell asleep again?",2,"Guadosalam"),
            new StoryFlag(0xb73,0x04,"Yuna: What does it do?",2,"Guadosalam"),
            new StoryFlag(0xb74,0x02,"Paine: Take it up with the boss.",2,"Guadosalam"),
            new StoryFlag(0xb7a,0x08,"Brother: This is Brother! How's it going?",2,"Guadosalam"),
            new StoryFlag(0xb86,0x02,"Rikku: Hey! This isn't the sphere they stole, is it?",2,"Guadosalam"),
            new StoryFlag(0x1dc9,0x20,"Did you say something? (crimson sphere #10)",2,"Guadosalam"),
            new StoryFlag(0xb86,0x10,"Logos: Only naughty girls would scrounge through...",2,"Guadosalam"),
            new StoryFlag(0xb93,0x08,"Paine: I was wondering why they'd bother stealing...",2,"Guadosalam"),
            new StoryFlag(0xb94,0x10,"Leblanc: W-Wait a second! I'll let you see what's in...",2,"Guadosalam"),
            new StoryFlag(0xb94,0x80,"Leblanc: That is the colossus Vegnagun.",2,"Guadosalam"),
            new StoryFlag(0xb96,0x20,"Leblanc: So then I guess we're on the same side.",2,"Guadosalam"),
            new StoryFlag(0xb97,0x02,"Sin is gone. The Calm is here. I thought our peaceful...",2,"Guadosalam"),
            //-Airship- (+0.4%) 42.2%
            new StoryFlag(0xa73,0x02,"Leblanc: First things first. We are going to Bevelle.",2,"Airship"),
            new StoryFlag(0xa74,0x02,"(before) Yuna: We're going to Bevelle. There should...",2,"Airship"),
            //-Bevelle- (+2.6%) 44.8%
            new StoryFlag(0xca5,0x20,"Rikku: So how're we going to do this?",2,"Bevelle"),
            new StoryFlag(0xca6,0x80,"It's those Youth League spies! We won't have you...",2,"Bevelle",1),//YL
            new StoryFlag(0xca7,0x08,"Oh, the high summoner! Please, forgive my rudeness!",2,"Bevelle (New Yevon)",2),//NY
            new StoryFlag(0xcbe,0x20,"Rikku: Wait. What are fiends doing in the temple?",2,"Bevelle"),
            new StoryFlag(0xccb,0x02,"Yuna: Watch the exit!",2,"Bevelle"),
            new StoryFlag(0xccb,0x20,"Rikku: Hey! Wait! It's us, the Gullwings!",2,"Bevelle (New Yevon)",2),//NY
            new StoryFlag(0xcd7,0x80,"Rikku: That sphere with you-know-who in it.",2,"Bevelle"),
            new StoryFlag(0xcd8,0x02,"There's a connection. Everything's connected.",2,"Bevelle"),
            new StoryFlag(0xce6,0x80,"Paine: I'm going.",2,"Bevelle"),
            new StoryFlag(0xce7,0x40,"With so many things woven together...",2,"Bevelle"),
            new StoryFlag(0xcf0,0x80,"Rikku: It's an aeon!",2,"Bevelle"),
            new StoryFlag(0xcf1,0x08,"Why is this happening? I wish you were here with me.",2,"Bevelle"),
            new StoryFlag(0xcfd,0x02,"Rikku: Nothing...",2,"Bevelle"),
            new StoryFlag(0xcfe,0x02,"Leblanc: I must report to Noojie-Woojie at once!",2,"Bevelle"),
            new StoryFlag(0xcfe,0x20,"This isn't how it was supposed to be.",2,"Bevelle"),
            new StoryFlag(0xce4,0x02,"Baralai: Waht's this? High Summoner Yuna?... (don't meet Baralai in Ch1)",7,"Bevelle"),
            //-CHAPTER 3-
            //-Airship- (+0.8%) 45.6%
            new StoryFlag(0xeb2,0x20,"Buddy: Trouble. And I mean big time!",3,"Airship"),
            new StoryFlag(0xeb3,0x04,"Brother: Is it Gullwing time?",3,"Airship"),
            new StoryFlag(0xeb4,0x02,"Rikku: Hey, I got an idea!",3,"Airship"),
            new StoryFlag(0xeb5,0x08,"Runno up!",3,"Airship"),
            //-Luca- (+0.8%) 46.4%
            new StoryFlag(0x1123,0x20,"Buddy: Hm. No reports of fiend activity here.",3,"Luca"),
            new StoryFlag(0x1130,0x02,"Shelinda: You can't go anywhere in Luca without...",3,"Luca"),
            new StoryFlag(0x1131,0x08,"Shinra: It's elementary, really, once you get...",3,"Luca"),
            new StoryFlag(0x1149,0x04,"Shelinda: High Summoner Yuna!",3,"Luca"),
            //-Mi'ihen Highroad- (+0.6%) 47%
            new StoryFlag(0xf6e,0x02,"It probably doesn't have anything to do with the temples...",3,"Mi'ihen Highroad"),
            new StoryFlag(0xf6e,0x20,"Okay, sounds like it's Mission Time!",3,"Mi'ihen Highroad"),
            new StoryFlag(0xf7a,0x20,"Thank you for all your help. Here's your reward, as promised.",3,"Mi'ihen Highroad"),
            //-Mushroom Rock- (+0.4%) 47.4%
            new StoryFlag(0xf87,0x04,"Yaibal: No need for concern, Lady Yuna. Everything's under control.",3,"Mushroom Rock",1),//YL
            new StoryFlag(0xf88,0x20,"Lucil: As you are probably aware, we have not heard from...",3,"Mushroom Rock"),
            new StoryFlag(0xf89,0x20,"Yaibal: Forgive me, I...I have to return to my duties.",3,"Mushroom Rock (New Yevon)",2),//NY
            //-Djose- (+0.2%) 47.6%
            new StoryFlag(0xf93,0x20,"Gippal: Hey, it's Cid's little girl!",3,"Djose"),
            //-Moonflow- (+0.2%) 47.8%
            new StoryFlag(0xfa0,0x02,"Tobli: This won't do, won't do at all! We've finally put...",3,"Moonflow"),
            //-Guadosalam- (+2.0%) 49.8%
            new StoryFlag(0xfac,0x20,"Ormi: Leblanc, there's nothing to worry about.",3,"Guadosalam"),
            new StoryFlag(0xfb9,0x02,"Leblanc: Leave me alone.",3,"Guadosalam"),
            new StoryFlag(0xfc5,0x20,"Ormi: What if we showed her a sphere of Nooj?",3,"Guadosalam"),
            new StoryFlag(0xfd2,0x08,"Logos: Ormi shot this, not me.",3,"Guadosalam"),
            new StoryFlag(0xfd3,0x08,"Rikku: It's Nooj!",3,"Guadosalam"),
            new StoryFlag(0xfde,0x20,"Yuna: Is this one from Bevelle, too?",3,"Guadosalam"),
            new StoryFlag(0xfdf,0x02,"Bah! The only reason the war's dragging on...",3,"Guadosalam"),
            new StoryFlag(0xfe0,0x20,"Maechen: I'm afraid not. After all, that sphere was...",3,"Guadosalam"),
            new StoryFlag(0xfeb,0x20,"Maechen: Oh, yes, that young man raised quite a few eyebrows...",3,"Guadosalam"),
            new StoryFlag(0x1d7e,0x02,"Kinoc: This is the final exercise.",3,"Guadosalam"),
            //-Thunder Plains- (+0.2%) 50%
            new StoryFlag(0x10f2,0x10,"Lian: Where does Lady Yuna think we should search for way...",3,"Thunder Plains"),
            new StoryFlag(0x10ff,0x01,"Cid: At this rate, who knows when we'll... (told Cid 'not really' in Ch1)",7,"Thunder Plains"),
            //-Macalania Forest- (+0.8%) 50.8%
            new StoryFlag(0x1004,0x08,"Paine: Must be from Macalania Temple.",3,"Macalania Forest"),
            new StoryFlag(0x101d,0x04,"Wryd wys id?",3,"Macalania Forest"),
            new StoryFlag(0x101e,0x01,"O'aka: Come on lad, I've come to give back the money...",3,"Macalania Forest"),
            new StoryFlag(0x101e,0x40,"O'aka: Then I'll just have to start sellin' to fiends...",3,"Macalania Forest"),
            //-Bikanel Desert- (+0.4%) 51.2%
            new StoryFlag(0x104f,0x02,"Nhadala: Boy, am I glad to see you!",3,"Bikanel Desert"),
            new StoryFlag(0x105b,0x40,"Rikku: So where's this Marnela, anyway?",3,"Bikanel Desert"),
            //-Bevelle- *New Yevon*
            new StoryFlag(0x110a,0x20,"Give us a straight answer! Where is Praetor Baralai?",3,"Bevelle (New Yevon)",2),//NY
            new StoryFlag(0x1029,0x20,"Paine: This isn't a playground.",3,"Bevelle (New Yevon)",2),//NY
            //-Calm Lands- (+0.4%) 51.6%
            new StoryFlag(0x1075,0x02,"To be honest, I'd had enough. I wanted to blame them...",3,"Calm Lands"),
            new StoryFlag(0x1081,0x08,"Paine: Careful. Someone might answer.",3,"Calm Lands"),
            //-Gagazete- (+0.4%) 52.0%
            new StoryFlag(0x108d,0x20,"Kimahri: Yuna must leave.",3,"Gagazete"),
            new StoryFlag(0x109a,0x02,"Garik: Ronso hold anger no longer.",3,"Gagazete"),
            //-Zanarkand- (+0.2%) 52.2%
            new StoryFlag(0x1117,0x02,"Isaaru: I've heard that fiends have been appearing...",3,"Zanarkand"),
            //-Besaid- (+2.0%) 54.2%
            new StoryFlag(0xed8,0x04,"Lulu: They're coming from inside the temple.",3,"Besaid"),
            new StoryFlag(0xecb,0x40,"Shinra: Installing a CommSphere. You never know when...",3,"Besaid"),
            new StoryFlag(0xecd,0x01,"Shinra: How asinine.",3,"Besaid"),
            new StoryFlag(0xee4,0x20,"Rikku: Yunie! Yunie! Something's up!",3,"Besaid"),
            new StoryFlag(0xee5,0x40,"Wakka: Hey! All we gotta do is stop the fiends, ya?",3,"Besaid"),
            new StoryFlag(0xef1,0x40,"Yuna: You want to see it burn that badly?",3,"Besaid"),
            new StoryFlag(0xefe,0x04,"Wakka: Whatever's controlling the fiends must be down there.",3,"Besaid"),
            new StoryFlag(0xf0a,0x04,"Yuna: No. Something's not right...",3,"Besaid"),
            new StoryFlag(0xf16,0x40,"Beclem: I see.",3,"Besaid"),
            new StoryFlag(0xf18,0x80,"Wakka: Fiends ever come out of the temple again,...",3,"Besaid"),
            //-Kilika- (+1.0%) 55.2%
            new StoryFlag(0xf23,0x02,"Dona: My, my, my, my... What brings you here?",3,"Kilika"),
            new StoryFlag(0xf2f,0x20,"Rikku: I think it's working!",3,"Kilika"),
            new StoryFlag(0xf3c,0x04,"Yuna: 'Walk the treetops...'",3,"Kilika"),
            new StoryFlag(0xf55,0x04,"Barthello: I'll be okay.",3,"Kilika"),
            new StoryFlag(0xf61,0x40,"Paine: An aeon?",3,"Kilika"),
            //-Airship- (+0.6%) 55.8%
            new StoryFlag(0xebf,0x02,"Rikku: Mmm... I don't get it!",3,"Airship"),
            new StoryFlag(0xec0,0x10,"Yuna: That's true, but they're connected somehow.",3,"Airship"),
            new StoryFlag(0xec2,0x02,"Yuna: Well, we'll just have to charge him a little extra,...",3,"Airship"),
            //-Bevelle- (1.6%) 57.4%
            new StoryFlag(0x1036,0x04,"Rikku: Was that...Gippal?",3,"Bevelle"),
            new StoryFlag(0x1042,0x80,"Nooj: If you were on time, then I'd really start to worry.",3,"Bevelle"),
            new StoryFlag(0x1045,0x02,"Gippal: Who?",3,"Bevelle"),
            new StoryFlag(0x1047,0x08,"Baralai: Why did you shoot Gippal and me?",3,"Bevelle"),
            new StoryFlag(0x1049,0x02,"Nooj: I made him do it.",3,"Bevelle"),
            new StoryFlag(0x104a,0x40,"Paine: I saw Baralai escape.",3,"Bevelle"),
            new StoryFlag(0x104c,0x40,"Paine: No pressure, huh?",3,"Bevelle"),
            new StoryFlag(0x1d58,0x20,"Baralai: This is rough. (watch Crimson Sphere 1)",3,"Bevelle"),
            //-Djose Temple- (+2.2%) 59.6%
            new StoryFlag(0x10a8,0x80,"Yuna: Then that's our cue.",3,"Djose"),
            new StoryFlag(0x10b3,0x04,"Paine: Merged with Al Bhed machina.",3,"Djose"),
            new StoryFlag(0x10bf,0x20,"Rikku: Another hole. I wonder what's down there.",3,"Djose"),
            new StoryFlag(0x10cc,0x02,"Yuna: It's so bright.",3,"Djose"),
            new StoryFlag(0x10cc,0x40,"????: Right here!",3,"Djose"),
            new StoryFlag(0x10da,0x80,"Nooj: Open your eyes!",3,"Djose"),
            new StoryFlag(0x10db,0x01,"Baralai: The end is not far now.",3,"Djose"),
            new StoryFlag(0x10dc,0x10,"I didn't know what had happened.",3,"Djose"),
            new StoryFlag(0x10e5,0x02,"(yuna falls to her knees before screaming)",3,"Djose"),
            new StoryFlag(0x10e5,0x08,"Yuna: Where are you?",3,"Djose"),
            new StoryFlag(0x10e5,0x10,"Yuna: Wait!",3,"Djose"),
            //CHAPTER 4
            //-Airship- (+1.8%) 61.4%
            new StoryFlag(0x1394,0x20,"Brother: Wrad a namiav! I droukrd wa rad mosd oou.",4,"Airship"),
            new StoryFlag(0x1395,0x40,"Shinra: Yeah, the girl from the Songstress dressphere.",4,"Airship"),
            new StoryFlag(0x1396,0x80,"Brother: Forget Lenne! Shuyin's the one who's wanting...",4,"Airship"),
            new StoryFlag(0x13a1,0x08,"Rikku: You met Shuyin, right?",4,"Airship"),
            new StoryFlag(0x13ae,0x04,"(yuna turns around after Paine: They're old friends)",4,"Airship"),
            new StoryFlag(0x13b2,0x02,"But nothing leads to you.",4,"Airship"),
            new StoryFlag(0x13ba,0x10,"Buddy: What about Yuna? Think she'll quit?",4,"Airship"),
            new StoryFlag(0x1d65,0x02,"Baralai: Ammo! (Crimson Report 2)",4,"Airship"),
            new StoryFlag(0x1d71,0x20,"Baralai: What do you make of this Operation Mi'ihen? (Crimson Report 3)",4,"Airship"),
            //-Besaid- (+0.2%) 61.6%
            new StoryFlag(0x1de2,0x02,"Wakka: Hey Yuna, how you been huh?",4,"Besaid"),
            //-Kilika- (+0.2%) 61.8%
            new StoryFlag(0x1e84,0x20,"Dona: Well, that's Kilika port for you.",4,"Kilika"),
            //-Mushroom Rock- (+0.2%) 62.0%
            new StoryFlag(0x1f01,0x80,"Yaibal: Actually, we've received some unconfirmed reports...",4,"Mushroom Rock"),
            //-Bevelle- (+0.2%) 62.2%
            new StoryFlag(0x2085,0x04,"Maroda: Well, for one, I'm running reconnaisance...",4,"Bevelle"),
            //-Airship- (+0.8%) 63%
            new StoryFlag(0x13c6,0x20,"Buddy: Looks like Nooj and Baralai still haven't...",4,"Airship"),
            new StoryFlag(0x13ca,0x08,"Rikku: I know! I know! I bet Tobli would help!",4,"Airship"),
            new StoryFlag(0x13cb,0x04,"Still, I will keep walking these roads.",4,"Airship"),
            new StoryFlag(0x13d3,0x02,"Paine: When you fought Sin, everyone came together and...",4,"Airship"),
            //-Besaid- (+0.4%) 63.4%
            new StoryFlag(0x1dfb,0x02,"Yuna: Is it time?",4,"Besaid"),
            new StoryFlag(0x1e20,0x20,"Beclem: Take my eyes off you for one minute and you're...",4,"Besaid"),
            //-Kilika- (+0.2%) 63.6%
            new StoryFlag(0x1e91,0x08,"Barthello: But without Baralai...",4,"Kilika"),
            //-Luca- (+0.2%) 63.8%
            new StoryFlag(0x2247,0x08,"But I figure once blitzball season starts up...",4,"Luca"),
            //-Djose- (+0.2%) 64%
            new StoryFlag(0x1f65,0x20,"Al Bhed man talks to you (first dialog)",4,"Djose"),
            //-Guadosalam- (+0.2%) 64.2%
            new StoryFlag(0x1fbd,0x08,"Ormi: Yup, she just up and left. Went out lookin' for clues...",4,"Guadosalam"),
            //-Thunder Plains- (+0.2%) 64.4%
            new StoryFlag(0x202e,0x01,"Shinra: Yes, with my latest invention: The ChocoPorter.",4,"Thunder Plains"),
            //-Macalania Woods- (+0.4%) 64.8%
            new StoryFlag(0x2047,0x02,"Bayra: The fayth that protected Spira are not immune...",4,"Macalania Woods"),
            new StoryFlag(0x205f,0x20,"O'aka: Hello! O'aka, at your service!",4,"Macalania Woods"),
            //-Bevelle- *New Yevon*
            new StoryFlag(0x20ac,0x08,"Shinra: I wish I could play sometime too.",4,"Bevelle (New Yevon)",2),//NY
            //-Bikanel- (+0.2%) 65%
            new StoryFlag(0x20c3,0x80,"Nhadala: But one thing...Lately there's been a pretty nasty fiend...",4,"Bikanel"),
            //-Calm Lands- (+0.2%) 65.2%
            new StoryFlag(0x2173,0x01,"Clasko: You're a good boy, aren't you?",4,"Calm Lands"),
            //-Gagazete- (+1.8%) 67%
            new StoryFlag(0x218b,0x20,"Yuna: Hey, Kimahri! I'm going to be in a concert!",4,"Gagazete"),
            new StoryFlag(0x2209,0x01,"Tobli: Ahh! That really hit the spot!",4,"Gagazete"),
            new StoryFlag(0x220a,0x08,"Buddy: So, uh, where to, kids?",4,"Gagazete"),
            new StoryFlag(0x220b,0x01,"O'aka: Welcome to O'aka's! (music note)",4,"Gagazete"),
            new StoryFlag(0x220d,0x01,"Isaaru: Maroda, may I have a word with you?",4,"Gagazete"),
            new StoryFlag(0x220d,0x08,"Elma: I dunno.Why would I know what he's up to?",4,"Gagazete"),
            new StoryFlag(0x220d,0x80,"Maechen: Sacred Mt. Gagazete.",4,"Gagazete"),
            new StoryFlag(0x2210,0x20,"Nhadala: Listen, Cid.It might be cliche, but times...",4,"Gagazete"),
            new StoryFlag(0x2210,0x80,"Dona: My, my, my, my...",4,"Gagazete"),
            //-Mi'ihen Highroad- (+0.4%) 67.4%
            new StoryFlag(0x1ef5,0x08,"Rin: Lately a number of strange events...",4,"Mi'ihen Highroad"),
            new StoryFlag(0x1ef6,0x08,"Rin: I have placed a number of modified comm...",4,"Mi'ihen Highroad"),
            //-Moonflow- (+0.8%) 68.2%
            new StoryFlag(0x13e0,0x08,"Hey, you! You haven't seen Tobli anywhere around...",4,"Moonflow"),
            new StoryFlag(0x13e2,0x08,"You don't suppose he climbed into one a dem trees, do ya?",4,"Moonflow"),
            new StoryFlag(0x13ec,0x08,"Tobli: Spectacularly spectacular! 'Twill be a yummy...",4,"Moonflow"),
            new StoryFlag(0x13ed,0x10,"Advertising ish our shpeshalty.We'll get you your...",4,"Moonflow"),
            //-Airship- (+0.6%) 68.8%
            new StoryFlag(0x13f8,0x20,"Buddy: We're over the Calm Lands now. We ready to go?",4,"Airship"),
            new StoryFlag(0x1405,0x04,"Shinra: A project.I'm engineering a giant sphere screen...",4,"Airship"),
            new StoryFlag(0x1411,0x20,"Buddy: All the Hypello have been deployed.",4,"Airship"),
            //-Besaid- (+0.4%) 69.2%
            new StoryFlag(0x1e39,0x40,"Beclem: You've probably heard, but I've been called back...",4,"Besaid"),
            new StoryFlag(0x1e46,0x02,"Lulu: Shame on you, Yuna.",4,"Besaid"),
            //-Kilika- (+0.6%) 69.8%
            new StoryFlag(0x1eb6,0x20,"Dona: Without you, the house seems so empty.",4,"Kilika"),
            new StoryFlag(0x1ecf,0x20,"Dona: The balloons are sure to reach the temple.",4,"Kilika"),
            new StoryFlag(0x1ee8,0x40,"Barthello: These are some balloons that Dona sent us.",4,"Kilika"),
            //-Mushroom Rock Road- (+0.4%) 70.2%
            new StoryFlag(0x1f1a,0x80,"Yuna: Are you going to fight New Yevon?",4,"Mushroom Rock"),
            new StoryFlag(0x1f27,0x08,"Yuna: You could sneak out and come.",4,"Mushroom Rock"),
            //-Moonflow- (+0.2%) 70.4%
            new StoryFlag(0x1f97,0x40,"Elma: Ohh! I heard you the first time!",4,"Moonflow"),
            //-Guadosalam- (+0.2%) 70.6%
            new StoryFlag(0x1fe3,0x01,"Ormi: Back then we was workin' for those Yevon creeps.",4,"Guadosalam"),
            //-Macalania Woods- (+0.2%) 70.8%
            new StoryFlag(0x206c,0x10,"O'aka: I swear on the O'aka name, I'd have...",4,"Macalania Woods"),
            //-Zanarkand- (+0.4%) 71.2%
            new StoryFlag(0x2215,0x08,"Isaaru: The Hypello told me the news.You're having a concert?",4,"Zanarkand"),
            new StoryFlag(0x2223,0x01,"Isaaru: I wonder what I'm supposed to be protecting?",4,"Zanarkand"),
            //-Airship- (+0.4%) 71.6%
            new StoryFlag(0x141e,0x02,"Barkeep: Rehearshal's shtarting.",4,"Airship"),
            new StoryFlag(0x141e,0x08,"Yuna: It's almost time. Do you think people will show...",4,"Airship"),
            //-Thunder Plains- (+0.4%) 72%
            new StoryFlag(0x1437,0x02,"Hello, Gullwings.Good to shee yoo.",4,"Thunder Plains"),
            new StoryFlag(0x1443,0x20,"Buddy: We're landing! If we cram any more people onboard...",4,"Thunder Plains"),
            //-Airship- (+3.6%) 75.6%
            new StoryFlag(0x1451,0x08,"Rikku: Hey, uh, the crowd is acting kinda funny.",4,"Airship"),
            new StoryFlag(0x1452,0x02,"The Yevonites are here too?",4,"Airship"),
            new StoryFlag(0x1453,0x01,"Paine: Well, Yuna? You're the one wanted to...",4,"Airship"),
            new StoryFlag(0x1453,0x20,"Tobli: The spectators are making a spectacle!",4,"Airship"),
            new StoryFlag(0x1454,0x10,"Yuna: Ready?",4,"Airship"),
            new StoryFlag(0x145c,0x20,"Yuna: One thousand years ago, before the time of Sin...",4,"Airship"),
            new StoryFlag(0x145d,0x20,"Yuna: Believe with me:",4,"Airship"),
            new StoryFlag(0x1469,0x04,"Yuna: I'm all right... I'm fine, really.",4,"Airship"),
            new StoryFlag(0x146a,0x10,"Paine: So the people we saw were Lenne...and Shuyin?",4,"Airship"),
            new StoryFlag(0x1475,0x20,"Maechen: 'Twas a magnificent melody, Lady Yuna.",4,"Airship"),
            new StoryFlag(0x1477,0x01,"About a thousand years ago, Lenne was a popular songstress...",4,"Airship"),
            new StoryFlag(0x1482,0x02,"Paine: So Shuyin was Lenne's lover.",4,"Airship"),
            new StoryFlag(0x1483,0x40,"Yuna: He never heard.The one person she wanted to tell...",4,"Airship"),
            new StoryFlag(0x148e,0x20,"Leblanc: I've been hunting around since we last met,...",4,"Airship"),
            new StoryFlag(0x149b,0x02,"Shinra: What have we here?",4,"Airship"),
            new StoryFlag(0x149c,0x04,"Gippal: An invention like this could change the world.",4,"Airship"),
            new StoryFlag(0x149f,0x04,"Leblanc: What a piece of junk! Forget it, I'll go...",4,"Airship"),
            new StoryFlag(0x14a0,0x02,"Paine: We'll just have to jump into one of those holes.",4,"Airship"),
            //-CHAPTER 5-
            //-Airship- (+2.0%) 77.6%
            new StoryFlag(0x271c,0x20,"Rikku: Vegnagun's definitely bothering me, but...",5,"Airship"),
            new StoryFlag(0x2729,0x02,"Shinra: We know Vegnagun is in the deepest reaches...",5,"Airship"),
            new StoryFlag(0x2729,0x80,"Brother: Who cares! We just pick a hole and dive!",5,"Airship"),
            new StoryFlag(0x2780,0x40,"Barkeep: If yoo love her, tell her how you feel, yesh?",5,"Airship"),
            new StoryFlag(0x2782,0x80,"Barkeep: Thish is my darling, yesh?",5,"Airship"),
            new StoryFlag(0x2774,0x02,"Buddy: Better keep your distance.Wouldn't wanna...",5,"Airship"),
            new StoryFlag(0x2775,0x40,"Buddy: And by some stroke of luck, we found this ship...",5,"Airship"),
            new StoryFlag(0x2777,0x01,"Buddy: Then, it appeared above us, out of nowhere: a single...",5,"Airship"),
            new StoryFlag(0x1d8a,0x80,"Gippal: Why are they killing eachother? (crimson sphere 5)",5,"Airship"),
            new StoryFlag(0x2735,0x40,"Buddy: Looks like Lulu finally had her baby.",5,"Airship"),
            //-Zanarkand- (+0.8%) 78.4%
            new StoryFlag(0x1ab7,0x04,"The monkeys can't do it alone.",5,"Zanarkand"),
            new StoryFlag(0x1acf,0x02,"Maechen: Although Vegnagun was constructed during the Machina War...",5,"Zanarkand"),
            new StoryFlag(0x1ad2,0x10,"Rikku: Gramps! You're dead?",5,"Zanarkand"),
            new StoryFlag(0x1ad4,0x20,"Yuna: So people really are connected.",5,"Zanarkand"),
            //-Besaid- (+1.8%) 80.2%
            new StoryFlag(0x1876,0x20,"Wakka: Hey!",5,"Besaid"),
            new StoryFlag(0x1883,0x02,"Rikku: Or, ra is so cuda!",5,"Besaid"),
            new StoryFlag(0x188f,0x20,"Beclem: Has Wakka settled on a name for his kid?",5,"Besaid"),
            new StoryFlag(0x189c,0x04,"Wakka: I thought I'd go say goodbye to Beclem.",5,"Besaid"),
            new StoryFlag(0x189c,0x80,"Chappu: Hey, Wakka, remember that time...",5,"Besaid"),
            new StoryFlag(0x18a8,0x20,"That night, Wakka gathered everyone in the village...",5,"Besaid"),
            new StoryFlag(0x18a9,0x80,"Wakka: I chose a name. His name is Vidina.",5,"Besaid"),
            new StoryFlag(0x18ab,0x40,"Wakka: But you know, in the end I'm just me.",5,"Besaid"),
            new StoryFlag(0x18ad,0x08,"Rikku: They're in their own little world.",5,"Besaid"),
            new StoryFlag(0x18a0,0x20,"Wakka: Dryhg ouu. (Thank you)... (Episode concluded)",7,"Besaid"),
            //-Kilika- (+1.0%) 81.2%
            new StoryFlag(0x18b6,0x01,"Dona: New Yevon this, Youth League that.",5,"Kilika"),
            new StoryFlag(0x18c1,0x20,"Paine: Songs are powerful.",5,"Kilika"),
            new StoryFlag(0x18c2,0x10,"Dona: Well, I...It seems to me you have forgotten...",5,"Kilika"),
            new StoryFlag(0x18c3,0x40,"Yuna: That's so sweet.",5,"Kilika"),
            new StoryFlag(0x18c5,0x02,"Brother: Oooh! A Gullwings welcome bash?",5,"Kilika"),
            //-Luca- (+0.6%) 81.8%
            new StoryFlag(0x1b71,0x02,"Shelinda: The day that blitz freaks across Spira...",5,"Luca"),
            new StoryFlag(0x1b8a,0x04,"Yuna: Wherever I go, all over Spira is tied to my memories.",5,"Luca"),
            new StoryFlag(0x1ba4,0x04,"Rikku: You and someone you care about are connected...",5,"Luca"),
            //-Mi'ihen Highroad- (+0.2%) 82%
            new StoryFlag(0x1bbc,0x04,"Rin: I would like to talk about the recent string of incidents...",5,"Mi'ihen Highroad"),
            new StoryFlag(0x1aa9,0x02,"Gippal: Just got a transmission. Apparently the Guado...(Gippal's Sphere if you caught Rin)",10,"Mi'ihen Highroad"),
            //-Mushroom Rock Road- (+1.4%) 83.4%
            new StoryFlag(0x19af,0x04,"Elma: I went to your concert! It was spectacular!",5,"Mushroom Rock"),
            new StoryFlag(0x19e1,0x08,"Yaibal: And...I might not be talking to you right now.",5,"Mushroom Rock (New Yevon)",2),//NY
            new StoryFlag(0x19b2,0x20,"Lucil: Very well, all units take your positions!",5,"Mushroom Rock"),
            new StoryFlag(0x19bb,0x40,"Elma: Awright, it's Elma time!",5,"Mushroom Rock"),
            new StoryFlag(0x19bd,0x04,"Lucil: Me? Lady Yuna, if I may?",5,"Mushroom Rock"),
            new StoryFlag(0x19bf,0x80,"Lucil: When the Calm arrived two years ago, it echoed...",5,"Mushroom Rock"),
            new StoryFlag(0x19c8,0x02,"Lucil: Yaibal, your unit will work with Machine Faction...",5,"Mushroom Rock"),
            new StoryFlag(0x19ee,0x01,"Nooj: My body is half-machina.I'm kept alive beyond my time.",5,"Mushroom Rock"),
            //-Djose- (+0.4%) 83.8%
            new StoryFlag(0x19fa,0x02,"Wa did nasaancr on machina consdnucdion and buimd a supanwaapon!",5,"Djose"),
            new StoryFlag(0x19fb,0x08,"Paine: Tell him this:",5,"Djose"),
            //-Moonflow- (+0.4%) 84.2%
            new StoryFlag(0x1a13,0x02,"Tobli: Yunapalooza was a super smasheriffic success!",5,"Moonflow"),
            new StoryFlag(0x1a14,0x80,"Tobli: This is a dream.Mine, I mean!",5,"Moonflow"),
            //-Guadosalam- (+1.2%) 85.4%
            new StoryFlag(0x18da,0x40,"It is as if this music delivered the Guado from our...",5,"Guadosalam"),
            new StoryFlag(0x18e8,0x01,"Rikku: What about you?",5,"Guadosalam"),
            new StoryFlag(0x18e8,0x08,"Donga: Ah, quit yer bellyachin'! Ye'd make a fine leader.",5,"Guadosalam"),
            new StoryFlag(0x18f4,0x04,"Tromell: This was to be the final resting place for the...",5,"Guadosalam"),
            new StoryFlag(0x1900,0x08,"I knew it! Lian and Ayde told me about you!",5,"Guadosalam"),
            new StoryFlag(0x190c,0x20,"Baralai: The Crimson Squad is no more. Maester Kinoc is... (Yevon's Secret sphere)",5,"Guadosalam"),
            //-Thunder Plains- (+1.0%) 86.4%
            new StoryFlag(0x1a38,0x40,"Shinra: Sphere waves scattered udring the concert caused...",5,"Thunder Plains"),
            new StoryFlag(0x1a51,0x80,"Rikku: Howdy? What howdy? What the heck are you doing?",5,"Thunder Plains"),
            new StoryFlag(0x1a54,0x10,"Yuna: If only I could have talked like this with my father...",5,"Thunder Plains"),
            new StoryFlag(0x278d,0x02,"Cid: Shameful, how they gussied this baby up!",5,"Thunder Plains"),
            new StoryFlag(0x279a,0x02,"Cid: Do whad oou wand.",5,"Thunder Plains"),
            //-Macalania Woods- (+0.6%) 87%
            new StoryFlag(0x1a77,0x02,"O'aka: How dare ye drag yer sorry bum back here!",5,"Macalania Woods"),
            new StoryFlag(0x1a6a,0x20,"(immediately on spring-1 scene)",5,"Macalania Woods"),
            new StoryFlag(0x1a6b,0x04,"I'm not ready to call this just a memory. Not yet.",5,"Macalania Woods"),
            //-Bikanel- (+0.4%) 87.4%
            new StoryFlag(0x1964,0x08,"Nhadala: We've got a prickly situation. Fiends are...",5,"Bikanel"),
            new StoryFlag(0x1973,0x08,"Benzo: Find the Gatekeepers before Marnela's strength...",5,"Bikanel"),
            //-Bevelle- (+1.2%) 88.6%
            new StoryFlag(0x1aeb,0x01,"Maroda: He goes around playing superhero and leaves...",5,"Bevelle"),
            new StoryFlag(0x1ae8,0x08,"Pacce: Hey Maroda, who you talkin' about?",5,"Bevelle (New Yevon)",2),//NY
            new StoryFlag(0x1af4,0x10,"Taro: We found it all by ourselves!",5,"Bevelle"),
            new StoryFlag(0x1b01,0x02,"Rikku: Farplane!",5,"Bevelle"),
            new StoryFlag(0x1d97,0x04,"What did you see? (Crimson Sphere 6)",5,"Bevelle"),
            new StoryFlag(0x1b0d,0x02,"Paine: Maester Kinoc!",5,"Bevelle"),
            new StoryFlag(0x1db0,0x02,"Nooj: I'm glad you're alright. (Crimson Sphere 8)",5,"Bevelle"),
            //-Calm Lands- (+0.2%) 88.8%
            new StoryFlag(0x1a83,0x80,"Tobli: Yup-yup! I can taste it in the air!",5,"Calm Lands"),
            //-Gagazete- (+1.2%) 90%
            new StoryFlag(0x1919,0x40,"Garik: Elder, what path should Ronso walk?",5,"Gagazete"),
            new StoryFlag(0x1926,0x02,"Kimahri: Kimahri must lead way to Ronso future.",5,"Gagazete"),
            new StoryFlag(0x1927,0x40,"Kimahri: Lian and Ayde enjoy seeing vast Spira?",5,"Gagazete"),
            new StoryFlag(0x1933,0x08,"Kimahri: Garik not think for himself!",5,"Gagazete"),
            new StoryFlag(0x193e,0x20,"Garik: Maybe it needs horn?",5,"Gagazete"),
            new StoryFlag(0x193f,0x04,"Garik: Honor to Ronso! Honor to mountain!",5,"Gagazete"),
            //-Bikanel- (+0.8%) 90.8%
            new StoryFlag(0x1989,0x20,"Benzo: The Cactuar Nation will be safe from fiends now.",5,"Bikanel"),
            new StoryFlag(0x198a,0x04,"Rikku: Now a fiend's attacking the camp!",5,"Bikanel"),
            new StoryFlag(0x1997,0x40,"Nhadala: It's all relative. This is nothing compared to...",5,"Bikanel"),
            new StoryFlag(0x19a2,0x20,"Yuna: So...I guess Marnela is gone.",5,"Bikanel"),
            //-Mushroom Rock Road- (+1.6%) 92.4%
            new StoryFlag(0x1b32,0x40,"Paine: Time to face my past. Come on.",5,"Mushroom Rock"),
            new StoryFlag(0x1b3f,0x02,"Rikku: Something's coming!",5,"Mushroom Rock"),
            new StoryFlag(0x1b41,0x04,"Shuyin: I wanted to rest forever, but the pyreflies...",5,"Mushroom Rock"),
            new StoryFlag(0x1b4b,0x40,"Shuyin: This is our story, Lene.",5,"Mushroom Rock"),
            new StoryFlag(0x1b58,0x04,"Yuna: Snap out of it!",5,"Mushroom Rock"),
            new StoryFlag(0x1b58,0x40,"Paine: When he died a thousand years ago, his feelings...",5,"Mushroom Rock"),
            new StoryFlag(0x1b59,0x80,"Paine: You'll pay! (a second before she says it)",5,"Mushroom Rock"),
            new StoryFlag(0x1b64,0x80,"Paine: Two years ago, the guys encountered Shuyin's...",5,"Mushroom Rock"),
            //-Calm Lands- (+0.2%) 92.6% (Calm Lands secret dungeon)
            new StoryFlag(0x1a9d,0x20,"They make a cute couple, don't you think?",5,"Calm Lands"),
            //-Djose- (+0.4%) 93%
            new StoryFlag(0x1a08,0x04,"Rikku: So...who taught you to speak Al Bhed?",5,"Djose"),
            new StoryFlag(0x1a0a,0x01,"Paine: What I'm trying to say is that running...(just before this line)",5,"Djose"),
            //-Airship- (+0.2%) 93.2% (mascot)
            new StoryFlag(0x275b,0x02,"Buddy: A special bonus for the Gullwings!",5,"Airship"),
            //-Bevelle- (+0.6%) 93.8% (Via Infinito)
            new StoryFlag(0x1b1a,0x02,"Paine: Trema is the founder of New Yevon. (Floor 60)",5,"Bevelle"),
            new StoryFlag(0x1b26,0x02,"Paine: So. You're Trema. (Floor 100)",5,"Bevelle"),
            new StoryFlag(0x1b28,0x80,"Yuna: I realize that losing my past would mean losing...",5,"Bevelle"),
            //-Airship- (+0.4%) 94.2%
            new StoryFlag(0x2742,0x20,"Brother: Your friendly neigh... Heh?",5,"Airship"),
            new StoryFlag(0x2743,0x02,"Brother: Surging Flapping Neighboring Gullwings, attack!!",5,"Airship"),
            //-Farplane- (+0.8%) 95%
            new StoryFlag(0x27cb,0x80,"We wanted to at least warn someone... but instead...",5,"Farplane"),
            new StoryFlag(0x27cd,0x08,"Yuna: I can handle a shadow.",5,"Farplane"),
            new StoryFlag(0x27d8,0x10,"Logos: Because the boss never goes against Lord Nooj's...",5,"Farplane"),
            new StoryFlag(0x27d9,0x80,"Leblanc: You do that, love. And don't forget to stress...",5,"Farplane"),
            //-Airship- (+1.0%) 96%
            new StoryFlag(0x2768,0x01,"Shinra: The more I study it, the more fascinating it gets.",5,"Airship"),
            new StoryFlag(0x27a8,0x02,"Buddy: Cid?",5,"Airship"),
            new StoryFlag(0x27b3,0x01,"Cid: I don't know what this sphere hunter business is...",5,"Airship"),
            new StoryFlag(0x27b6,0x01,"I was born in Bevelle. I grew up in Besaid...",5,"Airship"),
            new StoryFlag(0x27c0,0x04,"Yuna: Yeah. Next time will be your story.",5,"Airship"),
            //-Farplane- (+4.0%) 100%
            new StoryFlag(0x27e5,0x01,"Gippal: I could use...a nap.",5,"Farplane"),
            new StoryFlag(0x27e6,0x80,"Yuna: Think about it. You know you won't be able to fight...",5,"Farplane"),
            new StoryFlag(0x27f1,0x04,"Gippal: Any ideas, Dr. P? (Paine's sphere)",5,"Farplane"),
            new StoryFlag(0x27f3,0x01,"Paine: What happened to that Paine, I wonder.",5,"Farplane"),
            new StoryFlag(0x280a,0x02,"Yuna: It's moving!",5,"Farplane"),
            new StoryFlag(0x2816,0x80,"Nooj: I have a plan. Can't call it a smart one, though.",5,"Farplane"),
            new StoryFlag(0x2818,0x40,"(When everyone reacts to Yuna saying 'It sucks.')",5,"Farplane"),
            new StoryFlag(0x281a,0x02,"(right after screen changes when you hear 'forgive us.')",5,"Farplane"),
            new StoryFlag(0x281c,0x02,"Paine: Light?",5,"Farplane"),
            new StoryFlag(0x281d,0x02,"Leblanc: And I never was the wait-like-a-good-girl type...",5,"Farplane"),
            new StoryFlag(0x2820,0x04,"Yuna: If we all attack at once, we can do this!",5,"Farplane"),
            new StoryFlag(0x2830,0x01,"Leblanc: You want to get the heel?",5,"Farplane"),
            new StoryFlag(0x283c,0x04,"Leblanc: I'll let you have this one. I'm gonna go cheer... (98.6%)",5,"Farplane"),
            new StoryFlag(0x2848,0x80,"Yuna: The Gullwings are on it!",5,"Farplane"),
            new StoryFlag(0x2856,0x02,"Yuna: This is it, everyone! Stay focused!",5,"Farplane"),
            new StoryFlag(0x2856,0x80,"(a split second after the last line)",5,"Farplane"),
            new StoryFlag(0x2857,0x04,"Yuna: There's something I must tell you. Words left unspoken...",5,"Farplane"),
            new StoryFlag(0x2858,0x10,"Shuyin: You are not Lenne!",5,"Farplane"),
            new StoryFlag(0x2859,0x08,"Shuyin: A thousand years, and this moment is all we get?",5,"Farplane"),
            new StoryFlag(0x285a,0x08,"Lenne: Let's go. I have a new song for you.",5,"Farplane"),
            new StoryFlag(0x2861,0x20,"*screen fades white... (don't do 4 whistles ch3)",7,"Farplane"),
            new StoryFlag(0x2862,0x01,"Yuna: But you know, I'm not worried anymore. (don't do 4 whistles ch3)",7,"Farplane")
        };

        public static List<StoryFlag> Requisites = new List<StoryFlag>()
        {
            new StoryFlag(0x268,0x01,"Slept in airship cabin Chapter 1",1,"Airship",true),
            new StoryFlag(0x268,0x02,"Slept in airship cabin Chapter 2",2,"Airship",true),
            new StoryFlag(0x268,0x04,"Slept in airship cabin Chapter 3",3,"Airship",true),
            new StoryFlag(0x268,0x08,"Slept in airship cabin Chapter 4",4,"Airship",true),
            new StoryFlag(0x268,0x10,"Slept in airship cabin Chapter 5",5,"Airship",true),

            new StoryFlag(0x489,0x20,"Saw HQ form Kilika man's camera Chapter 1",1,"Kilika",true),
            new StoryFlag(0x489,0x40,"Saw HQ from Kilika man's camera Chapter 3",3,"Kilika",true),
            //new StoryFlag(0x439,0x01,"Spoke to al bhed girl with 3 machina on mi'ihen",3,"Mi'ihen"),
            new StoryFlag(0x231,0x40,"Let Clasko join airship",2,"Mi'ihen",true),
            new StoryFlag(0x388,0x80,"Allowed O'aka to lay low on your ship",1,"Macalania",true),

            new StoryFlag(0xc60,0x01,"Told Cid 'You bet I do!' in Zanarkand",1,"Zanarkand",true),

            new StoryFlag(0x439,0x04,"Machina destroying mission complete",3,"Mi'ihen",true),

            new StoryFlag(0x317,0x01,"Shinra spotted installing sphere in mi'ihen",3,"Mi'ihen",true),
            new StoryFlag(0x318,0x20,"Shinra dropped a comm sphere on mi'ihen road N",3,"Mi'ihen",true),
            new StoryFlag(0x234,0x08,"Shinra seen placing a comm sphere at mushroom rock, but then he moves it",3,"Mushroom Rock",true),
            new StoryFlag(0xca1,0x40,"Shinra seen placing a comm sphere at moonflow",3,"Moonflow",true),
            new StoryFlag(0xca1,0x80,"Shinra seen placing a comm sphere at guadosalam",3,"Guadosalam",true),
            new StoryFlag(0xca2,0x01,"Shinra seen placing a comm sphere at thunder plains",3,"Thunder Plains",true),
            new StoryFlag(0xca2,0x02,"Shinra seen placing a comm sphere at macalania",3,"Macalania",true),
            new StoryFlag(0xca2,0x80,"Shinra seen placing a comm sphere at macalania agency",3,"Macalania",true),
            new StoryFlag(0xca3,0x02,"Automatic install on scene of hover driving to cactuar nation",3,"Bikanel",true),
            new StoryFlag(0xca2,0x01,"Automatic install when visiting bridge to Gagazet",3,"Gagazet",true),
            new StoryFlag(0xca2,0x04,"Shinra seen placing a comm sphere at bevelle",3,"Bevelle",true),
            new StoryFlag(0x317,0x08,"Shinra seen placing a comm sphere at Calm Land Agency",3,"Calm Lands",true),
            new StoryFlag(0x318,0x80,"Shinra seen placing a comm sphere in chocobo ranch",3,"Calm Lands",true),
            new StoryFlag(0xca2,0x20,"Shinra seen placing a comm sphere in Gagazet",3,"Gagazet",true),
            new StoryFlag(0xca2,0x40,"Shinra seen placing a comm sphere in Zanarkand",3,"Zanarkand",true),
            new StoryFlag(0xca1,0x01,"Shinra scene placing a comm sphere in Besaid",3,"Besaid",true),
            new StoryFlag(0xca1,0x02,"Shinra seen placing a comm sphere in Djose Temple",3,"Djose Temple",true),

            new StoryFlag(0xf88,0x02,"Four whistles heard in Farplane",5,"Farplane",true)
        };       
    }
}
