# Easybots Apps - Examples
Here you can find examples of C# apps containing bots that integrate with the [Easybots Studio & Platform](http://easybots.net)

## What is Easybots Studio?
[Easybots Studio](https://easybots.net/Docs) helps you automate anything in matter of minutes, as long as you have the right bots. 
If the bots you need are not in the [Public App Store](https://easybots.net/AppStore), you can code your own. 
Integrating your code to the Easybots platform usually takes 5-15 minutes. 
See [How To Code My First Bot](https://easybots.net/Docs/FirstBot)

## Running the examples
In order to run the examples you will need to:
* Have **Easybots Studio & Platform** Installed
* Download 'Additional Licence' in Easybots Studio, and replace the contents of 'LicenceAdditional.cs' in the code 
  * Easybots Studion: Develop and Manage Apps -> Get App Licence -> Get Additional Licence
  
## Simplest Example
1. Specify the name of the Easybots app
2. Create link to the Easybots Platform
3. Instantiate your bot
* Easybots Licence file must also be included in the project
```C#
// 1. Specify the name of the Easybots app
[assembly: Easybots.Apps.EasybotsApp("My First App")]
namespace SimplestExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2. Create link to the Easybots Platform
            Easybots.Apps.EasybotsLink.CreateLink();

            // 3. Instantiate your bot 
            var myFirstBot = new MyFirstBot("My First Bot");                        
            Console.ReadLine();
        }
    }

    class MyFirstBot : Easybots.Apps.Easybot
    {
        // Specify the name of the bot
        public MyFirstBot(string botName) : base(botName)
        {}

        [Easybots.Apps.Action]
        public string SayHelloWorld()
        {
            return "Hello World";            
        }
    }
}
```
The result in Easybots Studio:
![alt text](https://easybots.net/Content/Images/Documenation/Devs/MyFirstAction.png)
