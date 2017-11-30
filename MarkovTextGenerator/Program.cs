using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovTextGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain = new Chain();

            Console.WriteLine("Welcome to Marky Markov's Random Text Generator!");

            /*
            Console.WriteLine("Enter some text I can learn from (enter single ! to finish): ");

            while (true)
            {

                Console.Write("> ");

                String line = Console.ReadLine();
                if (line == "!")
                    break;

                chain.AddString(line);  // Let the chain process this string
            }*/
            string[] lines = File.ReadAllLines(@"Text\Minecraft.txt");
            foreach (String line in lines)
            {
                String line2 = new string(line.Where(c => !char.IsPunctuation(c)).ToArray());
                chain.AddString(line2.ToLower());
            }

            // Now let's update all the probabilities with the new data
            chain.UpdateProbabilities();

            // Okay now for the fun part
            Console.WriteLine("Done learning!  Now give me a word and I'll tell you what comes next.");
            Console.Write("> ");

            String nextWord = Console.ReadLine();
            

            while (true)
            {
                nextWord = chain.GetNextWord(nextWord);

                if (nextWord == "")
                    break;

                Console.Write(nextWord + " ");

            }

        }
    }
}
/*
Diamond Sword to Major Steve
Diamond Sword to Major Steve
Take your speed potion and put your diamond helmet on
Diamond Sword to Major Steve
Closing my Minecraft doors chests are empty.
Check your pickaxe, and may Notch love be with you
This is Diamond Sword to Major Steve
You're gonna find diamonds
And the creepers wanna know if you have much armor
Now it's time to dig straight down if you dare!
This is Major Steve to Diamond Pickaxe
I'm mining some obsidian
And it's taking very long, why does it have to?
And tonight lapis doesn't look like diamonds!
From here I have 16 torches left
Noo more coal!
The mines are getting darker and there's nothing I can do...
Though I've mined almost 100 diamonds, I'm getting very low on health
And I think my diamond pickaxe is about to break!
Please tell Notch I love him very much.
He knows!
Diamond Sword to Major Steve
Your sword just broke, there's creepers near!
Can I fight 'till I decease? (x3)
Can I fight all these creepers here's a way out
I see some grass
The mine is getting lighter, and I'm almost getting through.

Uh, open up the potions, pop!
It's my mine come on, mine it up!
Hear a hiss behind the door and the night begins
Creepers done this before, I never let 'em in
Pack up your inventory, 'n' we can go out
Bring some extra food so that you don't starve
Sometimes you forget torches
And you gotta bring your pickaxe
Yeah, you know where we goin'
Sometimes you forget torches

Welcome to my mine, we are mining diamonds
We ain't gonna strip mine
We don't have to fight mobs
Welcome to my mine
Play that noteblock nicely
Show me all those emeralds
We don't gotta dodge lava
Welcome to my mine, welcome to my mine

When it comes and you know that you wanna stay
Block dirt, let's start mining those real things
Keep those swords in our hands, and open up those potions
Let's fight those mobs, come on slash away
Sometimes you forget torches
And you gotta bring a pickaxe
Yeah, we know where we going
Sometimes you forget torches

Welcome to my mine, we are mining diamonds
We don't gotta strip mine, we don't have to fight mobs
Welcome to my mine,play that noteblock nicely
Show me all those emeralds,we don't gotta dodge lava...
Welcome to my mine, welcome to my...

Welcome to my strip mine, the mine, the cave, the crack
My mine is your mine, treating it right
Sorry if my mine don't have the gold
As soon as I dig down I will find more of that
Oh, my goodness, what is that?
Azul brillante, guapo, so we're going to mine that
I think I know what that is
O.M.G it's diamonds!

Welcome to my mine, we will mine diamonds
We don't gotta strip mine
We don't gotta fight mobs
Welcome to my mine, play that noteblock nicely
Show me all those emeralds
We don't gotta dodge lava
Welcome to my mine, welcome to my mine, welcome to my mine
Hah, yeah!

I been in the cave
I been minin' them ores
I feel like I'm outta my game
It feel like my diamonds ain't mined
WHO PLAYS MINECRAFT?
I been in the cave
I been minin' them ores
I feel like I'm outta my game
It feels like my diamonds ain't mined

I don't wanna mine iron
I don't wanna mine iron
I just wanna get diamonds today
I just wanna get diamonds
I don't wanna mine iron
I don't wanna mine iron
I just wanna get diamonds
Now lemme go diamond

All these other ores I'm minin'
Now they think they're diamonds
I been prayin' for some diamonds to save me
No ores are comin'
And my iron don't even matter
I know it
I know it
I know I'm mining deep down
I can't show diamonds
I never had a diamond to call my own
I never had a diamonds
Ain't no ores hittin' my pick
Where you been?
Where you at?
What are your coordinates?
Every ore is precious but nobody cares about iron

I been in the cave
I been minin' them ores
I feel like I'm outta my game
It feel like my diamonds ain't mined
WHO PLAYS MINECRAFT?
I been in the cave
I been minin' them ores
I feel like I'm outta my game
It feels like my diamonds ain't mined

I want you to mine iron
I want you to mine iron
You don't gotta mine today
You don't gotta mine
I want you to mine iron
I want you to mine iron
You don't gotta mine
Now let me mine some ores

It's the first ore when you're pick's been mining on them rocks
And the torches on the wall when it's dark
Pick to- pick with the miner
It's mining on when the cave is dark and seeing ores in the lava pits
Stare at the enderman
Finally knowing it'll kill you
I know that you'll thank Notch, you did
I know where you've mined, where you mine, where you're minin'
I know you're the reason
What's an MC day without an MC night
I'm just trying to mine an ore
Mining is hard
It can be so hard, but you gotta mine right now
You got every ore to mine right now

I been in the cave
I been minin' them ores
I feel like I'm outta my game
It feel like my diamonds ain't mined
WHO PLAYS MINECRAFT?
I been in the cave
I been minin' them ores
I feel like I'm outta my game
It feels like my diamonds ain't mined

I finally wanna mine iron
I finally wanna mine iron
I don't wanna craft today
I don't wanna craft
I finally wanna mine iron
I finally wanna mine iron
I don't wanna craft
I don't wanna craft

Creepers don't hurt the same I know
The cave I travel feels so dark
But I'm mining my ores 'till my pick gives out
And I see my torches melt the slow no
But I don't wanna die
I don't wanna die no more
I don't even wanna fall in lava anymore
Steve don't wanna
Steve don't wanna
Steve don't wanna fall in lava anymore
*/